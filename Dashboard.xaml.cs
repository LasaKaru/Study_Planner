using Study_Planner.Pages;
using System;
using System.Collections.Generic;
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

namespace Study_Planner
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private readonly StudyPlanService _studyPlanService;

        public Dashboard(string username)
        {
            InitializeComponent();
            _studyPlanService = new StudyPlanService();

            // Fetch and display user-specific data
            DisplayUserStudyPlans(username);
            DisplayUserTasks(username);
            // Add logic to visualize progress
        }

        private void DisplayUserStudyPlans(string username)
        {
            // Fetch user-specific study plans from the service
            var studyPlans = _studyPlanService.GetUserStudyPlans(username);

            // Display study plans in the ListBox
            //studyPlansListBox.ItemsSource = (System.Collections.IEnumerable)studyPlans;
        }

        private void DisplayUserTasks(string username)
        {
            // Fetch user-specific tasks from the service
            var tasks = _studyPlanService.GetUserTasks(username);

            // Display tasks in the ListBox
            //tasksListBox.ItemsSource = (System.Collections.IEnumerable)tasks;
        }

        /*private void OpenStudyPlansPage(object sender, RoutedEventArgs e)
        {
            StudyPlansPage studyPlansPage = new StudyPlansPage();
            studyPlansPage.Show();
        }

        // Method to navigate to Study Plans feature page
        private void StudyPlansMenuItem_Click(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new StudyPlansPage());
        }

        private void NavigateToStudyPlans(object sender, RoutedEventArgs e)
        {
            featureFrame.Content = new StudyPlansControl();
        }*/

        // Method to navigate to Study Plans page
        private void OpenStudyPlansPage(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/StudyPlansPage.xaml", UriKind.Relative));
        }

        private void OpenTasksPage(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/TasksPage.xaml", UriKind.Relative));
        }

        private void OpenCalenderPage(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/CalenderPage.xaml", UriKind.Relative));
        }

        private void OpenProgress_Tracking(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Progress_Tracking.xaml", UriKind.Relative));
        }

        private void OpenResource_Management(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Resource_Management.xaml", UriKind.Relative));
        }

        private void OpenNote_Taking(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Note_Taking.xaml", UriKind.Relative));
        }

        private void OpenGoal_Setting(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Goal_Setting.xaml", UriKind.Relative));
        }

        private void OpenCustomization_Options(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Customization_Options.xaml", UriKind.Relative));
        }

        private void OpenSyncing_and_Backup(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Syncing_and_Backup.xaml", UriKind.Relative));
        }

        private void OpenReports_and_Analytics(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Reports_and_Analytics.xaml", UriKind.Relative));
        }

        private void OpenCollaboration(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Collaboration.xaml", UriKind.Relative));
        }

        private void OpenOffline_Access(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Offline_Access.xaml", UriKind.Relative));
        }

        private void OpenAccessibility(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Accessibility.xaml", UriKind.Relative));
        }

        private void OpenLicense_Management(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/License_Management.xaml", UriKind.Relative));
        }

        private void OpenContact_Us(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Contact_Us.xaml", UriKind.Relative));
        }

        private void OpenHelp(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Help.xaml", UriKind.Relative));
        }

        private void OpenSoftware_Updates(object sender, RoutedEventArgs e)
        {
            featureFrame.Navigate(new Uri("Pages/Software_Updates.xaml", UriKind.Relative));
        }

    }

    internal class StudyPlanService
    {
        private readonly Dictionary<string, List<StudyPlan>> _userStudyPlans;
        private readonly Dictionary<string, List<Task>> _userTasks;
        public StudyPlanService()
        {
            _userStudyPlans = new Dictionary<string, List<StudyPlan>>();
            _userTasks = new Dictionary<string, List<Task>>();

            // For demonstration purposes, let's populate some sample data
            PopulateSampleData();
        }

        internal List<StudyPlan> GetUserStudyPlans(string username)
        {
            if (_userStudyPlans.ContainsKey(username))
            {
                return _userStudyPlans[username];
            }
            return new List<StudyPlan>(); // Return an empty list if user doesn't have study plans
        }

        // Method to retrieve user-specific tasks
        internal List<Task> GetUserTasks(string username)
        {
            if (_userTasks.ContainsKey(username))
            {
                return _userTasks[username];
            }
            return new List<Task>(); // Return an empty list if user doesn't have tasks
        }

        // Helper method to populate sample data
        private void PopulateSampleData()
        {
            // Sample study plans for user1
            var user1StudyPlans = new List<StudyPlan>
            {
                new StudyPlan { Id = 1, Name = "Math Study Plan", Subject = "Mathematics", Goal = "Score A in Math exam" },
                new StudyPlan { Id = 2, Name = "Science Study Plan", Subject = "Science", Goal = "Prepare for Science project" }
            };

            _userStudyPlans.Add("user1", user1StudyPlans);

            // Sample tasks for user1
            var user1Tasks = new List<Task>
            {
                new Task { Id = 1, Name = "Complete Chapter 1 exercises", DueDate = DateTime.Now.AddDays(5), Priority = Priority.High },
                new Task { Id = 2, Name = "Read Chapter 2", DueDate = DateTime.Now.AddDays(7), Priority = Priority.Medium }
            };

            _userTasks.Add("user1", user1Tasks);
        }
    }

    // Model class for study plan
    internal class StudyPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Goal { get; set; }
    }

    // Model class for task
    internal class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
    }

    // Enum for task priority
    internal enum Priority
    {
        Low,
        Medium,
        High
    }
}


