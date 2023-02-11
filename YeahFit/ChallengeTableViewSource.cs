using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace YeahFit
{
	public class ChallengeTableViewSource : UITableViewSource
	{
        public UINavigationController CurrentNavigationController;
        ChallengeOverviewViewController owner;
        UIViewController parentController;

        List<Challenge> challenges;
        public static Challenge nowSelectedWorkout;
        public static Challenge selectedChallenge;

        public ChallengeTableViewSource(List<Challenge> challenges, UIViewController parentController, UINavigationController CurrentNavigationController)
        {
            this.challenges = challenges;
            this.parentController = parentController;
            this.CurrentNavigationController = CurrentNavigationController;
        }

        /// <summary>
        /// Get the individual recipe
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        /// <returns></returns>
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // Set cells in the TableView
            var cell = (UITableViewChallengeCell)tableView.DequeueReusableCell("cell", indexPath);

            selectedChallenge = challenges[indexPath.Row];

            // Update recipe cell
            cell.UpdateCell(selectedChallenge, indexPath.Row);

            return cell;
        }

        /// <summary>
        /// Count rows
        /// </summary>
        /// <param name="tableview"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return challenges.Count;
        }

        /// <summary>
        /// If user selects a row
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="indexPath"></param>
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Get selected recipe
            nowSelectedWorkout = challenges[indexPath.Row];

            UIStoryboard board = UIStoryboard.FromName("Main", null);

            // Show RecipeView and set index
            ChallengeOverviewViewController ctrl = (ChallengeOverviewViewController)board.InstantiateViewController("ChallengeViewController");
            if (parentController != null)
            {
                parentController.ShowViewController(ctrl, this);

                // Set index
                WorkoutViewController.index = indexPath.Row;
            }
        }
    }
}

