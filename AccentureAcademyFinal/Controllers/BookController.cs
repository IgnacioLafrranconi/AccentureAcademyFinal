using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccentureAcademyFinal.Models;

namespace AcademyFinal.Controllers
{
    public class BookController : Controller
    {
        private BookStoreEntities db;

        public BookController()
        {
            db = new BookStoreEntities();
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(Book book, Author authors, IEnumerable<int> genres, Publisher publisher)
        {
            foreach (int item in genres)
            {
                Genre genreReferencia = new Genre();
                genreReferencia = db.Genre.Find(item);
                book.Genre.Add(genreReferencia);
            }

            book.Author.Add(authors);
            book.Publisher.Add(publisher);

            this.db.Book.Add(book);
            this.db.SaveChanges();

            return Content("Libro Agregado");
        }

        public ActionResult Listar()
        {
            List<Book> listBook = new List<Book>();
            return View();
        }

    }
}