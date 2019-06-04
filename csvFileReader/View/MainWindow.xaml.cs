using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using csvFileReader.Presenters;
using csvFileReader.Model;
using csvFileReader.Database;

namespace csvFileReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationPresenter _applicationPresenter = null;

        public MainWindow()
        {
            InitializeComponent();
            ApplicationPresenter applicationPresenter = new ApplicationPresenter(this, new ContactSummaryRepository());
            _applicationPresenter = applicationPresenter;
            importTasks.ItemsSource = applicationPresenter.ContactSummary;			

			if (applicationPresenter.ContactSummary.Count > 0)
            {
                List<KeyValuePair<string, int>> contactValues = new List<KeyValuePair<string, int>>();
                contactValues.Add(new KeyValuePair<string, int>("Contacts Imported", applicationPresenter.ContactSummary[0].ContactsImported));
                contactValues.Add(new KeyValuePair<string, int>("Companies Imported", applicationPresenter.ContactSummary[0].CompaniesImported));
                contactValues.Add(new KeyValuePair<string, int>("Lacked Email", applicationPresenter.ContactSummary[0].LackedEmail));
                contactValues.Add(new KeyValuePair<string, int>("Lacked Phone", applicationPresenter.ContactSummary[0].LackedPhone));

                ImportsAtAGlance.DataContext = applicationPresenter.ContactSummary[0];
                QuickInsight.DataContext = applicationPresenter.ContactSummary[0];
                PieChart.DataContext = contactValues;

                DataService ds = new DataService();
                TableView.DataContext = ds.GetContactDetails(applicationPresenter.ContactSummary[0].ContactSummaryId);
            }
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(taskSummary.Visibility == Visibility.Visible)
            {
                taskSummary.Visibility = Visibility.Hidden;
                taskDetails.Width = 570;
				ImportsAtAGlance.Margin = new Thickness(83, 10, 0, 0);
				QuickInsight.Margin = new Thickness(303, 10, 0, 0);
				image.Source = new BitmapImage(new Uri(@"../../Icons/forwardArrow.png", UriKind.Relative));
			}
			else
            {
                taskSummary.Visibility = Visibility.Visible;
                taskDetails.Width = 440;
				ImportsAtAGlance.Margin = new Thickness(20, 10, 0, 0);
				QuickInsight.Margin = new Thickness(240, 10, 0, 0);
				image.Source = new BitmapImage(new Uri(@"../../Icons/backArrow.png", UriKind.Relative));				
			}
        }

        private void taskStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Model.ContactSummary selectedContactSummary = _applicationPresenter.ContactSummaryRepository.FindSelected(ApplicationPresenter.SelectedContactSummaryId);
            ImportsAtAGlance.DataContext = selectedContactSummary;
            QuickInsight.DataContext = selectedContactSummary;

            List<KeyValuePair<string, int>> contactValues = new List<KeyValuePair<string, int>>();
            contactValues.Add(new KeyValuePair<string, int>("Contacts Imported", selectedContactSummary.ContactsImported));
            contactValues.Add(new KeyValuePair<string, int>("Companies Imported", selectedContactSummary.CompaniesImported));
            contactValues.Add(new KeyValuePair<string, int>("Lacked Email", selectedContactSummary.LackedEmail));
            contactValues.Add(new KeyValuePair<string, int>("Lacked Phone", selectedContactSummary.LackedPhone));
            
            PieChart.DataContext = contactValues;

            DataService ds = new DataService();
            TableView.DataContext = ds.GetContactDetails(selectedContactSummary.ContactSummaryId);
        }

        private void OpenFile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _applicationPresenter.OpenFileToImport();
        }
    }
}
