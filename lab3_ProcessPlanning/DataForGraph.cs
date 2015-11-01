using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace lab3_ProcessPlanning
{
    public class DataForGraph
    {
        public int arisingTimeMin;
        public int arisingTimeMax;
        public long averagePauseTime;
        public double processorFreePercent;

        static public void Serialize(List<DataForGraph> dataList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<DataForGraph>));
            using (TextWriter writer = new StreamWriter("dataforgraph.xml"))
            {
                serializer.Serialize(writer, dataList);
            }
        }

        static public void Deserialize(ref List<DataForGraph> dataList)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<DataForGraph>));
            TextReader reader = new StreamReader("dataforgraph.xml");
            object obj = deserializer.Deserialize(reader);
            dataList = (List<DataForGraph>)obj;
            reader.Close();
        }

    }
}
