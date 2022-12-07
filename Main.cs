// Made by Benjamin Espenschied
// V1.8

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
            Dice[] allDice = new Dice[6];
            int forwardLength = 2;
            allDice[0] = new Dice(6, "f", "red");
            allDice[1] = new Dice(6, "f", "yellow");
            int backwardLength = 2;
            allDice[2] = new Dice(6, "b", "green");
            allDice[3] = new Dice(6, "b", "blue");
            int whiteLength = 2;
            allDice[4] = new Dice(6, "f", "1st white");
            allDice[5] = new Dice(6, "f", "2nd white");
            
            while (keepGoing != "no")
            {
                keepGoing = Console.ReadLine();
                switch(keepGoing) 
                {
                    case "red":
                        if (allDice[0].status == "active"){
                            allDice[0].status = "disabled";
                            Console.WriteLine("Red has been Disabled!");
                        } else {
                            allDice[0].status = "active";
                            Console.WriteLine("Red has been Activated!");
                        };
                        break;
                    case "yellow":
                        if (allDice[1].status == "active"){
                            allDice[1].status = "disabled";
                            Console.WriteLine("Yellow has been Disabled!");
                        } else {
                            allDice[1].status = "active";
                            Console.WriteLine("Yellow has been Activated!");
                        };
                        break;
                    case "green":
                        if (allDice[2].status == "active"){
                            allDice[2].status = "disabled";
                            Console.WriteLine("Green has been Disabled!");
                        } else {
                            allDice[2].status = "active";
                            Console.WriteLine("Green has been Activated!");
                        };
                        break;
                    case "blue":
                        if (allDice[3].status == "active"){
                            allDice[3].status = "disabled";
                            Console.WriteLine("Blue has been Disabled!");
                        } else {
                            allDice[3].status = "active";
                            Console.WriteLine("Blue has been Activated!");
                        };
                        break;
                    case "activate":
                        for (int i = 0; i < allDice.Length; i++)
                        {
                            allDice[i].status = "active";
                        }
                        Console.WriteLine("All are now active");
                        break;
                    case "no":
                        Console.WriteLine("Well, I will go now.");
                        Console.ReadLine();
                        break;
                }
                
                // Roll all
                for (int i = 0; i < allDice.Length; i++)
                {
                    allDice[i].rollDie();
                };
            
                for (int i = 0; i < allDice.Length; i++)
                {
                    allDice[i].comboWhite(allDice[allDice.Length - 2].roll, allDice[allDice.Length - 1].roll);
                };
                
                // Display all stuff
                for (int i = 0; i < allDice.Length; i++)
                {
                   if (allDice[i].status == "active")
                    {
                        if (allDice[i].sortDirection == "f")
                        {
                            Console.WriteLine("Your " + allDice[i].name + " rolls are: " + allDice[i].results[0] + ", " + allDice[i].results[1]);
                        } else if (allDice[i].sortDirection == "b")
                        {
                            Console.WriteLine("Your " + allDice[i].name + " rolls are: " + allDice[i].results[1] + ", " + allDice[i].results[0]);
                        };
                    };
                };
            }
        }
    }
    
    class Dice
    {
        public int roll;
        private int sides;
        public int[] results = new int[2];
        public int[] resultsFlipped = new int[2];
        public string status;
        private Random numGen = new Random();
        public string sortDirection;
        public string name;
        
        public Dice(int _sides, string _sortDirection, string _name)
        {
            roll = 0;
            status = "active";
            sides = _sides;
            sortDirection = _sortDirection;
            name = _name;
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
