using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjCinema.Models;
namespace ProjCinema.Areas.Admin.Controllers
{
    public class MovieAdminController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/Movie
        public ActionResult MovieAdmin()
        {
            var ID = (Session["Role"]).ToString();
            if (ID == "2" || ID == "1")
            {
                ViewBag.name = Session["AdminID"];
                ViewBag.dangchieu = db.Database.SqlQuery<MOVIE>("exec GetCurrentFilm").ToList();
                ViewBag.sapchieu = db.Database.SqlQuery<MOVIE>("exec GetFutureFilm").ToList();
                ViewBag.phim = db.Database.SqlQuery<MovieItem>("exec GetMovieInfo").ToList();
                //ViewBag.suatchieu = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
                return View();
            }
            else

                return RedirectToAction("Homepage", "Admin");
        }
        public ActionResult AddMovieView()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddMovieAdmin()
        {

            string movieName = Request.Form["movie-name"];
            string moviedirector = Request.Form["movie-director"];
            string movieactor = Request.Form["movie-actor"];
            string movienation = Request.Form["movie-nation"];
            string movielength = Request.Form["movie-length"];
            string moviestatus = Request.Form["movie-status"];


            string MovieID = db.Database.SqlQuery<String>("exec GetMaxMovieID").ToList()[0];
            MOVIE mv = new MOVIE();
            mv.MovieID = "MV";
            for (int i = 1; i <= (MovieID.Length - (Int32.Parse(MovieID.Substring(2, MovieID.Length - 2))).ToString().Length) - 2; i++)
            {
                mv.MovieID += "0";
            }
            mv.MovieID = mv.MovieID + (Int32.Parse(MovieID.Substring(2, MovieID.Length - 2)) + 1).ToString();
            mv.MovieName = movieName;
            mv.Director = moviedirector;
            mv.Actor = movieactor;
            mv.MovieLength = Byte.Parse(movielength);
            mv.MovieStatus = Byte.Parse(moviestatus);
            db.MOVIEs.Add(mv);
            db.SaveChanges();
            return RedirectToAction("/MovieAdmin");
        }
        public ActionResult EditMovieView(string movieId)
        {

            ViewBag.movie = db.MOVIEs.Find(movieId);
            ViewBag.movieId = movieId;
            return View();
        }

        public ActionResult EditMovieAdmin(string movieId)
        {
            string movieName = Request.Form["movie-name"];
            string moviedirector = Request.Form["movie-director"];
            string movieactor = Request.Form["movie-actor"];
            string moviecategory = Request.Form["movie-category"];
            string movielength = Request.Form["movie-length"];
            Byte moviestatus = Convert.ToByte(Request.Form["movie-status"]);
            MOVIE mv = db.MOVIEs.Find(movieId);
            mv.MovieName = movieName;
            mv.Director = moviedirector;
            mv.Actor = movieactor;
            mv.Category = moviecategory;
            mv.MovieLength = Byte.Parse(movielength);
            mv.MovieStatus = moviestatus;
            db.SaveChanges();
            return RedirectToAction("/MovieAdmin");
        }
        public ActionResult DeleteMovieAdmin(string movieId)
        {
            MOVIE mv = db.MOVIEs.Find(movieId);
            db.MOVIEs.Remove(mv);
            db.SaveChanges();
            return RedirectToAction("/MovieAdmin");
        }
    }
}