// Made by Benjamin Espenschied
// V1.1

using System;

namespace myProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dont close the program");
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
