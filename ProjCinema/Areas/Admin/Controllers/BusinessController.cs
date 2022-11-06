using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjCinema.Models;
namespace ProjCinema.Areas.Admin.Controllers
{
    public class BusinessController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/Business
        public ActionResult Business()
        {
            var ID = (Session["Role"].ToString());
            if (ID == "4" || ID == "1")
            {
                ViewBag.name = Session["AdminID"];
                //ViewBag.total = db.Database.SqlQuery<Int32>("exec GetMoney").ToList()[0];
                ViewBag.payment = db.Database.SqlQuery<int>($"Select Count(BillID) from BILL").ToList()[0];
                ViewBag.ticketType = db.TICKET_TYPE.ToList();
                ViewBag.service = db.SERVICEs.ToList();
                ViewBag.discount = db.DISCOUNT_CODE.ToList();
                ViewBag.room = db.Database.SqlQuery<RoomInfo>($"exec GetRoomInfo").ToList();
                ViewBag.bill = db.BILLs.ToList();
                return View();
            }
            else
                return RedirectToAction("Homepage", "Admin");

        }

        public ActionResult AddTicketTypeView()
        {
            //var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
            //var departments = db.DEPARTMENTs.ToList();
            //ViewBag.admins = admins;
            //ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult AddTicketType()
        {
            string ID = Request.Form["ticket_type1"];
            string name = Request.Form["tickettype_name"];
            string price = Request.Form["tickettype_price"];
            var data = db.TICKET_TYPE.Where(s => s.TicketTypeID.Equals(ID)).ToList();
            if (data.Count() > 0)
            {
                ViewBag.error = "Mã đã đã tồn tại";
                return View("~/Areas/Admin/Views/Business/AddTicketTypeView.cshtml");
            }
            else
            {
                TICKET_TYPE x = new TICKET_TYPE();
                x.TicketTypeID = ID;
                x.TicketTypeName = name;
                x.Price = price;
                db.TICKET_TYPE.Add(x);
                db.SaveChanges();
                return RedirectToAction("/Business");
            }

        }
        [HttpGet]
        public ActionResult EditTicketTypeView(string id)
        {
            //ViewBag.tickettype = db.TICKET_TYPE.ToList();
            ViewBag.ticket = db.TICKET_TYPE.Find(id);
            ViewBag.tickettypeID = id;
            return View();
        }
        [HttpPost]
        public ActionResult EditTicketType(string id)
        {
            string name = Request.Form["tickettype_name"];
            string price = Request.Form["tickettype_price"];
            TICKET_TYPE edit = db.TICKET_TYPE.Find(id);
            edit.TicketTypeName = name;
            edit.Price = price;

            db.SaveChanges();
            return RedirectToAction("/Business");
        }
        public ActionResult DeleteTicketType(string id)
        {
            TICKET_TYPE ticket = db.TICKET_TYPE.Find(id);
            db.TICKET_TYPE.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("/Business");
        }



        public ActionResult AddServiceView()
        {
            //var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
            //var departments = db.DEPARTMENTs.ToList();
            //ViewBag.admins = admins;
            //ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult AddService()
        {
            string ID = Request.Form["serviceID"];
            string name = Request.Form["service_name"];
            string price = Request.Form["service_price"];
            var data = db.SERVICEs.Where(s => s.ServiceID.Equals(ID)).ToList();
            if (data.Count() > 0)
            {
                ViewBag.error = "Mã đã đã tồn tại";
                return View("~/Areas/Admin/Views/Business/AddServiceView.cshtml");
            }
            else
            {
                SERVICE x = new SERVICE();
                x.ServiceID = ID;
                x.ServiceName = name;
                x.ServicePrice = price;
                db.SERVICEs.Add(x);
                db.SaveChanges();
                return RedirectToAction("/Business");
            }

        }
        [HttpGet]
        public ActionResult EditServiceView(string id)
        {
            //ViewBag.tickettype = db.SERVICEs.ToList();
            ViewBag.service = db.SERVICEs.Find(id);
            ViewBag.ServiceID = id;
            return View();
        }
        [HttpPost]
        public ActionResult EditService(string id)
        {
            string name = Request.Form["service_name"];
            string price = Request.Form["service_price"];
            SERVICE edit = db.SERVICEs.Find(id);
            edit.ServiceName = name;
            edit.ServicePrice = price;

            db.SaveChanges();
            return RedirectToAction("/Business");
        }
        public ActionResult DeleteService(string id)
        {
            SERVICE service = db.SERVICEs.Find(id);
            db.SERVICEs.Remove(service);
            db.SaveChanges();
            return RedirectToAction("/Business");
        }

        public ActionResult AddDiscountView()
        {
            //var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
            //var departments = db.DEPARTMENTs.ToList();
            //ViewBag.admins = admins;
            //ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        public ActionResult AddDiscount()
        {
            string ID = Request.Form["discount_ID"];
            string t = Request.Form["discount_t"];
            string stt = Request.Form["discount_stt"];
            var data = db.DISCOUNT_CODE.Where(s => s.CodeID.Equals(ID)).ToList();
            if (data.Count() > 0)
            {
                ViewBag.error = "Mã đã đã tồn tại";
                return View("~/Areas/Admin/Views/Business/AddDiscountView.cshtml");
            }
            else
            {
                DISCOUNT_CODE x = new DISCOUNT_CODE();
                x.CodeID = ID;
                x.DiscountNumber = Int32.Parse(t);
                x.State = Int32.Parse(stt);
                db.DISCOUNT_CODE.Add(x);
                db.SaveChanges();
                return RedirectToAction("/Business");
            }

        }
        [HttpGet]
        public ActionResult EditDiscountView(string id)
        {
            ViewBag.discountTotal = db.DISCOUNT_CODE.ToList();
            ViewBag.discount = db.DISCOUNT_CODE.Find(id);
            ViewBag.DiscountID = id;
            return View();
        }
        [HttpPost]
        public ActionResult EditDiscount(string id)
        {
            string t = Request.Form["discount_t"];
            string stt = Request.Form["discount_stt"];
            DISCOUNT_CODE edit = db.DISCOUNT_CODE.Find(id);
            if (edit.State == 1)
            {
                return RedirectToAction("EditDiscountView");
            }
            edit.DiscountNumber = Int32.Parse(t);
            edit.State = Int32.Parse(stt);
            db.SaveChanges();
            return RedirectToAction("/Business");
        }
        public ActionResult DeleteDiscount(string id)
        {
            DISCOUNT_CODE discount = db.DISCOUNT_CODE.Find(id);
            db.DISCOUNT_CODE.Remove(discount);
            db.SaveChanges();
            return RedirectToAction("/Business");
        }

    }
}