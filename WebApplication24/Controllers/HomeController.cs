using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication24.Models;

namespace WebApplication24.Controllers
{
    public class HomeController : Controller
    {
        BooksContext db = new BooksContext();
        public ActionResult Index(string searching)
        {
            var books = db.tblBooks.Where(x => (x.Title.Contains(searching) ||x.CategoryType.Contains(searching) ||x.ISBN.Contains(searching) || x.AuthorName.Contains(searching) || searching == null)).ToList();
            return View(books);
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Books b)
        {

            Books book = new Books()
            {
                Title = b.Title,
                CategoryType = b.CategoryType,
                AuthorName = b.AuthorName,
                PublicationName = b.PublicationName,
                ISBN = b.ISBN,
                CreatedBy = b.CreatedBy,
                CreatedDate = b.CreatedDate
            };

            db.tblBooks.Add(book);
            db.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(int Id)
        {
            var book = db.tblBooks.Find(Id);

            var bookedit = new Books()
            {
                Title = book.Title,
                CategoryType = book.CategoryType,
                AuthorName = book.AuthorName,
                PublicationName = book.PublicationName,
                ISBN = book.ISBN,
                CreatedBy = book.CreatedBy,
                CreatedDate = book.CreatedDate
            };
            ViewData["Id"] = book.Id;
            ViewData["Title"] = book.Title;
            ViewData["CategoryType"] = book.CategoryType;
            ViewData["AuthorName"] = book.AuthorName;
            ViewData["PublicationName"] = book.PublicationName;
            ViewData["ISBN"] = book.ISBN;
            ViewData["CreatedBy"] = book.CreatedBy;
            ViewData["CreatedDate"] = book.CreatedDate;
            return View(bookedit);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Books book)
        {
            var bookupdate = db.tblBooks.Find(Id);

            if (!ModelState.IsValid)
            {
                ViewData["Id"] = book.Id;
                ViewData["Title"] = book.Title;
                ViewData["CategoryType"] = book.CategoryType;
                ViewData["AuthorName"] = book.AuthorName;
                ViewData["PublicationName"] = book.PublicationName;
                ViewData["ISBN"] = book.ISBN;
                ViewData["CreatedBy"] = book.CreatedBy;
                ViewData["CreatedDate"] = book.CreatedDate;
                return View(book);
            }

            bookupdate.Id = book.Id;
            bookupdate.Title = book.Title;
            bookupdate.CategoryType = book.CategoryType;
            bookupdate.AuthorName = book.AuthorName;
            bookupdate.PublicationName = book.PublicationName;
            bookupdate.ISBN = book.ISBN;
            bookupdate.CreatedBy = book.CreatedBy;
            bookupdate.CreatedDate = book.CreatedDate;

            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int Id)
        {
            var bookdelete = db.tblBooks.Find(Id);

            db.tblBooks.Remove(bookdelete);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        
    }
}