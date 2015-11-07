using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace lab3_ProcessPlanning
{
    public class DataForGraph1
    {
        public int arisingTimeMin;
        public int arisingTimeMax;
        public long averagePauseTime;
        public double processorFreePercent;

        static public void Serialize(List<DataForGraph1> dataList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<DataForGraph1>));
            using (TextWriter writer = new StreamWriter("dataforgraph.xml"))
            {
                serializer.Serialize(writer, dataList);
            }
        }

        static public void Deserialize(ref List<DataForGraph1> dataList)
        {
            if (File.Exists("dataforgraph.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<DataForGraph1>));
                TextReader reader = new StreamReader("dataforgraph.xml");
                object obj = deserializer.Deserialize(reader);
                dataList = (List<DataForGraph1>)obj;
                reader.Close();
            }        
        }

    }
}
