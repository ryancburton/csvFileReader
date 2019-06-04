using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using csvFileReader.Database;
using csvFileReader.Processing;

namespace csvFileReader.Model
{
    class ContactSummaryRepository
    { 
        //private List<ImportTask> importTasks;
        private List<Database.ContactSummary> contactSummaryDB;
        private List<ContactSummary> contactSummary;        

        public ContactSummaryRepository()
        {
            contactSummary = new List<ContactSummary>();
            LoadContactSummaryFromDb();
        }
        
        public List<ContactSummary> FindAll()
        {
            foreach(var item in contactSummaryDB)
            {
                ContactSummary contactSummaryItem = new ContactSummary(item);
                contactSummary.Add(contactSummaryItem);
            }
            return contactSummary;
        }

        public ContactSummary FindSelected(int contactSummaryId)
        {
            ContactSummary contactSummary = FindAll().Where(contact => contact.ContactSummaryId == contactSummaryId).FirstOrDefault();    
            return contactSummary;
        }

        public ContactSummary OpenFileToImport()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "d:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            DialogResult result = openFileDialog.ShowDialog();
            ContactSummary contactSummary = new ContactSummary();

            //To Do Make sure excel file not opened
            if (result == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                {
                    contactSummary.ImportedFile = openFileDialog.FileName;
                    FileConsumption fileprocessing = new FileConsumption(contactSummary);
                }
            }
            contactSummary.ImportedFile = openFileDialog.FileName;
            return contactSummary;
        }

        private void LoadContactSummaryFromDb()
        {
            DataService omService = new DataService();
            contactSummaryDB = omService.GetContactSummary();
        }
    }
}