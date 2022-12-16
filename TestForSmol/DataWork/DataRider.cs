using System.IO;
using System.Xml.Serialization;

namespace TestForSmol.DataWork
{
    public class DataRider<T>
    {
        private readonly string PathAboutOrder;

        public DataRider(string puthAboutOrder) =>
            PathAboutOrder = puthAboutOrder;

        public T ReadDataFromXml()
        {
            XmlSerializer xmlSerializer = new(typeof(T));
            T order;
            try
            {
                var fileStream = new FileStream(PathAboutOrder, FileMode.Open);
                // десериализуем объект
                order = (T)xmlSerializer.Deserialize(fileStream);
            }
            catch
            {
                return default;
            }

            return order;
        }
    }
}
