using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication24.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryType { get; set; }
        public string AuthorName { get; set; }
        public string PublicationName { get; set; }
        public string ISBN { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

