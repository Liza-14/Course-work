using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressor
{
    public static class FileManager
    {
        public static string GetFile(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                return file.ReadToEnd();
            }
        }
        public static void SaveFile(string data, string path)
        {
            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(data);
                file.Close();
            }
        }
    }
}
