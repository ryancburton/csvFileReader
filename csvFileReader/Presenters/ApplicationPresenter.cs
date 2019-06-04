using System;
using System.Collections.ObjectModel;
using csvFileReader.Model;

namespace csvFileReader.Presenters
{
    class ApplicationPresenter : PresenterBase<MainWindow>
    {
        private readonly ContactSummaryRepository _contactSummaryRepository;
        private static ObservableCollection<ContactSummary> _contactSummary;
        private static int _selectedContactSummaryId;

        public ApplicationPresenter(MainWindow view, ContactSummaryRepository contactSummaryRepository) : base(view)
        {
            _contactSummaryRepository = contactSummaryRepository;            
            _contactSummary = new ObservableCollection<ContactSummary>(_contactSummaryRepository.FindAll());
        }

        public ObservableCollection<ContactSummary> ContactSummary
        {
            get { return _contactSummary; }
            set
            {
                _contactSummary = value;
                OnPropertyChanged("ContactSummary");
            }
        }

        public static int SelectedContactSummaryId
        {
            get { return _selectedContactSummaryId; }
            set
            {
                _selectedContactSummaryId = value;
            }
        }

        public void OpenFileToImport()
        {
            _contactSummary.Add(_contactSummaryRepository.OpenFileToImport());
        }

        public ContactSummaryRepository ContactSummaryRepository
        {
            get { return _contactSummaryRepository; }            
        }
    }
}