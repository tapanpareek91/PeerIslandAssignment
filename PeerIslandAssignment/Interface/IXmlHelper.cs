using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslandAssignment.Interface
{
    public interface IXmlHelper
    {
        IList<T> ReadXml<T>(string filePath, string rootAttribute);

        bool UpdateXml<T>(string filePath, string rootAttribute, T data);

        bool DeleteFromXml(string nodeName, string NodeValue, string filePath);
    }
}
