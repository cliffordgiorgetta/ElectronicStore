//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public Payment()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int PaymentsID { get; set; }
        public string ccNumber { get; set; }
        public string cccvc { get; set; }
        public string ccExpireMonth { get; set; }
        public string ccExpireYear { get; set; }
        public string ccName { get; set; }
        public string confirmationNumber { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
