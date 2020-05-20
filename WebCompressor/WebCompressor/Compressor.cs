using System;
using System.IO;
using System.Linq;

namespace WebCompressor
{
    public static class Compressor
    {
        
        public static void СompressHTML(File file)
        {
            var source = FileManager.GetFile(file.SourcePath);
            Console.Write("Before compression " + file.SourcePath.Split('\\').Last() + ": " + source.Length * sizeof(char) + " Bytes");
            var compressed = source;
            bool isNotDone = true;
            while (isNotDone)
            {
                isNotDone = false;
                while (compressed.Contains("\n"))
                {
                    compressed = compressed.Replace("\n", "");
                    isNotDone = true;
                }
                while (compressed.Contains("\t<"))
                {
                    compressed = compressed.Replace("\t<", "<");
                    isNotDone = true;
                }
                while (compressed.Contains(" <"))
                {
                    compressed = compressed.Replace(" <", "<");
                    isNotDone = true;
                }
                while (compressed.Contains("> "))
                {
                    compressed = compressed.Replace("> ", ">");
                    isNotDone = true;
                }
                while (compressed.Contains("\"  "))
                {
                    compressed = compressed.Replace("\"  ", "\" ");
                    isNotDone = true;
                }
            }
            Console.WriteLine(" ==> After compression " + file.SourcePath.Split('\\').Last() + ": " + compressed.Length * sizeof(char) + " Bytes");
            FileManager.SaveFile(compressed, file.OutputPath);
        }
        public static void CompressCSS(File file)
        {
            var source = FileManager.GetFile(file.SourcePath);
            Console.Write("Before compression " + file.SourcePath.Split('\\').Last() + ": " + source.Length * sizeof(char) + " Bytes");
            var compressed = source;
            bool isNotDone = true;
            while (isNotDone)
            {
                isNotDone = false;

                while (compressed.Contains("{ "))
                {
                    compressed = compressed.Replace("{ ", "{");
                    isNotDone = true;
                }
                while (compressed.Contains(" {"))
                {
                    compressed = compressed.Replace(" {", "{");
                    isNotDone = true;
                }
                while (compressed.Contains("} "))
                {
                    compressed = compressed.Replace("} ", "}");
                    isNotDone = true;
                }
                while (compressed.Contains(" }"))
                {
                    compressed = compressed.Replace(" }", "}");
                    isNotDone = true;
                }
                while (compressed.Contains("; "))
                {
                    compressed = compressed.Replace("; ", ";");
                    isNotDone = true;
                }
                while (compressed.Contains("\n"))
                {
                    compressed = compressed.Replace("\n", "");
                    isNotDone = true;
                }
                while (compressed.Contains(", "))
                {
                    compressed = compressed.Replace(", ", ",");
                    isNotDone = true;
                }               
            }
            Console.WriteLine(" ==> After compression " + file.SourcePath.Split('\\').Last() + ": " + compressed.Length * sizeof(char) + " Bytes"); ;
            FileManager.SaveFile(compressed, file.OutputPath);
        }
        public static void CompressJS(File file)
        {
            var source = FileManager.GetFile(file.SourcePath);
            Console.Write("Before compression " + file.SourcePath.Split('\\').Last() + ": " + source.Length * sizeof(char) + " Bytes");
            var compressed = source;
            bool isNotDone = true;
            while (isNotDone)
            {
                isNotDone = false;

                while (compressed.Contains("\n"))
                {
                    compressed = compressed.Replace("\n", string.Empty);
                    isNotDone = true;
                }
                while (compressed.Contains("\r"))
                {
                    compressed = compressed.Replace("\r", string.Empty);
                    isNotDone = true;
                }
                while (compressed.Contains("\t"))
                {
                    compressed = compressed.Replace("\t", string.Empty);
                    isNotDone = true;
                }
                while (compressed.Contains("; "))
                {
                    compressed = compressed.Replace("; ", ";");
                    isNotDone = true;
                }
                while (compressed.Contains("  return"))
                {
                    compressed = compressed.Replace("  return", " return");
                    isNotDone = true;
                }
                while (compressed.Contains(" return"))
                {
                    compressed = compressed.Replace(" return", ";return");
                    isNotDone = true;
                }
                while (compressed.Contains("{ "))
                {
                    compressed = compressed.Replace("{ ", "{");
                    isNotDone = true;
                }
                while (compressed.Contains(" {"))
                {
                    compressed = compressed.Replace(" {", "{");
                    isNotDone = true;
                }
                while (compressed.Contains("} "))
                {
                    compressed = compressed.Replace("} ", "}");
                    isNotDone = true;
                }
                while (compressed.Contains(" }"))
                {
                    compressed = compressed.Replace(" }", "}");
                    isNotDone = true;
                }
                while (compressed.Contains(" ("))
                {
                    compressed = compressed.Replace(" (", "(");
                    isNotDone = true;
                }

            }
            Console.WriteLine(" ==> After compression " + file.SourcePath.Split('\\').Last() + ": " + compressed.Length * sizeof(char) + " Bytes"); ;
            FileManager.SaveFile(compressed, file.OutputPath);
        }
    }
}
