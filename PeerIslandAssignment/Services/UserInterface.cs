using PeerIslandAssignment.Interface;
using System;

namespace PeerIslandAssignment.Services
{
    /// <summary>The User interface class to implement user interface methods.</summary>
    public class UserInterface : IUserInterface
    {
        public void ShowStart()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Please select an option to continue..........");
            Console.WriteLine("1 - Read");
            Console.WriteLine("2 - Write");
            Console.WriteLine("3 - Delete");
            Console.WriteLine("---------------------------------------------");
        }

        public void ShowSummary(int option, bool isSuccess, int resultCount = 0)
        {
            string message = string.Empty;
            switch (option)
            {
                case 1:
                    if (isSuccess)
                    {
                        message = $"Data read successful. Total Count: {resultCount}";
                    }
                    else
                    {
                        message = "Error while reading the data";
                    }
                    break;

                  case 2:
                    if (isSuccess)
                    {
                        message = $"Data write successful.";
                    }
                    else
                    {
                        message = "Error while writing the data";
                    }
                    break;

                case 3:
                    if (isSuccess)
                    {
                        message = $"Data delete successful.";
                    }
                    else
                    {
                        message = "Error while deleting the data";
                    }
                    break;
                default:
                    message = "Some error occured. Please try again.";
                    break;
            }

            Console.WriteLine(message);
        }

    }
}
