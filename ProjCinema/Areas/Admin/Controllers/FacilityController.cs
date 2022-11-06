using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjCinema.Models;
namespace ProjCinema.Areas.Admin.Controllers
{
    public class FacilityController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/Facility
        public ActionResult Facility()
        {
            var ID = (Session["Role"]).ToString();
            if (ID == "1")
            {
                ViewBag.name = Session["AdminID"];
                var locations = db.CINEMA_LOCATION.ToList();
                var cinemas = db.Database.SqlQuery<CinemaInfo>("exec GetCinemaInfo").ToList();
                var rooms = db.Database.SqlQuery<RoomInfo>("exec GetRoomInfo").ToList();
                ViewBag.locations = locations;
                ViewBag.cinemas = cinemas;
                ViewBag.rooms = rooms;
                return View();
            }
            else
                return RedirectToAction("Homepage", "Admin");
        }
        public ActionResult AddCinemaView()
        {
            var locations = db.CINEMA_LOCATION.ToList();
            ViewBag.locations = locations;
            return View();
        }
        public ActionResult AddCinema()
        {
            var locations = db.CINEMA_LOCATION.ToList();
            ViewBag.locations = locations;
            var cinemas = db.CINEMAs.ToList();
            string cinemaName = Request.Form["cinema-name"];
            string locationId = Request.Form["location-id"];
            string cinemaAddress = Request.Form["cinema-address"];
            string cinemaNumber = Request.Form["cinema-number"];
            string max = db.Database.SqlQuery<String>("exec GetMaxCinemaId").ToList()[0];
            int intMax = Int32.Parse(max.Substring(3, max.Length - 3)) + 1;
            string sign = "CNM";
            for (int i = 1; i <= (max.Length - (Int32.Parse(max.Substring(3, max.Length - 3))).ToString().Length) - 3; i++)
            {
                sign += "0";
            }
            string newCinemaId = sign + intMax.ToString();
            foreach (var cinema in cinemas)
            {
                if (cinemaName == cinema.CinemaName)
                {
                    ViewBag.error = "Tên rạp đã tồn tại";
                    return View("~/Areas/Admin/Views/Facility/AddCinemaView.cshtml");
                }
            }
            CINEMA newCinema = new CINEMA();
            newCinema.CinemaID = newCinemaId;
            newCinema.CinemaName = cinemaName;
            newCinema.LocationID = locationId;
            newCinema.CinemaAddress = cinemaAddress;
            newCinema.PhoneNumber = cinemaNumber;
            db.CINEMAs.Add(newCinema);
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult EditCinemaView(string cinemaId)
        {
            var locations = db.CINEMA_LOCATION.ToList();
            ViewBag.locations = locations;
            ViewBag.cinema = db.CINEMAs.Find(cinemaId);
            ViewBag.cinemaId = cinemaId;
            return View();
        }

        public ActionResult EditCinema(string cinemaId)
        {
            var cinemas = db.CINEMAs.ToList();
            string cinemaName = Request.Form["cinema-name"];
            string locationId = Request.Form["location-id"];
            string cinemaAddress = Request.Form["cinema-address"];
            string cinemaNumber = Request.Form["cinema-number"];
            foreach (var cinema in cinemas)
            {
                if (cinemaName == cinema.CinemaName)
                {
                    ViewBag.error = "Tên rạp đã tồn tại";
                    return View("~/Areas/Admin/Views/Facility/EditCinemaView.cshtml");
                }
            }
            ViewBag.error = null;
            CINEMA editedCinema = db.CINEMAs.Find(cinemaId);
            editedCinema.CinemaName = cinemaName;
            editedCinema.LocationID = locationId;
            editedCinema.CinemaAddress = cinemaAddress;
            editedCinema.PhoneNumber = cinemaNumber;
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult DeleteCinema(string cinemaId)
        {
            CINEMA deletedCinema = db.CINEMAs.Find(cinemaId);
            db.CINEMAs.Remove(deletedCinema);
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult AddLocationView()
        {
            var locations = db.CINEMA_LOCATION.ToList();
            ViewBag.locations = locations;
            return View();
        }
        public ActionResult AddLocation()
        {
            var locations = db.CINEMA_LOCATION.ToList();
            ViewBag.locations = locations;
            string locationName = Request.Form["location-name"];
            string max = db.Database.SqlQuery<String>("exec GetMaxLocationId").ToList()[0];
            int intMax = Int32.Parse(max.Substring(2, max.Length - 2)) + 1;
            string sign = "LC";
            for (int i = 1; i <= (max.Length - (Int32.Parse(max.Substring(2, max.Length - 2))).ToString().Length) - 2; i++)
            {
                sign += "0";
            }
            string newLocationId = sign + intMax.ToString();
            foreach (var location in locations)
            {
                if (locationName == location.LocationName)
                {
                    ViewBag.error = "Tên khu vực đã tồn tại";
                    return View("~/Areas/Admin/Views/Facility/AddLocationView.cshtml");
                }
            }
            CINEMA_LOCATION newLocation = new CINEMA_LOCATION();
            newLocation.LocationID = newLocationId;
            newLocation.LocationName = locationName;
            db.CINEMA_LOCATION.Add(newLocation);
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult EditLocationView(string locationId)
        {
            ViewBag.location = db.CINEMA_LOCATION.Find(locationId);
            ViewBag.locationId = locationId;
            return View();
        }

        public ActionResult EditLocation(string locationId)
        {
            var locations = db.CINEMA_LOCATION.ToList();
            ViewBag.locations = locations;
            string locationName = Request.Form["location-name"];
            CINEMA_LOCATION editedLocation = db.CINEMA_LOCATION.Find(locationId);
            editedLocation.LocationName = locationName;
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult DeleteLocation(string locationId)
        {
            CINEMA_LOCATION deletedLocation = db.CINEMA_LOCATION.Find(locationId);
            db.CINEMA_LOCATION.Remove(deletedLocation);
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult AddRoomView()
        {
            var cinemas = db.CINEMAs.ToList();
            ViewBag.cinemas = cinemas;
            return View();
        }
        public ActionResult AddRoom()
        {
            var rooms = db.ROOMs.ToList();
            string roomName = Request.Form["room-name"];
            string cinemaId = Request.Form["cinema-id"];
            string screenType = Request.Form["room-screentype"];
            string max = db.Database.SqlQuery<String>("exec GetMaxRoomId").ToList()[0];
            int intMax = Int32.Parse(max.Substring(1, max.Length - 1)) + 1;
            string sign = "R";
            for (int i = 1; i <= (max.Length - (Int32.Parse(max.Substring(1, max.Length - 1))).ToString().Length) - 1; i++)
            {
                sign += "0";
            }
            string newRoomId = sign + intMax.ToString();
            foreach (var room in rooms)
            {
                if (roomName == room.RoomName && cinemaId == room.CinemaID)
                {
                    ViewBag.error = "Tên phòng đã tồn tại";
                    return View("~/Areas/Admin/Views/Facility/AddRoomView.cshtml");
                }
            }
            ROOM newRoom = new ROOM();
            newRoom.RoomID = newRoomId;
            newRoom.CinemaID = cinemaId;
            newRoom.RoomName = roomName;
            newRoom.ScreenType = screenType;
            db.ROOMs.Add(newRoom);
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult EditRoomView(string roomId)
        {
            var cinemas = db.CINEMAs.ToList();
            ViewBag.cinemas = cinemas;
            ViewBag.room = db.ROOMs.Find(roomId);
            ViewBag.roomId = roomId;
            return View();
        }

        public ActionResult EditRoom(string roomId)
        {
            var rooms = db.ROOMs.ToList();
            string screenType = Request.Form["room-screentype"];
            string roomName = Request.Form["room-name"];
            string cinemaId = Request.Form["cinema-id"];
            ROOM editedRoom = db.ROOMs.Find(roomId);
            editedRoom.RoomName = roomName;
            editedRoom.CinemaID = cinemaId;
            editedRoom.ScreenType = screenType;
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
        public ActionResult DeleteRoom(string roomId)
        {
            ROOM deletedRoom = db.ROOMs.Find(roomId);
            db.ROOMs.Remove(deletedRoom);
            db.SaveChanges();
            return RedirectToAction("/Facility");
        }
    }
}