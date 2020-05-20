using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<File> files = AppSettings.GetFiles().FilesToCompress;
            IEnumerable<File> filesToDecompress = AppSettings.GetFiles().FilesToDecompress;

            foreach (var file in files)
            {
                var format = file.SourcePath.Split('.').Last().ToUpper();

                switch (format)
                {
                    case "HTML":
                        Compressor.СompressHTML(file);
                        break;
                    case "CSS":
                        Compressor.CompressCSS(file);
                        break;
                    case "JS":
                        Compressor.CompressJS(file);
                        break;
                }
            }

            foreach (var file in filesToDecompress)
            {
                var format = file.SourcePath.Split('.').Last().ToUpper();

                switch (format)
                {
                    case "HTML":
                        Decompressor.DecompressHTML(file);
                        break;
                    case "CSS":
                        Decompressor.DecompressCSS(file);
                        break;
                    case "JS":
                        Decompressor.DecompressJS(file);
                        break;
                }
            }

        }
    }
}
