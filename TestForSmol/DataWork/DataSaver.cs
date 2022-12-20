using System;
using System.IO;
using System.IO.Pipes;
using System.Xml.Serialization;

namespace TestForSmol.DataWork
{
    public class DataSaver<T>
    {
        private readonly string PathToSaveFolder;
        private short SaveNameNumber = 0;

        public DataSaver(string pathToSaveFolder) =>
            PathToSaveFolder = pathToSaveFolder;

        public void Save(T order, string saveName)
        {
            if (order is null)
                return;
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                FileStream fileStream = new(SavePath(saveName), FileMode.CreateNew);
                xmlSerializer.Serialize(fileStream, order);
                Console.WriteLine("Обновлен");
                fileStream.Close();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Ошибка InvalidOperationException - {ex.Message}, код: {ex.HResult}");
            }
            catch (IOException ex)
            {
                if (ex.HResult is -2147024816)
                {
                    SaveNameNumber++;
                    Save(order, saveName);
                }
                else
                    Console.WriteLine($"Ошибка IOException - {ex.Message}, код: {ex.HResult}");

            }
            SaveNameNumber = 0;
        }

        private string SavePath(string saveName) =>
            SaveNameNumber is 0 ? $"{PathToSaveFolder}\\{saveName}.xml" : $"{PathToSaveFolder}\\{saveName}_{SaveNameNumber}.xml";
    }
}
