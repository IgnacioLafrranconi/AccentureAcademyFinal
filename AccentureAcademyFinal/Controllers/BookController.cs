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
            try
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
            }
            catch
            {
                return View("Error");
            }

            return View();
        }

        public ActionResult Listar()
        {
            BookStoreEntities db = new BookStoreEntities();
            return View(db.Book.ToList());
        }

        public ActionResult ListarCards()
        {
            BookStoreEntities db = new BookStoreEntities();
            return View(db.Book.ToList());
        }

        [HttpPost]
        public ActionResult Listar(ListarViewModel filtros)
        {
            IQueryable<Book> qry = this.db.Book;
            try
            {
                if (filtros.FilterTitle != null)
                {
                    qry = qry.Where(lib => lib.Title.Contains(filtros.FilterTitle));
                }

                if (filtros.FilterGenre.HasValue)
                {
                    qry = qry.Where(lib =>
                        lib.Genre.Any(
                               aut => aut.Id.Equals(filtros.FilterGenre.Value)
                        )
                    );
                }
            }
            catch
            {
                this.ViewBag.Error = "Error vuelva a intentar";
                return View("Error");
            }
            return View(qry.ToList());
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
            try
            {
                book.Author.Add(author);
                book.Publisher.Add(publisher);


                foreach (int item in genre)
                {
                    Genre genreReferencia = new Genre();
                    genreReferencia = db.Genre.Find(item);
                    book.Genre.Add(genreReferencia);
                }

                this.db.Book.Attach(book);
                this.db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                this.db.SaveChanges();
            }
            catch
            {
                this.ViewBag.Error = "Error vuelva a intentar";
                return View("Error");
            }

            return RedirectToAction("Listar");
        }


        public ActionResult AgregarGenero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarGenero(Genre genre)
        {
            try
            {
                db.Genre.Add(genre);
                db.SaveChanges();
            }
            catch
            {
                this.ViewBag.Error = "Error Vuelva a intentar";
                return View("Error");
            }
           return View("Listar");
        }


        public ActionResult Error()
        {
            return View();
        }
    }
}