using PeerIslandAssignment.Interface;
using PeerIslandAssignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslandAssignment.Builder
{
    /// <summary>The Concrete Builder class for Employees with Address.</summary>
    public class EmployeeXmlBuilder : Builder<Employee>
    {
        private string xmlPath;
        private IXmlHelper xmlHelper;

        public EmployeeXmlBuilder(IXmlHelper xmlHelper, string xmlPath)
        {
            this.xmlHelper = xmlHelper;
            this.xmlPath = xmlPath;
        }

        public override IList<Employee> Read(string rootAttribute)
        {
            return this.xmlHelper.ReadXml<Employee>(xmlPath, rootAttribute);
        }

        public override bool Write(Employee employee, string rootAttribute)
        {
            return this.xmlHelper.UpdateXml<Employee>(xmlPath, rootAttribute, employee);
        }

        public override bool Delete(string nodeName, string NodeValue)
        {
            return this.xmlHelper.DeleteFromXml(nodeName, NodeValue, xmlPath);
        }
    }
}
