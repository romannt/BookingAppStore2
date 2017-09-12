using BookingAppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingAppStore2.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            var books = db.Books;
            return View(books);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            db.Books.Add(book); // INSERT
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /*
        // Удаление с помощью глагола Get небезопастно
        public ActionResult Delete(int id)
        {
            // Ищем объект Book по id
            Book b = db.Books.Find(id);
            // Если найдено
            if (b != null )
            {
                // Удаляем
                db.Books.Remove(b);
                // Сохраняем изменения
                db.SaveChanges();
            }
            // Более оптимальный способ удаления (за 1 запрос)
            // Создаём объект Book в котором установлено только свойство Id
            // Book b = new Book { Id = id };
            // Помечаем состояние этого объекта как Deleted
            // db.Entry(b).State = EntityState.Deleted;
            // Сохраняем изменения
            // db.SaveChanges();
            return RedirectToAction("Index");
        }
        */

        [HttpGet]
        public ActionResult Delete(int id)
        {
            // Получаем удаляемый объект и передаём его в представление Delete
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        // С помощью атрибута ActionName указываем, что этот метод относится к действию Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b); // DELETE
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Методы с представлениями, сгенерированными автоматически

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            db.Books.Add(book); // INSERT
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified; // UPDATE
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}