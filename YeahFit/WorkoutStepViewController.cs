// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Collections;
using System.Drawing;
using System.IO;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using MySql.Data.MySqlClient;
using SDWebImage;
using UIKit;

namespace YeahFit
{
    public partial class WorkoutStepViewController : UIViewController
    {
        public static int index;
        public static Workout selectedWorkout;
        int i = 0;

        MySqlConnection con;

        NSTimer timer;
        int seconds = 0;

        public WorkoutStepViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            con = new MySqlConnection(@"Server=localhost;Database=YeahFit;User Id=root;Password=; CharSet = utf8");
            con.Open();


           // string query = "SELECT ÜbungGif FROM Übung"; //SQL command
            var gifData = new byte[1024];

            /*using (var command = new MySqlCommand(query, con))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        gifData = (byte[])reader["ÜbungGif"];
                    }
                }
            }*/

            gifData = selectedWorkout.Exercises[i].ExerciseImage;

            NSData imageData = NSData.FromArray(gifData);


            var imageView = new FLAnimatedImageView();
            imageView.Frame = new CoreGraphics.CGRect(-200, -60, 850, 850);
            imageView.Frame = new CoreGraphics.CGRect(-200, -60, 850, 850);
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            View.AddSubview(imageView);

            // Load the GIF image from a byte array
            var animatedImage = FLAnimatedImage.AnimatedImageWithGIFData(imageData);

            // Set the animatedImage property of the FLAnimatedImageView
            imageView.AnimatedImage = animatedImage;


            timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(1), delegate
            {
                seconds++;
                int minutes = seconds / 60;
                int remainingSeconds = seconds % 60;
                timerLabel.Text = $"{minutes}:{remainingSeconds:00}";
            });

            lbl_ExerciseName.Text = selectedWorkout.Exercises[i].ExerciseName;
            lbl_SetsReps.Text = selectedWorkout.Exercises[i].ExerciseSets + "x" + selectedWorkout.Exercises[0].ExerciseReps;
            if (selectedWorkout.Exercises[i + 1] != null)
            {
                lbl_NextExercise.Text = "Nächste Übung: " + selectedWorkout.Exercises[0 + 1].ExerciseName;
            }
            else
            {
                lbl_NextExercise.Text = "Letzte Übung";
            }

            btn_NextExercise.TouchUpInside += (sender, e) =>
            {
                i++;
                if (selectedWorkout.Exercises[i + 1] != null)
                {
                    
                    lbl_ExerciseName.Text = selectedWorkout.Exercises[i].ExerciseName;
                    lbl_SetsReps.Text = selectedWorkout.Exercises[i].ExerciseSets + "x" + selectedWorkout.Exercises[i].ExerciseReps;
                    if (selectedWorkout.Exercises[i + 1] != null)
                    {
                        lbl_NextExercise.Text = "Nächste Übung: " + selectedWorkout.Exercises[i + 1].ExerciseName;
                    }
                    else
                    {
                        lbl_NextExercise.Text = "Letzte Übung";
                    }
                    gifData = selectedWorkout.Exercises[i].ExerciseImage;

                    imageData = NSData.FromArray(gifData);


                    imageView = new FLAnimatedImageView();
                    imageView.Frame = new CoreGraphics.CGRect(-200, -60, 850, 850);
                    imageView.Frame = new CoreGraphics.CGRect(-200, -60, 850, 850);
                    imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
                    View.AddSubview(imageView);

                    // Load the GIF image from a byte array
                    animatedImage = FLAnimatedImage.AnimatedImageWithGIFData(imageData);

                    // Set the animatedImage property of the FLAnimatedImageView
                    imageView.AnimatedImage = animatedImage;
                }
                else
                {
                    btn_NextExercise.SetTitle("Workout beenden", UIControlState.Normal);
                }
            };

            btn_Break.TouchUpInside += (sender, e) =>
            {

            };
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            timer.Invalidate();
        }

        void ResetTimer()
        {
            seconds = 0;
            timerLabel.Text = "0:00";
        }
    }
}
