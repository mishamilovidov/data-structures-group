﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Group:          2-8
 *  Names:          Andrew Wiser, Greggory Peck, Misha Milovidov, Shaun Quinton
 *  Date:           2016.09.26
 *  GitHub Repo:    https://github.com/mmilovidov/data-structures-group.git
 *  Description:    A console program that performs a variety of functions on three diffrent data structures (queue, stack, and dictionary) based on  input from a user.
 */

namespace HW_3_Data_Structures
{
    class Program
    {
        //Method that displays option numbers
        static void mainMenuOutput(List<string> s)
        {
            int i = 1;
            foreach (string n in s)
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

        //This function checks to make sure an integer is positive
        static int positiveCheck(int teamNumber)
        {
            while (teamNumber < 0)
            {
                string sNumber = Convert.ToString(teamNumber);
                Console.Write("PLEASE ENTER A POSITIVE NUMBER: ");
                sNumber = Console.ReadLine();

                Console.WriteLine();

                teamNumber = numberFormatChecker(sNumber);
            }
            return (teamNumber);
        }

        //This function makes sure that the search option choice is valid
        static string menuChoice(string choice)
        {
            while (choice.ToUpper() != "L" && choice.ToUpper() != "N")
            {
                Console.Write("NOT A VALID INPUT. PLEASE ENTER 'L' OR 'N': ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        //This function makes sure that the input is a valid integer
        static int numberFormatChecker(string numCheck)
        {
            bool intVal = false;
            int teamNumber = 0;
            while (intVal == false)
            {
                try
                {
                    teamNumber = Convert.ToInt32(numCheck);
                    intVal = true;

                }
                catch (FormatException)
                {
                    Console.Write("Please enter an integer: ");
                    numCheck = Console.ReadLine();

                    Console.WriteLine();
                }
            }

            teamNumber = positiveCheck(teamNumber);
            return (teamNumber);
        }

        static void Main(string[] args)
        {
            //Initialize variables
            string mainMenuChoice = "Start";
            string input;
            string sLocation;
            int iLocation;

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
            while (mainMenuChoice != "4")
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
                    while (choice != "7")
                    {
                        Console.WriteLine("STACK SUB MENU");
                        menuOutput("Stack");
                        Console.Write("SELECT AN OPTION: ");
                        choice = Console.ReadLine();
                        Console.WriteLine();

                        //Add an item to the stack
                        if (choice == "1")
                        {



                            Console.Write("ENTER A STRING TO ADD TO THE STACK: ");
                            input = Console.ReadLine();
                            Console.WriteLine();

                            // checks for unique data entry
                            if (ourStack.Count > 0)
                            {
                                bool exitLoop = true;
                                while (exitLoop)
                                {


                                    foreach (string s in ourStack)
                                    {
                                        if (input == s)
                                        {
                                            System.Console.WriteLine();
                                            System.Console.Write("PLEASE ENTER A UNIQUE VALUE: ");
                                            input = Console.ReadLine();


                                        }
                                        else
                                        {
                                            exitLoop = false;
                                        }
                                    }

                                }
                            }
                            System.Console.WriteLine();
                            ourStack.Push(input);
                        }
                        //Add 2000 items to the stack
                        else if (choice == "2")
                        {
                            ourStack.Clear();

                            for (int i = 1; i <= 2000; i++)
                            {
                                ourStack.Push("New Entry " + i);
                            }

                            Console.Write("ADDED 2000 ITEMS TO THE STACK");
                            Console.WriteLine();
                        }
                        //Display all items in the stack
                        else if (choice == "3")
                        {
                            if (ourStack.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DISPLAY BECAUSE THERE'S NOTHING IN THE STACK!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                            {
                                foreach (string s in ourStack)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine();
                            }
                        }
                        //Delete an item in the stack
                        else if (choice == "4")
                        {
                            //Ensures there is at least one item in the stack
                            if (ourStack.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE STACK!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                            {
                                tempStack.Clear();
                                string searchtype;

                                //Determines how the user would like to delete an iteam
                                Console.Write("WOULD YOU LIKE TO SEARCH FOR THE ITEM TO DELETE BY LOCATION OR NAME (L FOR LOCATION, N FOR NAME): ");
                                searchtype = Console.ReadLine();
                                searchtype = menuChoice(searchtype);

                                //Delete an item based on the location
                                if (searchtype.ToUpper() == "L")
                                {
                                    bool exitLoop = false;
                                    int realLocation;
                                    while (exitLoop == false)
                                    {
                                        //Gets the location of the item the user would like to delete
                                        Console.Write("PLEASE ENTER THE LOCATION OF THE ITEM YOU WOULD LIKE TO DELETE: ");
                                        sLocation = Console.ReadLine();
                                        iLocation = numberFormatChecker(sLocation);

                                        //Makes sure that the user does not input a location greater than the size of the stack
                                        if (iLocation > ourStack.Count - 1)
                                        {
                                            Console.WriteLine("NOT A VALID ENTRY. PLEASE ENTER AN INTEGER BETWEEN 0 AND " + (ourStack.Count - 1));
                                        }
                                        else
                                        {
                                            realLocation = iLocation;

                                            //Fill up the temporary stack
                                            for (int i = 0; i < realLocation; i++)
                                            {
                                                tempStack.Push(ourStack.Pop());
                                            }

                                            //Delete the item from the stack
                                            if (ourStack.Count != 0)
                                            {
                                                ourStack.Pop();
                                                for (int i = 0; i < realLocation; i++)
                                                {
                                                    ourStack.Push(tempStack.Pop());
                                                }
                                            }

                                            else
                                            {
                                                for (int i = 0; i < realLocation-1; i++)
                                                {
                                                    ourStack.Push(tempStack.Pop());
                                                }
                                            }
                                            

                                            Console.WriteLine("\nITEM DELETED!\n");
                                            exitLoop = true;
                                        }
                                    }


                                }
                                else
                                {
                                    //Option to delete an item based on the name of the item
                                    bool exitLoop = false;
                                    bool found = false;
                                    int itemLocation = 0;
                                    int realLocation = 0;
                                    tempStack.Clear();
                                    while (exitLoop == false)
                                    {
                                        //Gets the location of the item the user would like to delete
                                        Console.Write("PLEASE ENTER THE NAME OF THE ITEM YOU WOULD LIKE TO DELETE: ");
                                        string itemDelete = Console.ReadLine();

                                        //Searches for the name
                                        foreach (string s in ourStack)
                                        {
                                            if (itemDelete == s)
                                            {
                                                found = true;
                                                exitLoop = true;
                                                realLocation = itemLocation;
                                            }
                                            else
                                            {
                                                itemLocation++;
                                            }
                                        }

                                        //Fills the temporary stack
                                        if (found == true)
                                        {
                                            for (int i = 0; i < realLocation; i++)
                                            {
                                                tempStack.Push(ourStack.Pop());
                                            }

                                            //Removes the item from the stack
                                            ourStack.Pop();

                                            //Refills the stack
                                            for (int i = 0; i < realLocation; i++)
                                            {
                                                ourStack.Push(tempStack.Pop());
                                            }
                                            Console.WriteLine("\nITEM DELETED!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("ITEM NOT FOUND!");
                                        }

                                    }
                                }
                            }
                        }
                        //Clear all items in the stack
                        else if (choice == "5")
                        {
                            ourStack.Clear();

                            Console.Write("THE STACK WAS CLEARED.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        //Search for an item in the stack
                        else if (choice == "6")
                        {

                            if (ourStack.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE STACK!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }

                            else
                            {
                                Console.Write("ENTER SEARCH TERM: ");
                                input = Console.ReadLine();
                                Console.WriteLine();

                                bool found = false;
                                sw.Start();

                                foreach (string s in ourStack)
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



                            // checks for unique data entry
                            if (ourQueue.Count > 0)
                            {
                                bool exitLoop = true;

                                while (exitLoop)
                                {


                                    foreach (string s in ourQueue)
                                    {
                                        if (input == s)
                                        {
                                            System.Console.WriteLine();
                                            System.Console.Write("PLEASE ENTER A UNIQUE VALUE: ");
                                            input = Console.ReadLine();


                                        }
                                        else
                                        {
                                            exitLoop = false;
                                        }
                                    }

                                }
                            }
                            System.Console.WriteLine();
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
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE QUEUE!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                            {
                                foreach (string s in ourQueue)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine();
                            }
                        }
                        //Delete an item in the queue
                        else if (choice == "4")
                        {
                            //Informs the user if there is nothing
                            if (ourQueue.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE QUEUE!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }

                            //Asks the user to see if they would like to delete by name or by location
                            else
                            {
                                tempQueue.Clear();
                                string searchtype;
                                Console.Write("WOULD YOU LIKE TO SEARCH FOR THE ITEM TO DELETE BY LOCATION OR NAME (L FOR LOCATION, N FOR NAME): ");
                                searchtype = Console.ReadLine();
                                searchtype = menuChoice(searchtype);

                                //If the user selects to delete by location
                                if (searchtype.ToUpper() == "L")
                                {
                                    bool exitLoop = false;
                                    int realLocation;
                                    while (exitLoop == false)
                                    {
                                        Console.Write("PLEASE ENTER THE LOCATION OF THE ITEM YOU WOULD LIKE TO DELETE: ");
                                        sLocation = Console.ReadLine();
                                        iLocation = numberFormatChecker(sLocation);

                                        if (iLocation > ourQueue.Count - 1)
                                        {
                                            Console.WriteLine("\nNOT A VALID ENTRY. PLEASE ENTER AN INTEGER BETWEEN 0 AND " + (ourQueue.Count - 1) + "\n");
                                        }
                                        else
                                        {
                                            realLocation = iLocation;
                                            for (int i = 0; i < realLocation; i++)
                                            {
                                                tempQueue.Enqueue(ourQueue.Dequeue());
                                            }
                                            if (ourQueue.Count != 0)
                                            {
                                                ourQueue.Dequeue();
                                                for (int i = 0; i < realLocation; i++)
                                                {
                                                    ourQueue.Enqueue(tempQueue.Dequeue());
                                                }
                                            }
                                            else
                                            {
                                                for (int i = 0; i < realLocation-1; i++)
                                                {
                                                    ourQueue.Enqueue(tempQueue.Dequeue());
                                                }
                                            }
                                            Console.WriteLine("\nITEM DELETED!\n");
                                            exitLoop = true;
                                        }
                                    }


                                }
                                //If user selects to delete by name
                                else
                                {
                                    bool exitLoop = false;
                                    bool found = false;
                                    int itemLocation = 0;
                                    int realLocation = 0;
                                    tempQueue.Clear();
                                    while (exitLoop == false)
                                    {
                                        Console.Write("PLEASE ENTER THE NAME OF THE ITEM YOU WOULD LIKE TO DELETE: ");
                                        string itemDelete = Console.ReadLine();

                                        foreach (string s in ourQueue)
                                        {
                                            if (itemDelete == s)
                                            {
                                                found = true;
                                                exitLoop = true;
                                                realLocation = itemLocation;
                                            }
                                            else
                                            {
                                                itemLocation++;
                                            }
                                        }
                                        if (found == true)
                                        {
                                            for (int i = 0; i < realLocation; i++)
                                            {
                                                tempQueue.Enqueue(ourQueue.Dequeue());
                                            }
                                            ourQueue.Dequeue();
                                            for (int i = 0; i < realLocation; i++)
                                            {
                                                ourQueue.Enqueue(tempQueue.Dequeue());
                                            }
                                            Console.WriteLine("\nITEM DELETED!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nITEM NOT FOUND!\n");
                                        }

                                    }
                                }
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


                            // checks for unique data entry
                            if (ourDictionary.Count > 0)
                            {
                                bool exitLoop = true;

                                while (exitLoop)
                                {


                                    foreach (var s in ourDictionary)
                                    {
                                        if (input == s.Key)
                                        {

                                            System.Console.WriteLine();
                                            System.Console.Write("PLEASE ENTER A UNIQUE VALUE: ");
                                            input = Console.ReadLine();


                                        }
                                        else
                                        {
                                            exitLoop = false;
                                        }
                                    }

                                }
                            }



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
                            else
                            {
                                foreach (var s in ourDictionary)
                                {
                                    Console.WriteLine(s.Key + "\t\t" + s.Value);
                                }
                                Console.WriteLine();
                            }
                        }
                        //Delete an item in the dictionary
                        else if (choice == "4")
                        {
                            string dictionaryKey = "";
                            if (ourDictionary.Count == 0)
                            {
                                Console.Write("THERE'S NOTHING TO DELETE BECAUSE THERE'S NOTHING IN THE DICTIONARY!");
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            else
                            {

                                bool exitLoop = false;
                                while (exitLoop == false)
                                {
                                    Console.Write("ENTER KEY YOU WANT TO DELETE: ");
                                    dictionaryKey = Console.ReadLine();
                                    bool found = false;

                                    foreach (var s in ourDictionary)
                                    {
                                        if (dictionaryKey == s.Key)
                                        {

                                            found = true;

                                            exitLoop = true;

                                            counter--;
                                        }
                                    }
                                    if (found == false)
                                    {
                                        Console.WriteLine("\nKEY NOT FOUND!\n");
                                    }

                                }
                                ourDictionary.Remove(dictionaryKey);
                                Console.WriteLine("\nITEM DELETED!\n");
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