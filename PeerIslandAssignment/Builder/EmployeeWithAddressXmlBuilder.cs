using PeerIslandAssignment.Interface;
using PeerIslandAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslandAssignment.Builder
{
    /// <summary>The Concrete Builder class for Employees with Address.</summary>
    public class EmployeeWithAddressXmlBuilder : Builder<EmployeeWithAddress>
    {
        private string xmlPath;
        private IXmlHelper xmlHelper;

        public EmployeeWithAddressXmlBuilder(IXmlHelper xmlHelper, string xmlPath)
        {
            this.xmlHelper = xmlHelper;
            this.xmlPath = xmlPath;
        }

        public override IList<EmployeeWithAddress> Read(string rootAttribute)
        {
            return this.xmlHelper.ReadXml<EmployeeWithAddress>(xmlPath, rootAttribute);
        }

        public override bool Write(EmployeeWithAddress employee, string rootAttribute)
        {
            return this.xmlHelper.UpdateXml<EmployeeWithAddress>(xmlPath, rootAttribute, employee);
        }

        public override bool Delete(string nodeName, string NodeValue)
        {
            return this.xmlHelper.DeleteFromXml(nodeName, NodeValue, xmlPath);
        }
    }
}
