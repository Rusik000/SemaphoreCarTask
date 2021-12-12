using Newtonsoft.Json;
using SemaphoreTask.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaphoreTask.FileHelper
{
    public static class JsonHelper
    {

        public static string filename { get; set; }
        public static void JSONSerialization(ObservableCollection<Car> database, string Filename)
        {
            filename = Filename;
            var serializer = new JsonSerializer();
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    jsonTextWriter.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonTextWriter, database);
                }
            }
        }
        public static ObservableCollection<Car> JSONDeSerialization(string filename)
        {
            var serializer = new JsonSerializer();

            using (StreamReader streamReader = new StreamReader(filename))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    var database = serializer.Deserialize<ObservableCollection<Car>>(jsonTextReader);
                    return database;
                }
            }
        }
    }
}
