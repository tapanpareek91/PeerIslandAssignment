using PeerIslandAssignment.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PeerIslandAssignment.Services
{
    public class XmlHelper : IXmlHelper
    {

        public IList<T> ReadXml<T>(string filePath, string rootAttribute)
        {
            var itemList = new List<T>();

            if(File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootAttribute));
                using (TextReader reader = new StreamReader(filePath))
                {
                    itemList = (List<T>)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            return itemList;
        }

        public bool UpdateXml<T>(string filePath, string rootAttribute, T data)
        {
            try
            {
                var xDoc = new XmlDocument();
                xDoc.Load(filePath);
                var rootNode = xDoc.GetElementsByTagName(rootAttribute)[0];
                var nav = rootNode.CreateNavigator();
                var emptyNamespace = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

                using (var writer = nav.AppendChild())
                {
                    var serializer = new XmlSerializer(data.GetType());
                    writer.WriteWhitespace("");
                    serializer.Serialize(writer, data, emptyNamespace);
                    writer.Close();
                }

                xDoc.Save(filePath);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteFromXml(string nodeName, string NodeValue, string filePath)
        {
            try
            {
                var xDoc = XDocument.Load(filePath);
                var node = xDoc.Descendants(nodeName).Where(x => x.Value == NodeValue).ToList();
                if (node == null)
                {
                    return false;
                }

                node.ForEach(x=>x.Parent.Remove());
                xDoc.Save(filePath);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
