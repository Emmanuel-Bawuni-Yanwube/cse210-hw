using System;

class Program
{
    /*
     * Eternal Quest - Gamified Goal Tracker
     * -------------------------------------
     * Base Requirements:
     * - Supports Simple, Eternal, and Checklist Goals
     * - Tracks score, saves & loads goals
     * - Uses inheritance, encapsulation, and polymorphism
     * 
     * Exceeding Requirements:
     * - Added Level System (Levels & Titles)
     * - Added Badge Achievements
     * - Fun console messages for engagement
     */

    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
