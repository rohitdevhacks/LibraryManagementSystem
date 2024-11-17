using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication24.Models
{
    public class BooksContext:DbContext
    {
        public DbSet<Books> tblBooks { get; set; }
    }
}