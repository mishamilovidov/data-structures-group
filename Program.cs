using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Group:          2-8
 *  Names:          Andrew Wiser, Greggory Peck, Misha Milovidov, Shaun Quinton
 *  Date:           2016.09.26
 *  GitHub Repo:    https://github.com/mmilovidov/data-structures-group.git
 *  Description:    A console program that performs a variety of functions on three diffrent data structures (queue, stack, and dictionary) based on                     input from a user.
 */

namespace HW_3_Data_Structures
{
    class Program
    {
        //Method that displays option numbers
        static void mainMenuOutput(List<string> s)
        {
            int i = 1;
            foreach(string n in s)
            {
                Console.WriteLine(" " + i + ". " + n);
                i++;
            }
        }

        //Method that displays submenu
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
            //Initialize variables
            string mainMenuChoice = "Start";
            string input;
        
            //Create main menu list and add items
            List<string> mainMenu = new List<string>();
            mainMenu.Add("Stack");
            mainMenu.Add("Queue");
            mainMenu.Add("Dictionary");
            mainMenu.Add("Exit");

            //Create stack, queue, and dictionary objects
            Stack<string> ourStack = new Stack<string>();
            Queue<string> ourQueue = new Queue<string>();
            Dictionary<string, int> ourDictionary = new Dictionary<string, int>();

            //Create temporary stack and queue objects for deleting purposes
            Stack<string> tempStack = new Stack<string>();
            Queue<string> tempQueue = new Queue<string>();

            //Create stopwatch object to clock search time
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            //Initialize counter for dictionary values
            int counter = 1;

            //Display divider to make program more readable
            Console.WriteLine("*****************************************************************");

