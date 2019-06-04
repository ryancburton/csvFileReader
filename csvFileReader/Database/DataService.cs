using System.Collections.Generic;
using System.Linq;

namespace csvFileReader.Database
{
    public class DataService
    {
        public List<ContactSummary> GetContactSummary()
        {
            using (var entities = new ContactsEntities())
            {
                return entities.ContactSummaries.ToList();                
            }            
        }

        public List<ContactDetail> GetContactDetails(int ContactSummaryId)
        {
            List<ContactDetail> ContactSummary = new List<ContactDetail>();

            using (var entities = new ContactsEntities())
            {
                return entities.ContactDetails.Where(x=> x.ContactSummaryId == ContactSummaryId).ToList();
            }
        }

        public int SaveContactSummary(ContactSummary ContactSummary)
        {
            using (var entities = new ContactsEntities())
            {
                ContactSummary result = entities.ContactSummaries.Add(ContactSummary);
                entities.SaveChanges();

                return result.ContactSummaryId;
            }
        }

        public void SaveContactDetail(List<ContactDetail> ContactDetail, int ContactSummaryId)
        {
            using (var entities = new ContactsEntities())
            {
                foreach (var contactDetail in ContactDetail)
                {
                    ContactDetail dbContactDetail = new Database.ContactDetail();

                    dbContactDetail.Name = contactDetail.Name;
                    dbContactDetail.Company = contactDetail.Company;
                    dbContactDetail.Email = contactDetail.Email;
                    dbContactDetail.Phone = contactDetail.Phone;
                    dbContactDetail.ContactSummaryId = ContactSummaryId;

                    entities.ContactDetails.Add(dbContactDetail);
                }

                entities.SaveChanges();
            }
        }
    }
}
