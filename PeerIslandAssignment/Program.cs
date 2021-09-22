using Microsoft.Extensions.DependencyInjection;
using PeerIslandAssignment.Builder;
using PeerIslandAssignment.Interface;
using PeerIslandAssignment.Models;
using System;

namespace PeerIslandAssignment
{
    /// <summary>The Program Class.</summary>
    public class Program
    {
        private IUserInterface userInterface;

        private IXmlHelper xmlHelper;
        public Program(IUserInterface userInterface, IXmlHelper xmlHelper)
        {
            this.userInterface = userInterface;
            this.xmlHelper = xmlHelper;
        }

        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ServiceConfiguration.RegisterServices();
            Program program = serviceProvider.GetService<Program>();

            // Base employee read
            program.Run1();

            // Employee with Address -- uncomment the below code
            // program.Run2();

            ServiceConfiguration.DisposeServices(serviceProvider);
        }

        private void Run1()
        {
            // provide local file path to test
            var filePath = "./Xml/employee.xml";
            this.userInterface.ShowStart();

            var option = Convert.ToInt32(Console.ReadLine());
            var isSuccess = false;
            var resultCount = 0;
            var builder = new EmployeeXmlBuilder(this.xmlHelper, filePath);

            switch (option)
            {
                case 1:
                    var result = builder.Read("Employees");
                    resultCount = result.Count;
                    isSuccess = true;
                    break;

                case 2:
                    var data = new Employee { Name = "test", Age = 11, Designation = "tester" };
                    isSuccess = builder.Write(data, "Employees");
                    break;

                case 3:
                    Console.WriteLine("name of the employee to be removed: ");
                    string nodeValue = Console.ReadLine();
                    isSuccess = this.xmlHelper.DeleteFromXml("Name", nodeValue, filePath);
                    break;
                default:
                    break;
            }

            this.userInterface.ShowSummary(option, isSuccess, resultCount);
        }

        private void Run2()
        {
            // provide local file path to test
            var filePath = "./Xml/EmployeeWithAddress.xml";
            this.userInterface.ShowStart();

            var option = Convert.ToInt32(Console.ReadLine());
            var isSuccess = false;
            var resultCount = 0;
            var builder = new EmployeeWithAddressXmlBuilder(this.xmlHelper, filePath);

            switch (option)
            {
                case 1:
                    var result = builder.Read("Employees");
                    resultCount = result.Count;
                    isSuccess = true;
                    break;

                case 2:
                    var address = new Address { DoorNumber = "1", Street = "x", Town = "y", State = "z" };
                    var data = new EmployeeWithAddress { Name = "test", Age = 11, Designation = "tester", Address = address };
                    isSuccess = builder.Write(data, "Employees");
                    break;

                case 3:
                    Console.WriteLine("name of the employee to be removed: ");
                    string nodeValue = Console.ReadLine();
                    isSuccess = this.xmlHelper.DeleteFromXml("Name", nodeValue, filePath);
                    break;
                default:
                    break;
            }

            this.userInterface.ShowSummary(option, isSuccess, resultCount);
        }
    }
}
