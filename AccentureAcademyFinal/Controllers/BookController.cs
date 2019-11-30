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
            BookStoreEntities db = new BookStoreEntities();
            return View(db.Book.ToList());
        }

        public ActionResult Eliminar(int id)
        {
            Book book = this.db.Book.Find(id);
            this.db.Book.Remove(book);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Editar(int id)
        {
            Book m = this.db.Book.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Book book,Author author,IEnumerable<int> genre,Publisher publisher)
        {

            foreach (int item in genre)
            {
                Genre genreReferencia = new Genre();
                genreReferencia = db.Genre.Find(item);
                book.Genre.Add(genreReferencia);
            }

            book.Author.Add(author);
            book.Publisher.Add(publisher);
            

            this.db.Book.Attach(book);
            this.db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }


    }
}