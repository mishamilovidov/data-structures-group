using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_3_Data_Structures
{
    class Program
    {
        static void mainMenuOutput(List<string> s)
        {
            int i = 1;
            foreach(string n in s)
            {
                Console.WriteLine(i + ". " + n);
                i++;
            }
        }

        static void menuOutput(string choice)
        {
            List<string> menuChoices = new List<string>();
            menuChoices.Add("Add one time to " + choice);
            menuChoices.Add("Add Huge List of Items to " + choice);
            menuChoices.Add("Display " + choice);
            menuChoices.Add("Delete from " + choice);
            menuChoices.Add("Clear " + choice);
            menuChoices.Add("Search " + choice);
            menuChoices.Add("Return to Main Menu");

            mainMenuOutput(menuChoices);
        }
        static void Main(string[] args)
        {
            string choice = "Start";
            string mainMenuChoice = "Start";
            List<string> mainMenu = new List<string>();
            mainMenu.Add("Stack");
            mainMenu.Add("Queue");
            mainMenu.Add("Dictionary");
            mainMenu.Add("Exit");

            while(mainMenuChoice != "4" )
            {
                mainMenuOutput(mainMenu);
                mainMenuChoice = Console.ReadLine();
                choice = "Start";
                if (mainMenuChoice == "1")
                {
                    while(choice != "7")
                    {
                        menuOutput("Stack");
                        choice = Console.ReadLine();
                    }
                    
                }
                else if (mainMenuChoice == "2")
                {
                    while (choice != "7")
                    {
                        menuOutput("Queue");
                        choice = Console.ReadLine();
                    }

                }
                else if (mainMenuChoice == "3")
                {
                    while (choice != "7")
                    {
                        menuOutput("Dictionary");
                        choice = Console.ReadLine();
                    }

                }
                else if (mainMenuChoice == "4")
                {
                    Console.WriteLine("Exit");
                }
                else
                {
                    Console.WriteLine("Invalid Input: Insert 1, 2, 3, or 4.");
                }
            }
            Console.Read();
            
        }
    }
}
