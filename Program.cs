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
            string mainMenuChoice = "Start";
            string input;
            List<string> mainMenu = new List<string>();
            mainMenu.Add("Stack");
            mainMenu.Add("Queue");
            mainMenu.Add("Dictionary");
            mainMenu.Add("Exit");
            Stack<string> ourStack = new Stack<string>();
            Queue<string> ourQueue = new Queue<string>();
            Dictionary<string, int> ourDictionary = new Dictionary<string, int>();

            Stack<string> tempStack = new Stack<string>();
            Queue<string> tempQueue = new Queue<string>();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            int counter = 1;

            while(mainMenuChoice != "4" )
            {
                mainMenuOutput(mainMenu);
                mainMenuChoice = Console.ReadLine();
                string choice = "Start";
                if (mainMenuChoice == "1")
                {
                    while(choice != "7")
                    {
                        menuOutput("Stack");
                        choice = Console.ReadLine();
                        if(choice == "1")
                        {
                            Console.Write("Enter a string: ");
                            input = Console.ReadLine();
                            ourStack.Push(input);
                        }
                        else if(choice == "2")
                        {
                            ourStack.Clear();
                            for(int i = 1; i <= 2000; i++)
                            {
                                ourStack.Push("New Entry " + i);
                            }
                        }
                        else if(choice == "3")
                        {
                            //Add a error if it's empty
                            foreach(string s in ourStack)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        else if(choice == "4")
                        {
                            Console.Write("Which item would you like to be deleted? ");
                        }
                        else if(choice == "5")
                        {
                            ourStack.Clear();
                        }
                        else if(choice == "6")
                        {
                            Console.Write("Which item would you like to be deleted? ");
                            input = Console.ReadLine();
                            bool found = false;
                            //sw.Start();
                            foreach(string s in ourStack)
                            {
                                if(input == s)
                                {
                                    sw.Stop();
                                    /*TimeSpan ts = sw.Elapsed;

                                    //We're finding this too quickly :(
                                    // Format and display the TimeSpan value.
                                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours, ts.Minutes, ts.Seconds,
                                        ts.Milliseconds / 10);
                                    Console.WriteLine("Found the item in: " + sw.Elapsed.TotalMilliseconds * 1000000);*/
                                    found = true;
                                }
                            }
                            if(found == false)
                            {
                                Console.WriteLine("ITEM NOT FOUND!");
                            }

                        }
                    }
                    
                }
                else if (mainMenuChoice == "2")
                {
                    while (choice != "7")
                    {
                        menuOutput("Queue");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.Write("Enter a string: ");
                            input = Console.ReadLine();
                            ourQueue.Enqueue(input);
                        }
                        else if (choice == "2")
                        {
                            ourQueue.Clear();
                            for (int i = 1; i <= 2000; i++)
                            {
                                ourQueue.Enqueue("New Entry " + i);
                            }
                        }
                        else if (choice == "3")
                        {
                            //Add a error if it's empty
                            foreach (string s in ourQueue)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        else if (choice == "4")
                        {
                            Console.Write("Which item would you like to be deleted? ");
                        }
                        else if (choice == "5")
                        {
                            ourQueue.Clear();
                        }
                        else if (choice == "6")
                        {
                            Console.Write("Which item would you like to be deleted? ");
                            input = Console.ReadLine();
                            bool found = false;
                            //sw.Start();
                            foreach (string s in ourQueue)
                            {
                                if (input == s)
                                {
                                    sw.Stop();
                                    /*TimeSpan ts = sw.Elapsed;

                                    //We're finding this too quickly :(
                                    // Format and display the TimeSpan value.
                                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours, ts.Minutes, ts.Seconds,
                                        ts.Milliseconds / 10);
                                    Console.WriteLine("Found the item in: " + sw.Elapsed.TotalMilliseconds * 1000000);*/
                                    found = true;
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("ITEM NOT FOUND!");
                            }

                        }

                    }

                }
                else if (mainMenuChoice == "3")
                {
                    while (choice != "7")
                    {
                        menuOutput("Dictionary");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            Console.Write("Enter a string: ");
                            input = Console.ReadLine();
                            ourDictionary.Add(input, counter);
                            counter++;
                        }
                        else if (choice == "2")
                        {
                            ourDictionary.Clear();
                            counter = 2001;
                            for (int i = 1; i <= 2000; i++)
                            {
                                ourDictionary.Add("New Entry " + i, i);
                            }
                        }
                        else if (choice == "3")
                        {
                            //Add a error if it's empty
                            foreach (var s in ourDictionary)
                            {
                                Console.WriteLine(s.Key + "\t\t" + s.Value);
                            }
                        }
                        else if (choice == "4")
                        {
                            Console.Write("Which item would you like to be deleted? ");
                        }
                        else if (choice == "5")
                        {
                            ourDictionary.Clear();
                            counter = 0;
                        }
                        else if (choice == "6")
                        {
                            Console.Write("Which item are you seaching for? ");
                            input = Console.ReadLine();
                            bool found = false;
                            //sw.Start();
                            foreach (var s in ourDictionary)
                            {
                                if (input == s.Key)
                                {
                                    sw.Stop();
                                    TimeSpan ts = sw.Elapsed;

                                    //We're finding this too quickly :(
                                    // Format and display the TimeSpan value.
                                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                        ts.Hours, ts.Minutes, ts.Seconds,
                                        ts.Milliseconds / 10);
                                    Console.WriteLine("Found the item in: " + elapsedTime);
                                    found = true;
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("ITEM NOT FOUND!");
                            }

                        }
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
