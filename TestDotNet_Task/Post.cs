//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestDotNet_Task
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public Post()
        {
            this.Post_to_Category = new HashSet<Post_to_Category>();
        }
    
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public byte[] Created { get; set; }
        public System.DateTime Modified { get; set; }
    
        public virtual ICollection<Post_to_Category> Post_to_Category { get; set; }
        public virtual User User { get; set; }
    }
}
