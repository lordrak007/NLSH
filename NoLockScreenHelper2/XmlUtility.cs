using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LTools
{

    public static class XmlUtility
    {

        /// <summary>
        /// Serialize to string.
        /// </summary>
        /// <typeparam name="T">object type (class)</typeparam>
        /// <param name="o">object to serialize</param>
        /// <returns>xml data</returns>
        public static string SerializeToString<T>(T o)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, o);
                return writer.ToString();
            }
        }


        /// <summary>
        /// Deserialize from string.
        /// </summary>
        /// <typeparam name="T">object type (class)</typeparam>
        /// <param name="xml">xml data</param>
        /// <returns>object to deserialize</returns>
        public static T DeserializeFromString<T>(string xml)
        {
            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Serialize to file.
        /// </summary>
        /// <typeparam name="T">object type (class)</typeparam>
        /// <param name="o">object to serialize</param>
        /// <param name="path">path to file</param>
        public static void SerializeToFile<T>(T o, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, o);
            }
        }

        /// <summary>
        /// Deserialize from file.
        /// </summary>
        /// <typeparam name="T">object type (class)</typeparam>
        /// <param name="path">path to file</param>
        /// <returns>object to deserialize</returns>
        public static T DeserializeFromFile<T>(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Serialize to xml document
        /// </summary>
        /// <typeparam name="T">object type (class)</typeparam>
        /// <param name="o">object to serialize</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument SerializeToXmlDocument<T>(T obj)
        {
            XmlDocument document = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (XmlWriter writer = document.CreateNavigator().AppendChild())
                serializer.Serialize(writer, obj);

            return document;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document"></param>
        /// <returns></returns>
        public static T DeserializeFromXmlDocument<T>(XmlDocument document)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlNodeReader reader = new XmlNodeReader(document.DocumentElement))
                return (T)serializer.Deserialize(reader);
        }
    }


}

