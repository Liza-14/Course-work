using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressor
{
    public class ConfigFile
    {
        public IEnumerable<File> FilesToCompress { get; set; }
        public IEnumerable<File> FilesToDecompress { get; set; }
    }
}
