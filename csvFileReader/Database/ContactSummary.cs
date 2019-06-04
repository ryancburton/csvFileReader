//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace csvFileReader.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class ContactSummary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactSummary()
        {
            this.ContactDetails = new HashSet<ContactDetail>();
        }
    
        public int ContactSummaryId { get; set; }
        public string ImportFileName { get; set; }
        public string ImportDate { get; set; }
        public string ImportDuration { get; set; }
        public int ContactsImported { get; set; }
        public int CompaniesImported { get; set; }
        public int LackedEmail { get; set; }
        public int LackedPhone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}