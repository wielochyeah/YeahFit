using System;
using System.Collections.Generic;

namespace YeahFit
{
	public class Workout
	{
        // General
        public string RecipeName { get; set; }
        public string RecipeInfo { get; set; }

        // Categories
        public bool breakfast { get; set; }
        public bool lunch { get; set; }
        public bool dinner { get; set; }
        public bool dessert { get; set; }
        public bool snacks { get; set; }
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool drinks { get; set; }
        public int duration { get; set; }

        // ID
        public int id { get; set; }

        // Difficulty
        public string difficulty { get; set; }

        // Liked
        public bool liked { get; set; }

        // Steps
        //internal List<Step> Steps { get; set; }

        // Ingredients
        //internal List<Ingredient> Ingredients { get; set; }

        // Image
        public byte[] RecipeImage;
    }
}

