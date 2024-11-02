using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ServerApp
{
    internal static class Data
    {
        public static List<Organization> Organizations = new List<Organization>();

        public static void LoadData()
        {
            Console.WriteLine("Текущий рабочий каталог: " + Directory.GetCurrentDirectory());
            string path = GetPathToFile();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Organizations = JsonConvert.DeserializeObject<List<Organization>>(json);
                Console.WriteLine("Файл успешно считан");
            }
            else
            {
                Console.WriteLine("Не удалось прочитать json файл");
            }
        }

        private static string GetPathToFile()
        {
            string rootPath = null;
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var directoryInfo = Directory.GetParent(baseDirectory)?.Parent;

            if (directoryInfo?.Parent == null)
            {
                return null;
            }

            rootPath = directoryInfo.Parent.FullName;
            rootPath += @"\\resources\\data.json";

            return rootPath;
        }

        public static void SaveData()
        {
            string json = JsonConvert.SerializeObject(Organizations, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("data.json", json);
        }
    }
}