            //Display main menu until user enters valid input
            while(mainMenuChoice != "4" )
            {
                Console.WriteLine("MAIN MENU");
                mainMenuOutput(mainMenu);
                Console.Write("SELECT AN OPTION: ");
                mainMenuChoice = Console.ReadLine();
                Console.WriteLine();

                //Initialize user choice variable
                string choice = "Start";

                //If user selects Stack
                if (mainMenuChoice == "1")
                {
                    //Display the stack submenu menu until user enters valid input
                    while(choice != "7")
                    {
                        Console.WriteLine("STACK SUB MENU");
                        menuOutput("Stack");
                        Console.Write("SELECT AN OPTION: ");
                        choice = Console.ReadLine();
                        Console.WriteLine();

                        //Add an item to the stack
                        if(choice == "1")
                        {
                            Console.Write("ENTER A STRING TO ADD TO THE STACK: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            ourStack.Push(input);
                        }
                        //Add 2000 items to the stack
                        else if(choice == "2")
                        {
                            ourStack.Clear();

                            for(int i = 1; i <= 2000; i++)
                            {
                                ourStack.Push("New Entry " + i);
                            }

                            Console.Write("ADDED 2000 ITEMS TO THE STACK");
                            Console.WriteLine();
                        }
                        //Display all items in the stack
                        else if(choice == "3")
                        {
                            if (ourStack.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DISPLAY BECAUSE THERE'S NOTHING IN THE STACK!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else {
                                foreach(string s in ourStack)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine();
                            }
                        }
                        //Delete an item in the stack
                        else if(choice == "4")
                        {
                            if (ourStack.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE STACK!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else {
                                Console.Write("ENTER ITEM YOU WANT TO DELETE: ");
                                Console.WriteLine();
                            }
                        }
                        //Clear all items in the stack
                        else if(choice == "5")
                        {
                            ourStack.Clear();

                            Console.Write("THE STACK WAS CLEARED.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        //Search for an item in the stack
                        else if(choice == "6")
                        {
                            Console.Write("ENTER SEARCH TERM: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            bool found = false;
                            sw.Start();

                            foreach(string s in ourStack)
                            {
                                if(input == s)
                                {
                                    sw.Stop();

                                    Console.WriteLine("FOUND ITEM IN " + (sw.Elapsed.TotalMilliseconds) + " MILLISECONDS.");
                                    Console.WriteLine();

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

                //If user selects Queue
                else if (mainMenuChoice == "2")
                {
                    //Display the queue submenu menu until user enters valid input
                    while (choice != "7")
                    {
                        Console.WriteLine("QUEUE SUB MENU");
                        menuOutput("Queue");
                        Console.Write("SELECT AN OPTION: ");
                        choice = Console.ReadLine();
                        Console.WriteLine();

                        //Add and item to the queue
                        if (choice == "1")
                        {
                            Console.Write("ENTER A STRING TO ADD TO THE QUEUE: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            ourQueue.Enqueue(input);
                        }
                        //Add 2000 items to the queue
                        else if (choice == "2")
                        {
                            ourQueue.Clear();

                            for (int i = 1; i <= 2000; i++)
                            {
                                ourQueue.Enqueue("New Entry " + i);
                            }

                            Console.Write("ADDED 2000 ITEMS TO THE QUEUE");
                            Console.WriteLine();
                        }
                        //Display all items in the queue
                        else if (choice == "3")
                        {
                            if (ourQueue.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DISPLAY BECAUSE THERE'S NOTHING IN THE QUEUE!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else {
                                foreach(string s in ourQueue)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine();
                            }
                        }
                        //Delete an item in the queue
                        else if (choice == "4")
                        {
                            if (ourQueue.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE QUEUE!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else {
                                Console.Write("ENTER ITEM YOU WANT TO DELETE: ");
                                Console.WriteLine();
                            }
                        }
                        //Clear all items in the queue
                        else if (choice == "5")
                        {
                            ourQueue.Clear();

                            Console.Write("THE QUEUE WAS CLEARED.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        //Search for an item in the queue
                        else if (choice == "6")
                        {
                            Console.Write("ENTER SEARCH TERM: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            bool found = false;
                            sw.Start();

                            foreach (string s in ourQueue)
                            {
                                if (input == s)
                                {
                                    sw.Stop();

                                    Console.WriteLine("FOUND ITEM IN " + (sw.Elapsed.TotalMilliseconds) + " MILLISECONDS.");
                                    Console.WriteLine();

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

                //If user selects Dictionary
                else if (mainMenuChoice == "3")
                {
                    //Display the dictionary submenu menu until user enters valid input
                    while (choice != "7")
                    {
                        Console.WriteLine("DICTIONARY SUB MENU");
                        menuOutput("Dictionary");
                        Console.Write("SELECT AN OPTION: ");
                        choice = Console.ReadLine();
                        Console.WriteLine();

                        //Add an item to the dictionary
                        if (choice == "1")
                        {
                            Console.Write("ENTER A STRING TO ADD TO THE DICTIONARY: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            ourDictionary.Add(input, counter);

                            counter++;
                        }
                        //Add 2000 items to the dictionary
                        else if (choice == "2")
                        {
                            ourDictionary.Clear();
                            counter = 2001;

                            for (int i = 1; i <= 2000; i++)
                            {
                                ourDictionary.Add("New Entry " + i, i);
                            }

                            Console.Write("ADDED 2000 ITEMS TO THE DICTIONARY");
                            Console.WriteLine();
                        }
                        //Display all items in the dictionary 
                        else if (choice == "3")
                        {
                            if (ourDictionary.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DISPLAY BECAUSE THERE'S NOTHING IN THE DICTIONARY!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else {
                                foreach (var s in ourDictionary)
                                {
                                    Console.WriteLine(s.Key + "\t\t" + s.Value);
                                }
                                Console.WriteLine();
                            }
                        }
                        //Delete and item in the dictionary
                        else if (choice == "4")
                        {
                            if (ourDictionary.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE DICTIONARY!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.Write("ENTER ITEM YOU WANT TO DELETE: ");
                                Console.WriteLine();
                            }
                        }
                        //Clear all items in the dictionary
                        else if (choice == "5")
                        {
                            ourDictionary.Clear();
                            counter = 0;

                            Console.Write("THE DICTIONARY WAS CLEARED.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        //Search for an item in the dictionary
                        else if (choice == "6")
                        {
                            Console.Write("ENTER SEARCH TERM: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            bool found = false;
                            sw.Start();

                            foreach (var s in ourDictionary)
                            {
                                if (input == s.Key)
                                {
                                    sw.Stop();

                                    Console.WriteLine("FOUND ITEM IN " + (sw.Elapsed.TotalMilliseconds) + " MILLISECONDS.");
                                    Console.WriteLine();

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

                //If user selects Exit
                else if (mainMenuChoice == "4")
                {
                    Console.WriteLine("EXITING PROGRAM...");
                    Console.WriteLine();
                }

                //If user input is not valid
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("INVALID INPUT!\nINSERT 1, 2, 3, or 4.");
                    Console.WriteLine();
                }
            }

            Console.Read();
            
        }
    }
}
