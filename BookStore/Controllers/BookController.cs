using BookStore.App_Start;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using BookStore.Models;
using MongoDB.Driver;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
       
        MongoContext db;
        public IMongoCollection<Book> BookCollection;
        
        public BookController()
        {
            
            db = new MongoContext();
            BookCollection=db.database.GetCollection<Book>("book");
        }
        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = BookCollection.AsQueryable<Book>().ToList();

            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
           Book  book= BookCollection.AsQueryable<Book>().SingleOrDefault(x=>x.Id==id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase Image)
        {

            List<Book> books = BookCollection.AsQueryable<Book>().ToList();
            if(books.Count>=1)
                book.Id =books.Last().Id+1;
            else
                book.Id =1;


            try
            {
                if (Image.FileName != null) {

                    string Imgname = book.Id.ToString() + "." + Image.FileName.Split('.')[1];
                    Image.SaveAs(Server.MapPath("~/Content/assets/images/") + Imgname);
                    book.Img = Imgname;

                    ViewData["imgfound"] = Image;
                    
                    BookCollection.InsertOne(book);
                   
                }
                else
                {

                    ViewData["imgfound"] = Image;
                    
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = BookCollection.AsQueryable<Book>().SingleOrDefault(x => x.Id == id);

            
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book newbook, HttpPostedFileBase Image)
        {
            try
            {
                Book oldbook = BookCollection.AsQueryable<Book>().SingleOrDefault(x => x.Id == id);
                var book = Builders<Book>.Filter.Eq("_id", id);
                string Imgname = "";
                if (Image != null)
                {
                    
                     Imgname = newbook.Id.ToString() + "." + Image.FileName.Split('.')[1];
                    Image.SaveAs(Server.MapPath("~/Content/assets/images/") + Imgname);
                    newbook.Img = Imgname;
                }
                else
                {
                        newbook.Img = Image != null ? Imgname : oldbook.Img;
                }
                // TODO: Add update logic here
                
                
            
                BookCollection.ReplaceOneAsync(book, newbook);
    
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = BookCollection.AsQueryable<Book>().SingleOrDefault(x => x.Id == id);
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Book b)
        {
            try
            {
                var book = Builders<Book>.Filter.Eq(e => e.Id, id);


                BookCollection.DeleteOneAsync(book);
                List<Book> books = BookCollection.AsQueryable<Book>().ToList();
                
               
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
