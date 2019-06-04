using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using csvFileReader.Database;
using System.Threading.Tasks;
using Akka.Actor;

namespace csvFileReader.Processing
{
    public class FileProcessing : ReceiveActor
    {
        private Dictionary<string, int> columns = new Dictionary<string, int>()
        {{"Name", -1}, {"Company", -1}, {"Email", -1}, {"Phone", -1}};

        public FileProcessing()
        {
            Receive<string>(async fileName =>
            {
                ContactSummary contactSummary = new ContactSummary();
                try
                {
                    string filePath = fileName.Replace('%', '\\');
                    var reader = ReadAsLines(filePath);
                    Stopwatch countdown = new Stopwatch();
                    countdown.Start();                    

                    //this assumes the first record is filled with the column names
                    List<string> headers = reader.First().Split(',').ToList();
                    int colPosition = 0;

					//Dynamically determine Column locations
                    foreach (string column in headers)
                    {
						if (columns.ContainsKey(column))
						{
							columns[column] = colPosition;
						}
                        colPosition++;
                    }

                    var records = reader.Skip(1);
                    List<ContactDetail> contactDetailList = new List<ContactDetail>();

                    foreach (var record in records)
                    {
                        List<string> rowData = record.Split(',').ToList();
                        ContactDetail contactDetails = new ContactDetail();

                        contactDetails.Name = columns["Name"] != -1 ? rowData.ElementAt(columns["Name"]) : "";
                        contactDetails.Company = columns["Company"] != -1 ? rowData.ElementAt(columns["Company"]) : "";
                        contactDetails.Email = columns["Email"] != -1 ? rowData.ElementAt(columns["Email"]) : "";
                        contactDetails.Phone = columns["Phone"] != -1 ? rowData.ElementAt(columns["Phone"]) : "";
                        contactDetailList.Add(contactDetails);

                        records = reader.Skip(1);
                    }

                    countdown.Stop();
                    
                    contactSummary.ImportFileName = filePath.Substring(filePath.LastIndexOf("\\") + 1, filePath.Length - (filePath.LastIndexOf("\\")+1));
                    contactSummary.ImportDate = DateTime.Now.ToString("dd/mm/yy").ToString();
                    contactSummary.ImportDuration = countdown.Elapsed.Seconds.ToString() + " seconds";
                    contactSummary.ContactsImported = contactDetailList.Where(x => !string.IsNullOrEmpty(x.Name)).Count();                    
                    contactSummary.CompaniesImported = contactDetailList.Where(x => !string.IsNullOrEmpty(x.Company)).Count();
                    contactSummary.LackedEmail = contactDetailList.Where(x => string.IsNullOrEmpty(x.Email)).Count();
                    contactSummary.LackedPhone = contactDetailList.Where(x => string.IsNullOrEmpty(x.Phone)).Count();

                    DataService ds = new DataService();
                    int contactSummaryId = ds.SaveContactSummary(contactSummary);
                    ds.SaveContactDetail(contactDetailList, contactSummaryId);
                }
                catch (Exception ex)
                {
                    Sender.Tell(string.Format("Error occured: {0} ", ex.Message), Self);
                }
                Sender.Tell("Imported", Self);
            });
    }

    static IEnumerable<string> ReadAsLines(string filename)
        {
			using (StreamReader reader = new StreamReader(filename))
			{
				while (!reader.EndOfStream)
				{
					yield return reader.ReadLine();
				}
			}
        }
    }

    public class FileConsumption
    {
        public FileConsumption(Model.ContactSummary contactSummary)
        {
            var system = ActorSystem.Create("FileProcessing");
            var fileProcess = system.ActorOf<FileProcessing>();

            Task.Run(async () =>
            {
                var task = fileProcess.Ask(contactSummary.ImportedFile.Replace('\\', '%'));
                await Task.WhenAll(task);

                contactSummary.TimeToImport = task.Result.ToString();
            });
        }
    }
}
