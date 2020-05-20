using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressor
{
    public class File
    {
        public File() { }
        public File(string sourcePatrh, string outputPath)
        {
            this.SourcePath = sourcePatrh;
            this.OutputPath = outputPath;
        }
        public string SourcePath { get; set; }
        public string OutputPath { get; set; }
    }
}
