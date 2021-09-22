using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeerIslandAssignment.Interface;
using PeerIslandAssignment.Models;
using PeerIslandAssignment.Services;

namespace PeerIslandAssignmentTests
{
    [TestClass]
    public class XmlHelperTests
    {
        private IXmlHelper xmlHelper;

        public XmlHelperTests()
        {
            this.xmlHelper = new XmlHelper();
        }

        [TestMethod]
        public void XmlRead_Success()
        {
            // Arrange
            var filePath = @"./TestXml/employee.xml";

            // Act
            var result = this.xmlHelper.ReadXml<Employee>(filePath, "Employees");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void XmlWrite_Success()
        {
            // Arrange
            var filePath = @"./TestXml/testWrite.xml";
            var data = new Employee { Name = "test", Age = 11, Designation = "tester" };

            // Act
            var count = this.xmlHelper.ReadXml<Employee>(filePath, "Employees").Count;
            var result = this.xmlHelper.UpdateXml<Employee>(filePath, "Employees", data);
            var count2 = this.xmlHelper.ReadXml<Employee>(filePath, "Employees").Count;

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(count + 1, count2);
        }

        [TestMethod]
        public void XmlWrite_Fail()
        {
            // Arrange
            var filePath = @"";
            var data = new Employee { Name = "test", Age = 11, Designation = "tester" };

            // Act
            var result = this.xmlHelper.UpdateXml<Employee>(filePath, "Employees", data);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void XmlDelete_Fail()
        {
            // Arrange
            var filePath = @"";

            // Act
            var result = this.xmlHelper.DeleteFromXml("Name", "t", filePath);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void XmlDelete_Pass()
        {
            // Arrange
            var filePath = @"./TestXml/testWrite.xml";
            var data = new Employee { Name = "test", Age = 11, Designation = "tester" };
            this.xmlHelper.UpdateXml<Employee>(filePath, "Employees", data);
            // Act
            var result = this.xmlHelper.DeleteFromXml("Name", "test", filePath);

            // Assert
            Assert.IsTrue(result);
        }

    }
}
