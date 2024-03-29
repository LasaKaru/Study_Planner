using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Study_Planner.Pages
{
    /// <summary>
    /// Interaction logic for StudyPlansPage.xaml
    /// </summary>
    public partial class StudyPlansPage : Page
    {

        // Define a collection to store study sessions
        private ObservableCollection<StudySession> studySessions = new ObservableCollection<StudySession>();
        public StudyPlansPage()
        {
            InitializeComponent();
        }

        private void AddStudySession_Click(object sender, RoutedEventArgs e)
        {
            // Open a dialog window for users to input session details
            AddStudySessionDialog dialog = new AddStudySessionDialog();

            // Pass study plan name and goal/objectives to the dialog
            string studyPlanName = txtStudyPlanName.Text;
            string goal = txtGoal.Text;

            if (dialog.ShowDialog() == true)
            {
                // If the user confirms the input, add the session to the collection
                StudySession newSession = dialog.GetStudySession(studyPlanName, goal);
                studySessions.Add(newSession);
            }
        }
    }

    internal class StudySession
    {
        // Properties to represent the details of a study session
        public string Subject { get; set; }
        public string Topic { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
        public string StudyPlanName { get; internal set; }
        public string Goal { get; internal set; }
    }

    internal class AddStudySessionDialog
    {
        // Method to display the dialog window and retrieve the entered study session details
        internal StudySession GetStudySession(string studyPlanName, string goal)
        {
            // For simplicity, let's assume we're just creating a new study session with default values
            // You can modify this method to display a dialog window for users to input session details
            return new StudySession { StudyPlanName = studyPlanName, Goal = goal };
        }

        internal StudySession GetStudySession()
        {
            throw new NotImplementedException();
        }

        // Method to show the dialog window
        internal bool ShowDialog()
        {
            // For simplicity, let's assume the dialog is always shown successfully
            return true;
        }
    }
}
