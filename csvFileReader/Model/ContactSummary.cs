using System;
using csvFileReader.Presenters;

namespace csvFileReader.Model
{
    public class ContactSummary : Notifier
    {
        private int _contactSummaryId;
        private string _importedFile;
        private string _dateImported;
        private string _timeToImport;
        private int _contactsImported;
        private int _companiesImported;
        private int _lackedEmail;
        private int _lackedPhone;

        public ContactSummary(Database.ContactSummary importTask)
        {
            this.ContactSummaryId = importTask.ContactSummaryId;
            this.ImportedFile = importTask.ImportFileName;
            this.DateImported = importTask.ImportDate;
            this.TimeToImport = importTask.ImportDuration;
            this.ContactsImported = importTask.ContactsImported;
            this.CompaniesImported = importTask.CompaniesImported;
            this.LackedEmail = importTask.LackedEmail;
            this.LackedPhone = importTask.LackedPhone;
        }

        public ContactSummary()
        {
            this.DateImported = DateTime.Now.ToString("dd/mm/yy");
            this.TimeToImport = "processing";
            this.ContactSummaryId = 1;            
        }

        public int ContactSummaryId
        {
            get { return _contactSummaryId; }
            set
            {
                _contactSummaryId = value;
                OnPropertyChanged("ContactSummaryId");
            }
        }

        public string ImportedFile
        {
            get { return _importedFile; }
            set
            {
                _importedFile = value;
                OnPropertyChanged("ImportedFile");
            }
        }

        public string DateImported
        {
            get { return _dateImported; }
            set
            {
                _dateImported = value;
                OnPropertyChanged("DateImported");
            }
        }

        public string TimeToImport
        {
            get { return _timeToImport; }
            set
            {
                _timeToImport = value;
                OnPropertyChanged("TimeToImport");
            }
        }

        public int ContactsImported
        {
            get { return _contactsImported; }
            set
            {
                _contactsImported = value;
                OnPropertyChanged("ContactsImported");
            }
        }

        public int CompaniesImported
        {
            get { return _companiesImported; }
            set
            {
                _companiesImported = value;
                OnPropertyChanged("CompaniesImported");
            }
        }

        public int LackedEmail
        {
            get { return _lackedEmail; }
            set
            {
                _lackedEmail = value;
                OnPropertyChanged("LackedEmail");
            }
        }

        public int LackedPhone
        {
            get { return _lackedPhone; }
            set
            {
                _lackedPhone = value;
                OnPropertyChanged("LackedPhone");
            }
        }
    }
}
        