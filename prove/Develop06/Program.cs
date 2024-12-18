//For Creativity, i added a title naming system based on the amount of goals completed for each type of goal
//To do this i had to create new member variables in the GoalManager Class as well as new methods
//to get the player's title and to handle the display of the user's score alongside the title 
//achieved by virtue of completing certain number of goals for each goal type

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}