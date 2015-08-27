using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureScanner
{
    internal class ScanResult
    {
        public int Count { get; set; }
        public int DuplicationCount { get; set; }
        public int Multiprocessed { get; internal set; }
        public int UniqueCount { get; set; }
    }
}
