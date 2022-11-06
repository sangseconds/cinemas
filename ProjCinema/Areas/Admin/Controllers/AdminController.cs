using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjCinema.Models;
namespace ProjCinema.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/Admin
        public ActionResult Homepage()
        {
            if (Session["AdminID"] != null)
            {
                ViewBag.name = Session["AdminID"];
                var locations = db.CINEMA_LOCATION.ToList();
                var cinemas = db.Database.SqlQuery<CinemaInfo>("exec GetCinemaInfo").ToList();
                var rooms = db.Database.SqlQuery<RoomInfo>("exec GetRoomInfo").ToList();
                ViewBag.locations = locations;
                ViewBag.cinemas = cinemas;
                ViewBag.rooms = rooms;
                var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
                var departments = db.DEPARTMENTs.ToList();
                ViewBag.admins = admins;
                ViewBag.departments = departments;
                ViewBag.sobaidang = db.POSTs.ToList();
                ViewBag.soblog = db.Database.SqlQuery<MovieItem>("exec GetAllBlog").ToList();
                ViewBag.sobaibl = db.Database.SqlQuery<MovieItem>("exec GetAllReview").ToList();
                ViewBag.sobaitin = db.Database.SqlQuery<MovieItem>("exec GetAllSale").ToList();
                ViewBag.phanhoi = db.Database.SqlQuery<FeedbackList>("exec GetFeedBack").ToList();
                ViewBag.dangchieu = db.Database.SqlQuery<MOVIE>("exec GetCurrentFilm").ToList();
                ViewBag.sapchieu = db.Database.SqlQuery<MOVIE>("exec GetFutureFilm").ToList();
                ViewBag.phim = db.Database.SqlQuery<MovieItem>("exec GetMovieInfo").ToList();
                ViewBag.payment = db.Database.SqlQuery<int>($"Select Count(BillID) from BILL").ToList()[0];
                ViewBag.ticketType = db.TICKET_TYPE.ToList();
                ViewBag.service = db.SERVICEs.ToList();
                ViewBag.discount = db.DISCOUNT_CODE.ToList();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}