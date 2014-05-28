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
    
    public partial class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }
    
        public int PostID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public System.DateTime date { get; set; }
        public string body { get; set; }
        public Nullable<int> likes { get; set; }
        public Nullable<int> dislikes { get; set; }
        public string image { get; set; }
        public int AuthorID { get; set; }
    
        public virtual Author Author1 { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}