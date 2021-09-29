//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messengers_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Messengers_tbl()
        {
            this.Information_tbl = new HashSet<Information_tbl>();
            this.Order_tbl = new HashSet<Order_tbl>();
        }
    
        public int Messenger_Id { get; set; }
        public string Messenger_name { get; set; }
        public string Messenger_phone { get; set; }
        public string Messenger_Email { get; set; }
        public string Password { get; set; }
        public int Manager_Id { get; set; }
        public int MaxAmountPackages { get; set; }
        public bool IsAvailable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Information_tbl> Information_tbl { get; set; }
        public virtual Manager_tbl Manager_tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_tbl> Order_tbl { get; set; }
    }
}