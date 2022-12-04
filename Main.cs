// Made by Benjamin Espenschied
// V1.4

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
            Dice redDice = new Dice(6, "f");
            Dice yellowDice = new Dice(6, "f");
            Dice greenDice = new Dice(6, "b");
            Dice blueDice = new Dice(6, "b");
            Dice whiteDice1 = new Dice(6, "f");
            Dice whiteDice2 = new Dice(6, "f");
            
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
                        if (yellowDice.status == "active"){
                            yellowDice.status = "disabled";
                            Console.WriteLine("Yellow has been Disabled!");
                        } else {
                            yellowDice.status = "active";
                            Console.WriteLine("Yellow has been Activated!");
                        };
                        break;
                    case "green":
                        if (greenDice.status == "active"){
                            greenDice.status = "disabled";
                            Console.WriteLine("Green has been Disabled!");
                        } else {
                            greenDice.status = "active";
                            Console.WriteLine("Green has been Activated!");
                        };
                        break;
                    case "blue":
                        if (blueDice.status == "active"){
                            blueDice.status = "disabled";
                            Console.WriteLine("Blue has been Disabled!");
                        } else {
                            blueDice.status = "active";
                            Console.WriteLine("Blue has been Activated!");
                        };
                        break;
                    case "activate":
                        redDice.status = "active";
                        yellowDice.status = "active";
                        greenDice.status = "active";
                        blueDice.status = "active";
                        Console.WriteLine("All are now active")
                    case "no":
                        Console.WriteLine("Well, I will go now.");
                        Console.ReadLine();
                        break;
                }
                
                // Roll!
                redDice.rollDie();
                yellowDice.rollDie();
                greenDice.rollDie();
                blueDice.rollDie();
                whiteDice1.rollDie();
                whiteDice2.rollDie();
                
                redDice.comboWhite(whiteDice1, whiteDice2);
                yellowDice.comboWhite(whiteDice1, whiteDice2);
                greenDice.comboWhite(whiteDice1, whiteDice2);
                blueDice.comboWhite(whiteDice1, whiteDice2);
                whiteDice1.comboWhite(whiteDice2, whiteDice2);
                
                
            }
        }
    }
    
    class Dice
    {
        public int roll;
        public int sides;
        public int[] results = new int[2];
        public int[] resultsFlipped = new int[2];
        public string status;
        public Random numGen = new Random();
        private string sortDirection
        
        public Dice(int _sides, string _sortDirection)
        {
            roll = 0;
            status = "active";
            sides = _sides;
            sortDirection = _sortDirection;
        }
        
        public int rollDie()
        {
            roll = numGen.Next(1, sides + 1);
            return roll;
        }
        
        public void comboWhite(int white1, int white2)
        {
            results[0] = white1 + roll;
            results[1] = white2 + roll;
            Array.Sort(results);
            resultsFlipped[0] = results[1];
            resultsFlipped[1] = results[0];
        }
    }
}
