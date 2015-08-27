using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScanner
{
    internal class DuplicationScanner
    {
        private readonly Guid scanId;

        private IEnumerable<ScanState> state;
        private int ownerCounter = 0;
        private int duplicateCounter = 0;
        private int multiprocessed = 0;
        private int count = 0;

        public DuplicationScanner(Guid scanId)
        {
            this.scanId = scanId;
        }

        public async Task<ScanResult> ScanAsync()
        {
            return await Task.Run(() => { return Scan(); });
        }

        public ScanResult Scan()
        {
            this.BuildInitialState();

            this.ApplyCrudeSortorder();

            this.PerformScan();

            this.PersistScan();

            return new ScanResult { Count = count, DuplicationCount = duplicateCounter, UniqueCount = ownerCounter, Multiprocessed = multiprocessed };
        }

        private void PersistScan()
        {
            using (var context = new DatabaseContext())
            {
                context.DuplicationOwners.AddRange(this.state.Where(suspect => suspect.Owner != null).Select(item => item.Owner));
                context.SaveChanges();
            }

        }

        private void PerformScan()
        {
            while (this.state.Any(item => !item.Used))
            {
                PerformScanInternal();
            }
        }

        private void PerformScanInternal()
        {
            Parallel.ForEach(this.state, (suspect) =>
            {
                if (!suspect.TrySetUsed())
                {
                    multiprocessed++;
                    return;
                }
                count++;
                ScanState owner;
                if (this.TryFindOwner(suspect, out owner))
                {
                    owner.Add(suspect);
                    duplicateCounter++;
                }
                else
                {
                    suspect.Add(suspect);
                    ownerCounter++;
                }
            });

        }

        private bool TryFindOwner(ScanState suspect, out ScanState owner)
        {
            owner = state.FirstOrDefault(item => item.DataFile.Id != suspect.DataFile.Id 
                                                    && item.Used 
                                                    && item.DataFile.Size == suspect.DataFile.Size 
                                                    && item.DataFile.Hash == suspect.DataFile.Hash);
            return owner != null;
        }

        private void BuildInitialState()
        {
            using (var context = new DatabaseContext())
            {
                this.state = context.SearchFiles.Where(item => item.ScanId == this.scanId).Select(res => new ScanState { DataFile = res }).ToList();
            }
        }

        private void ApplyCrudeSortorder()
        {
            this.state = this.state.OrderBy(item => item.DataFile.Size);
        }

        private class ScanState
        {
            private readonly object syncLock = new object();

            public ScanState()
            {
            }

            public DataFile DataFile { get; set; }

            public DuplicationOwner Owner { get; private set; }

            public void Add(ScanState state)
            {
                lock (this.syncLock)
                {
                    if (this.Owner == null)
                    {
                        this.Owner = new DuplicationOwner { Owner = state.DataFile, ScanId = state.DataFile.ScanId };
                    }
                    else
                    {
                        this.Owner.DuplicateFiles.Add(new DuplicateFile() { ScanId = state.DataFile.ScanId, DataFile = state.DataFile });
                    }
                }
            }

            public bool Used { get; private set; }

            public bool TrySetUsed()
            {
                lock (this.syncLock)
                {
                    if (this.Used) return false;
                    this.Used = true;
                    return true;
                }
            }
        }

    }
}
