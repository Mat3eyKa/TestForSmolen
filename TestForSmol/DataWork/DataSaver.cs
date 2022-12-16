using System;
using System.IO;
using System.Xml.Serialization;

namespace TestForSmol.DataWork
{
    public class DataSaver<T>
    {
        private readonly string FolderToSeve;
        private short SaveNameNumber = 0;

        public DataSaver(string folderToSave) =>
            FolderToSeve = folderToSave;

        public void Save(T order, string saveName)
        {
            try
            {
                XmlSerializer xmlSerializer = new(typeof(T));
                FileStream fileStream = new(SavePath(saveName), FileMode.CreateNew);
                xmlSerializer.Serialize(fileStream, order);
            }
            catch (IOException)
            {
                SaveNameNumber++;
                Save(order, saveName);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Ошибка сохранения");
            }
            SaveNameNumber = 0;
        }

        private string SavePath(string saveName) =>
            SaveNameNumber == 0 ? $"{FolderToSeve}\\{saveName}.xml" : $"{FolderToSeve}\\{saveName}_{SaveNameNumber}.xml";
    }
}
