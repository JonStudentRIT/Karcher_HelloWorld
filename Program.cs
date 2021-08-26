using System;
using System.Threading;

namespace Karcher_HelloWorld
{
    /* IGME 206 Hello World Assignment 
     * Author: Jonathan Karcher
     * Purpose: Initial exploration of the differences between java and C#
     * Restrictions: None
     */
    class HelloWorld
    {
        /* Method: Main
         * Purpose: Initiate the Main Menu and main menu loop.
         *          Contains stored data for use within the menu options.
         *          Initiates any functions selected by the user.
         *          Contains the only exit Condition.
         *          Restrictions: none
         */
        static void Main(string[] args)
        {
            // This variable holds the user name input from "Greeting()".
            string nameIn ="";
            // This variable holds the user text input that is verified as acceptable.
            string choiceIn = "";
            // Initiates the first Greeting to set "nameIn".
            bool firstCycle = true;
            // This variable is parsed from "choiceIn" variable for use in the main program loop and decision of function to run.
            int choice = 0;
            // Run inital greeting and store the user name in "nameIn".
            nameIn = Greeting(nameIn, 0);
            // Main program loop, the exit condition is int of 4.
            while (choice != 4)
            {
                if (firstCycle)
                {
                    // Formal introduction, greeting, and choice list is displayed.
                    // User can not exit this function without valid input.
                    choiceIn = Greeting(nameIn, 1);
                    firstCycle = false;
                }
                else
                {
                    // Informal greeting and choice list is displayed.
                    // User can not exit this function without valid input.
                    choiceIn = Greeting(nameIn, 3);
                }
                // The choice is parsed from "choiceIn".
                choice = Int32.Parse(choiceIn);
                // Run the function represented by the "choice" variable
                switch (choice)
                {
                    case 1:
                        {
                            RandomizeMyName(nameIn);
                            break;
                        }
                    case 2:
                        {
                            FibonacciMadness(nameIn);
                            break;
                        }
                    case 3:
                        {
                            SimpleEncryption(nameIn);
                            break;
                        }
                    case 4:
                        {
                            // Exit condition
                            Console.WriteLine("Good Bye");
                            Thread.Sleep(500);
                            break;
                        }
                    default:
                        {
                            // catch all condition, inform the user of an error
                            Console.WriteLine("There was an unexpected Error");
                            // force an apropriate method for the program to close
                            choice = 4;
                            Thread.Sleep(500);
                            break;
                        }
                }
            }
        }
        /* Method: Greeting
         * Purpose: This method will Greet the user.
         *          This method collects the user name for storage in the "Main" method.
         *          Displays options for use to the user and verifys the option is acceptable, if it is not the user if informed and the options loop.
         *          Collects the verifyed user choice for use in the "Main" method.
         * Restrictions: None         
         */
        static string Greeting(string output, int cycle)
        {
            // The test number to attempt to parse, -1 is unused
            int sToNumParse = -1;
            // Cycle 0 sets the user name
            if(cycle == 0)
            {
                //Initial Greeting
                output = "";
                string Greeting = "Hello and Welcome!\nWho do I have the pleasure of meating?\n";
                // Output the text in a more user friendly manner.
                FancyOutput(Greeting);
                // Set the output to the text comming in from the console.
                output = Console.ReadLine();

            }
            // Cycle 1 checks for bad user input.
            else if(cycle == 1)
            {
                //Initial Options
                // Exit condition for "Bad Input Loop" is false.
                bool repeteForBadInput = false;
                string Greeting = "Its nice to meet you " + output + ".\n";
                string Greeting2 = "What can I do for you today?\n1) Randomize My Name\n2) Fibunaccie Madness\n3) Simple Encryption of my name\n4) Exit\n";
                FancyOutput(Greeting);
                FancyOutput(Greeting2);
                // Output is reset to new user input.
                output = Console.ReadLine();
                // Test to see if the user input a number, if not set verification test to begin looping.
                if (Int32.TryParse(output, out sToNumParse))
                {
                    // Test to see if the user input a number between 1 and 4, if not set verification test to begin looping.
                    if (!(sToNumParse <= 4 && sToNumParse >= 1))
                    {
                        repeteForBadInput = true;
                    }
                    //everthing looks good if we reach this point
                    /*
                     * any additional input before a verified coice method is called but after the name is connected here
                     */
                }
                // This is called if the user did not input an int.
                else
                {
                    repeteForBadInput = true;
                }
                //Bad Input Loop
                // If the user input bad input then loop through the bad entery notification.
                while(repeteForBadInput)
                {
                    //User is informed of incorrect input.
                    Console.WriteLine("\n\nError Wrong input\n\n");
                    FancyOutput(Greeting2);
                    // Output is reset to new user input.
                    output = Console.ReadLine();
                    // Test to see if the user input a number, if not set verification test to begin looping.
                    if (Int32.TryParse(output, out sToNumParse))
                    {
                        // Test to see if the user input a number between 1 and 4, if not set verification test to begin looping.
                        if (sToNumParse <= 4 && sToNumParse >= 1)
                        {
                            repeteForBadInput = false;
                        }
                    }
                    // This is called if the user did not input an int.
                    else
                    {
                        repeteForBadInput = true;
                    }
                }
            }
            else if (cycle == 3)
            {
                //Display options for non first cycle of options.
                string Greeting = "Are there any other functions you would like to see?\n1) Randomize My Name\n2) Fibunaccie Madness\n3) Simple Encryption of my name\n4) Exit\n";
                FancyOutput(Greeting);
                // Output is reset to new user input.
                output = Console.ReadLine();
            }
            // Output information processed depending on what cycle is beeing processed.
            return output;
        }
        /* Method: FibonacciMadness
         * Purpose: After converting each letter of the user name to their ASCII Decmal values they are added to represent the upper limit of a fibonacci series.
         *          The method then generates a fibonacci series up to but not past the upper limit.
         * Restrictions: None         
         */
        static void FibonacciMadness(string name)
        {
            // Fibunacci variables
            int firstNumber = 0;
            int secondNumber = 1;
            int placeHolder = 0;
            int nameNumber = 0;
            // Find the ASCII Decmal values of the characters in the users.
            for (int i = 0; i < name.Length; i++)
            {
                // Add the users ASCII Decmal values.
                nameNumber += Convert.ToInt32(name[i]);
            }
            // Initialize the Fibunacci sequence.
            Console.Write(firstNumber + " " + secondNumber + " ");
            placeHolder = firstNumber + secondNumber;
            // Run the Fibunacci sequence untill the value is greater than the value in "nameNumber".
            while (secondNumber < nameNumber)
            {
                Console.Write(placeHolder + " ");
                firstNumber = secondNumber;
                secondNumber = placeHolder;
                placeHolder = firstNumber + secondNumber;
            }
            FancyOutput("\nThank you for visiting.\n\n");
        }
        /* Method: RandomizeMyName
         * Purpose: Using the name stored in the "Main" method for the length, a new randomized string of the same length is then displayed.
         *          Note: the user name stored in "Main" method is not effected in any way by the method
         * Restrictions: None         
         */
        static void RandomizeMyName(string name)
        {
            // Create a new random.
            Random rand = new Random();
            string randGreeting = "Your Randomized name is ";
            FancyOutput(randGreeting);
            // For the length of the users name.
            for (int i = 0; i < name.Length; i++)
            {
                // Get a random int value that can represent a printable character.
                // Convert it to a char.
                // Display this character to the user.
                Console.Write(Convert.ToChar(Convert.ToInt32(rand.Next(32, 127))));
            }
            FancyOutput("\nThank you for visiting.\n\n");
        }
        /* Method: SimpleEncryption
         * Purpose: Using a simple encryption system of plus 5 to the ASCII Decmal value of each letter in the user name in the "Main" method,
         *          an encrypted and decrypted verson of their name is displayed
         *          Note: the user name stored in "Main" method is not effected in any way by the method
         * Restrictions: None         
         */
        static void SimpleEncryption(string name)
        {
            // Key for the encryption.
            // Note: Value of key is arbitrary.
            int key = 5;
            string encrypt = "";
            string decrypt = "";
            //encrypt
            FancyOutput("Your name Encrypted is: ");
            // Go throiugh each character in the users name.
            for(int i = 0; i < name.Length; i++)
            {
                // Convert the char at name[i] to an int and add the key.
                int temp = Convert.ToInt32(name[i]) + key;
                // Check to make sure the update only displays prinatable characters.
                if(temp > 126)
                {
                    // If the math check confirms that the char will be printable update.
                    temp -= key;
                }
                // Build the encrypted name to display.
                encrypt = encrypt + Convert.ToString(Convert.ToChar(temp));
            }
            // Display the encrypted name.
            Console.Write(encrypt);
            //decrypt
            FancyOutput("\nYour name Decrypted is: ");
            // Go throiugh each char in the users name.
            for (int i = 0; i < name.Length; i++)
            {
                // Convert the char at encrypted[i] to an int and add the key.
                int temp = Convert.ToInt32(encrypt[i]) - key;
                // Check to make sure the update only displays prinatable characters.
                if (temp < 32)
                {
                    // If the math check confirms that the char will be printable update.
                    temp += key;
                }
                // Build the decrypted name to display.
                decrypt = decrypt + Convert.ToString(Convert.ToChar(temp));
            }
            // Display the decrypted name.
            Console.Write(decrypt);
            FancyOutput("\nThank you for visiting.\n\n");
        }
        /* Method: FancyOutput
         * Purpose: Reduces the speed of any string being displayed to the console.
         * Restrictions: None         
         */
        static void FancyOutput(string s)
        {
            // For the length of the string.
            for (int i = 0; i < s.Length; i++)
            {
                // Pause for a moment. 
                Thread.Sleep(120);
                // Output each char one at a time to the console.
                Console.Write(s[i]);
            }
        }
    }
}
