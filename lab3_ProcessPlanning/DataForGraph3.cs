using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3_ProcessPlanning
{
    public class DataForGraph3
    {
        public int priority;
        public long averagePauseTime;

        static public void Serialize(List<DataForGraph3> dataList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<DataForGraph3>));
            using (TextWriter writer = new StreamWriter("dataforgraph3.xml"))
            {
                serializer.Serialize(writer, dataList);
            }
        }

        static public bool Deserialize(ref List<DataForGraph3> dataList)
        {
            if (File.Exists("dataforgraph3.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<DataForGraph3>));
                TextReader reader = new StreamReader("dataforgraph3.xml");
                object obj = deserializer.Deserialize(reader);
                dataList = (List<DataForGraph3>)obj;
                reader.Close();
                return true;
            }
            return false;
        }
    }
}
