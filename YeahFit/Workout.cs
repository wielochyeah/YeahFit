using System;
using System.Collections.Generic;

namespace YeahFit
{
	public class Workout
	{
        // Name
        public string WorkoutName { get; set; }

        // Categories
        public bool core { get; set; }
        public bool upperBody { get; set; }
        public bool lowerBody { get; set; }
        public bool fullBody { get; set; }
        public bool push { get; set; }
        public bool pull { get; set; }
        public bool twentyMinutes { get; set; }
        public bool noEquipment { get; set; }

        // Duration
        public int duration { get; set; }

        // ID
        public int day { get; set; }

        // ID
        public int id { get; set; }

        // Difficulty
        public string difficulty { get; set; }

        // Liked
        public bool liked { get; set; }

        // Ingredients
        internal List<Exercise> Exercises { get; set; }

        // Image
        public byte[] WorkoutImage;
    }
}

