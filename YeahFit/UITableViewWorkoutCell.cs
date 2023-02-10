// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace YeahFit
{
    public partial class UITableViewWorkoutCell : UITableViewCell
    {
            bool liked;

            /// <summary>
            /// Custom cell in the FirtView for the individual recipes
            /// </summary>
            /// <param name="handle"></param>
            public UITableViewWorkoutCell (IntPtr handle) : base(handle)
            {
            }
            
            /// <summary>
            /// Update each cell content
            /// </summary>
            /// <param name="selectedRecipe"></param>
            /// <param name="indexPath"></param>
            internal void UpdateCell(Workout selectedWorkout, int indexPath)
            {
                // Set recipe text
                imageView_LikeWorkout.Image = UIImage.GetSystemImage("heart.fill");
                lbl_WorkoutName.Text = selectedWorkout.RecipeName;
                lbl_WorkoutCategory.Text = "";

                
                //
                // Categories
                //

                // Category: Breakfast
                if (selectedWorkout.breakfast == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Frühstück";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Frühstück";
                    }
                }

                // Category: Lunch
                if (selectedWorkout.lunch == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Mittagessen";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Mittagessen";
                    }
                }

                // Category: Dinner
                if (selectedWorkout.dinner == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Abendessen";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Abendessen";
                    }
                }

                // Category: Dessert
                if (selectedWorkout.dessert == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Dessert";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Dessert";
                    }
                }

                // Category: Snacks
                if (selectedWorkout.snacks == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Snack";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Snack";
                    }
                }

                // Category: Drinks
                if (selectedWorkout.drinks == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Getränk";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Getränk";
                    }
                }

                // Category: Vegetarian
                if (selectedWorkout.vegetarian == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Vegetarisch";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Vegetarisch";
                    }
                }

                // Category: Vegan
                if (selectedWorkout.vegan == true)
                {
                    // If there were categories set before
                    if (lbl_WorkoutCategory.Text != "")
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = lbl_WorkoutCategory.Text + ", Vegan";
                    }
                    else
                    {
                        // Set category text
                        lbl_WorkoutCategory.Text = "Vegan";
                    }
                }

                // If no category was selected
                if (
                    selectedWorkout.breakfast == false &&
                    selectedWorkout.lunch == false &&
                    selectedWorkout.dinner == false &&
                    selectedWorkout.dessert == false &&
                    selectedWorkout.snacks == false &&
                    selectedWorkout.vegetarian == false &&
                    selectedWorkout.vegan == false &&
                    selectedWorkout.drinks == false
                    )
                // Set category text
                {
                    lbl_WorkoutCategory.Text = "Keine Kategorie ausgewählt";
                }


                //
                // Difficulties
                //

                // Difficulty beginner
                if (selectedWorkout.difficulty == "beginner")
                {
                    // Set difficulty text
                    lbl_difficulty.Text = "Anfänger";
                }

                // Difficulty advanced
                else if (selectedWorkout.difficulty == "advanced")
                {
                    // Set difficulty text
                    lbl_difficulty.Text = "Fortgeschritten";
                }

                // Difficulty professional
                else if (selectedWorkout.difficulty == "professional")
                {
                    // Set difficulty text
                    lbl_difficulty.Text = "Profi";
                }


                //
                // Duration
                //

                // Convert duration from int (seconds)  to TimeSpan
                TimeSpan duration = TimeSpan.FromSeconds(selectedWorkout.duration);

                // Set Duration as string
                lbl_duration.Text = duration.ToString(@"hh\:mm");


                //
                // Liked
                //

                // Set liked
                liked = selectedWorkout.liked;
                if (liked == false)
                {
                    liked = false;

                    // Set image View with the normal heart
                    imageView_LikeWorkout.Image = UIImage.GetSystemImage("heart");
                }
                else if (liked == true)
                {
                    // Set image View with the filled heart
                    imageView_LikeWorkout.Image = UIImage.GetSystemImage("heart.fill");
                }


                //
                // Recipe image
                //

                // Get recipe image from byte array
                var data = NSData.FromArray(selectedWorkout.RecipeImage);

                // Convert to UIImage
                UIImage image = UIImage.LoadFromData(data);

                // Set as image
                imageView_Workout.Image = image;

                // AspectFill
                imageView_Workout.ContentMode = UIViewContentMode.ScaleAspectFill;
                
            }
        }
    }