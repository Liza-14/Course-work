using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCompressor
{
    public static class Decompressor
    {

        public static void DecompressHTML(File file)
        {
            string[] emptyTags = new string[] { "area", "base", "br", "col", "embed", "hr", "img", "input", "link", "menuitem", "meta", "param", "source", "track", "wbr" };
            var source = FileManager.GetFile(file.SourcePath);
            Console.Write("Before decompression " + file.SourcePath.Split('\\').Last() + ": " + source.Length * sizeof(char) + " Bytes");
            var decompressed = source;
            bool isNotDone = true;
            int progressIndex = 0;
            int level = 0;
            bool isOpenedTag = false;
            while (isNotDone)
            {
                int startIndex = decompressed.IndexOf("<", progressIndex);
                if (startIndex == -1) break;
                int endIndex;

                if (decompressed[startIndex + 1] != '/')
                {
                    endIndex = decompressed.IndexOf(">", startIndex);
                    if (endIndex == -1) break;
                    while (decompressed.Substring(startIndex, endIndex - startIndex + 1).Where(x => x == '\"').Count() % 2 != 0)
                    {
                        endIndex = decompressed.IndexOf("\">", endIndex);
                    }
                    string insertStr = "\n";
                    level++;
                    for (int i = 0; i < level; i++)
                    {
                        insertStr = insertStr + "\t";
                    }
                    isOpenedTag = true;
                    if (emptyTags.Contains(decompressed.Substring(startIndex + 1, endIndex - startIndex).Split(' ', '>').First()))
                    {
                        level--;
                        isOpenedTag = false;
                    }
                    decompressed = decompressed.Insert(startIndex, insertStr);
                }
                else
                {
                    endIndex = decompressed.IndexOf(">", startIndex);
                    if (endIndex == -1) break;
                    endIndex = endIndex + 1;
                    string insertStr = "\n";
                    if (!isOpenedTag)
                    {
                        for (int i = 0; i < level; i++)
                        {
                            insertStr = insertStr + "\t";
                        }
                        decompressed = decompressed.Insert(startIndex, insertStr);
                        endIndex = endIndex + level;
                    }
                    endIndex = endIndex - level - 1;
                    level--;
                    isOpenedTag = false;
                }
                progressIndex = endIndex + level + 2;
            }
            Console.WriteLine(" ==> After decompress " + file.SourcePath.Split('\\').Last() + ": " + decompressed.Length * sizeof(char) + " Bytes");
            FileManager.SaveFile(decompressed, file.OutputPath);
        }
        public static void DecompressCSS(File file)
        {
            var source = FileManager.GetFile(file.SourcePath);
            Console.Write("Before decompression " + file.SourcePath.Split('\\').Last() + ": " + source.Length * sizeof(char) + " Bytes");
            var decompressed = source;

            decompressed = decompressed.Replace(",", ", ");
            decompressed = decompressed.Replace(",  ", ", ");
            decompressed = decompressed.Replace("{", " {\n\t");
            decompressed = decompressed.Replace("  {", " {");
            decompressed = decompressed.Replace(";", ";\n\t");
            decompressed = decompressed.Replace("\t}", "}\n");

            Console.WriteLine(" ==> After decompression " + file.SourcePath.Split('\\').Last() + ": " + decompressed.Length * sizeof(char) + " Bytes");
            FileManager.SaveFile(decompressed, file.OutputPath);
        }

        public static void DecompressJS(File file)
        {
            var source = FileManager.GetFile(file.SourcePath);
            Console.Write("Before decompression " + file.SourcePath.Split('\\').Last() + ": " + source.Length * sizeof(char) + " Bytes");
            var decompressed = source;
            bool isDone = false;
            int progressIndex = 0;
            int level = 0;
            while (!isDone)
            {
                var index = decompressed.IndexOfAny(new char[] { '{', '}', ';', 'f' }, progressIndex);
                if (index == -1)
                {
                    break;
                }
                if (decompressed[index] == '{')
                {
                    string insertStr = "\n";
                    level++;
                    for (int i = 0; i < level; i++)
                    {
                        insertStr = insertStr + "  ";
                    }
                    decompressed = decompressed.Insert(index + 1, insertStr);

                    decompressed = decompressed.Insert(index, " ");
                    progressIndex = index + level + 1;
                }
                else if (decompressed[index] == ';')
                {
                    string insertStr = "\n";
                    for (int i = 0; i < level; i++)
                    {
                        insertStr = insertStr + "  ";
                    }

                    decompressed = decompressed.Insert(index + 1, insertStr);
                    progressIndex = index + 1;
                }
                else if (decompressed[index] == 'f')
                {                    
                    if (decompressed.Length > 5 + index)
                    {
                        string isFor = decompressed.Substring(index, 4);
                        if(isFor == "for("){
                            progressIndex = decompressed.IndexOf("{", index);                            
                        }
                        else
                        {
                            progressIndex = index + 1;
                        }
                    }
                    else
                    {
                        progressIndex = index + 1;
                    }
                    
                }
                else
                {
                    string insertStr = "\n";
                    level--;
                    for (int i = 0; i < level; i++)
                    {
                        insertStr = insertStr + "  ";
                    }
                    
                    decompressed = decompressed.Insert(index+1, insertStr);
                    decompressed = decompressed.Remove(index - 2, 2);
                    progressIndex = index ;
                }
            }
            Console.WriteLine(" ==> After decompression " + file.SourcePath.Split('\\').Last() + ": " + decompressed.Length * sizeof(char) + " Bytes");
            FileManager.SaveFile(decompressed, file.OutputPath);
        }
    }
}
