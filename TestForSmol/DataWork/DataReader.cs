using System;
using System.IO;
using System.Xml.Serialization;

namespace TestForSmol.DataWork
{
    public class DataReader<T>
    {
        // изменить catch 
        // Проверка самого файла(Расширение и не пустой ли он ) 

        private readonly string PathToFile;

        public DataReader(string pathToFile) =>
            PathToFile = pathToFile;

        public T ReadDataFromXml()
        {
            XmlSerializer xmlSerializer = new(typeof(T));
            T order;
            try
            {
                FileStream fileStream = new(PathToFile, FileMode.Open);
                order = (T)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
            }   
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка Exception - {ex.Message}, код: {ex.HResult}");
                return default;
            }

            return order;
        }
    }
}
