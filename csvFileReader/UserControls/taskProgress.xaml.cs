using System.Windows.Controls;
using csvFileReader.Presenters;
using csvFileReader.Model;

namespace csvFileReader.UserControls
{
    /// <summary>
    /// Interaction logic for taskProgress1.xaml
    /// </summary>
    public partial class taskProgress : UserControl
    {
        public taskProgress()
        {
            InitializeComponent();            
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.Grid grid = (System.Windows.Controls.Grid) sender;
            ContactSummary selectedSummary = (ContactSummary) grid.DataContext;
            ApplicationPresenter.SelectedContactSummaryId = selectedSummary.ContactSummaryId;
        }
    }
}
