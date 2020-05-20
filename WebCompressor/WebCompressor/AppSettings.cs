using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebCompressor
{
    static class AppSettings
    {
        private static string configFilePath = GetPath();
        public static ConfigFile GetFiles()
        {
            Console.WriteLine(configFilePath);
            if (System.IO.File.Exists(configFilePath))
            {
                using (StreamReader configFile = new StreamReader(configFilePath))
                {                    
                    var config = JsonConvert.DeserializeObject<ConfigFile>(configFile.ReadToEnd());
                    return config;
                }                
            }
            else
            {
                CreateConfigFile();
                Console.WriteLine("Config file is not exist");
                Console.WriteLine("Empty config file have been created");
                using (StreamReader configFile = new StreamReader(configFilePath))
                {
                    var config = JsonConvert.DeserializeObject<ConfigFile>(configFile.ReadToEnd());
                    return config;
                }
            }
        }

        private static string GetPath()
        {
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(exePath, "config.json");
        }

        private static void CreateConfigFile()
        {
            using (FileStream fstream = new FileStream(configFilePath, FileMode.OpenOrCreate))
            {
                var json = "{    \n   \"filesToCompress\": [\n        {\n            \"sourcePath\": \"\",\n            \"outputPath\": \"\"\n        }\n    ],\n   \"filesToDecompress\": [\n        {\n            \"sourcePath\": \"\",\n            \"outputPath\": \"\"\n        }\n    ]\n}";
                byte[] array = System.Text.Encoding.Default.GetBytes(json);
                fstream.Write(array, 0, array.Length);
            }
        }
    }
}
