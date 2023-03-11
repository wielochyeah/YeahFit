using System;
using System.Collections.Generic;

namespace YeahFit
{
	public class Challenge
	{
        // General
        public string ChallengeName { get; set; }

        // Workouts
        internal List<Workout> Workouts { get; set; }

        // ID
        public int id { get; set; }

        // ID
        public int daysPerWeek { get; set; }

        // Difficulty
        public string difficulty { get; set; }

        // Liked
        public bool liked { get; set; }

        // Image
        public byte[] ChallengeImage;
    }
}

