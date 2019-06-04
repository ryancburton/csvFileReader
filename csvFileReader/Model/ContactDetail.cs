using System;
using csvFileReader.Presenters;

namespace csvFileReader.Model
{
    public class ContactDetail : Notifier
    {
        private string _name;
        private string _company;
        private string _email;
        private string _phone;        

        ContactDetail() { }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Company
        {
            get { return _company; }
            set
            {
                _company = value;
                OnPropertyChanged("Company");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
    }
}
