

// Made by Benjamin Espenschied
// V1.2

using System;

namespace myProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Dont close the program");
            string keepGoing = "yes";
            
            // Set up dice
            Dice redDice = new Dice(6);
            Dice yellowDice = new Dice(6);
            Dice greenDice = new Dice(6);
            Dice blueDice = new Dice(6);
            
            // Introductions
            Console.WriteLine("Hello! My name is Josh. I help work the Quixx dice. If \nYou want to roll the dice, just press enter. Typing \nin a dice color or no, then it will disable that \ndice or stop the program. Go ahead! Give it a shot!");
            
            // Main loop
            while (keepGoing != "no") 
            {
                keepGoing = Console.ReadLine();
                switch(keepGoing) 
                {
                    case "red":
                        if (redDice.status == "active"){
                            redDice.status = "disabled";
                            Console.WriteLine("Red has been Disabled!");
                        } else {
                            redDice.status = "active";
                            Console.WriteLine("Red has been Activated!");
                        };
                        break;
                    case "yellow":
                        yellowDice.status = "disabled";
                        Console.WriteLine("Yellow has been Disabled!");
                        break;
                    case "greem":
                        greenDice.status = "disabled";
                        Console.WriteLine("Green has been Disabled!");
                        break;
                    case "blue":
                        blueDice.status = "disabled";
                        Console.WriteLine("Blue has been Disabled!");
                        break;
                    case "no":
                        Console.WriteLine("Well, I will go now.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
    
    class Dice
    {
        public int roll;
        public int sides;
        public int[] results = new int[2];
        public string status;
        public Random numGen = new Random();
        
        public Dice(int _sides)
        {
            roll = 0;
            status = "active";
            sides = _sides;
        }
        
        public int rollDie()
        {
            roll = numGen.Next(1, sides + 1);
            return roll;
        }
    }
}
