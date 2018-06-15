using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Syncfusion.Addin.Utility
{
    /// <summary>
    /// XML�ļ�ת��
    /// </summary>
    public static class XmlConvertor
    {
        /// <summary>
        /// ���кŶ���Ϊ�ַ��� serialize an object to string.
        /// </summary>
        /// <param name="obj">
        ///  ���� the object.
        /// </param>
        /// <returns>
        /// �������л��ַ���  the serialized string.
        /// </returns>
        public static string ObjectToXml(object obj)
        {
            return XmlConvertor.ObjectToXml(obj, false);
        }

        /// <summary>
        /// ���кŶ���Ϊ�ַ���  serialize an object to string.
        /// </summary>
        /// <param name="obj">
        /// ���� the object.
        /// </param>
        /// <param name="toBeIndented">
        /// �Ƿ�������     whether to be indented.
        /// </param>
        public static string ObjectToXml(object obj, bool toBeIndented)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            String content = String.Empty;
            UTF8Encoding encoding = new UTF8Encoding(false);
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding))
                {
                    xmlTextWriter.Formatting = toBeIndented ? Formatting.Indented : Formatting.None;
                    xmlSerializer.Serialize(xmlTextWriter, obj);

                    content = encoding.GetString(memoryStream.ToArray());
                }
            }
            return content;
        }

        /// <summary>
        /// �����л�һ������  deserialize string.to an object.
        /// </summary>
        /// <param name="type">
        /// the type of the object.
        /// </param>
        /// <param name="xml">
        /// �ַ�����Ҫ�����л���
        /// </param>
        /// <returns>
        /// �����л��Ķ���
        /// </returns>
        public static object XmlToObject(Type type, string xml)
        {
            if (xml == null)
            {
                throw new ArgumentNullException("xml");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            object obj = null;
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = new XmlTextReader(stringReader))
                {
                    obj = xmlSerializer.Deserialize(xmlReader);
                }
            }
            return obj;
        }
    }
}