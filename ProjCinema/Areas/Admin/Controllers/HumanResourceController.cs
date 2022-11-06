using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjCinema.Models;
namespace ProjCinema.Areas.Admin.Controllers
{
    public class HumanResourceController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/HumanResource
        public ActionResult HumanResource()
        {
            var ID = (Session["Role"]).ToString();
            //var x = db.Database.SqlQuery<String>($"exec getRole '{Session["Role"]}'").FirstOrDefault().ToString();
            if (ID == "1")
            {
                ViewBag.name = Session["AdminID"];
                var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
                var departments = db.DEPARTMENTs.ToList();
                ViewBag.admins = admins;
                ViewBag.departments = departments;
                return View();
            }
            else
                return RedirectToAction("Homepage", "Admin");
        }
        public ActionResult AddAdminView()
        {
            var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
            var departments = db.DEPARTMENTs.ToList();
            ViewBag.admins = admins;
            ViewBag.departments = departments;
            return View();
        }
        public ActionResult AddAdmin()
        {
            var departments = db.DEPARTMENTs.ToList();
            ViewBag.departments = departments;
            string adminName = Request.Form["admin-name"];
            string adminPassword = Request.Form["admin-password"];
            int adminRole = Convert.ToInt32(Request.Form["role"]);
            var admins = db.Database.SqlQuery<AdminInfo>("exec GetAdminInfo").ToList();
            var max = admins[0].AdminID;
            foreach (var admin in admins)
            {
                if (max < admin.AdminID) max = admin.AdminID;
                if (adminName == admin.AdminName)
                {
                    ViewBag.error = "Tên đăng nhập đã tồn tại";
                    return View("~/Areas/Admin/Views/HumanResource/AddAdminView.cshtml");
                }
            }
            int adminId = max + 1;
            ADMIN_ACCOUNT newAdmin = new ADMIN_ACCOUNT();
            newAdmin.AdminID = adminId;
            newAdmin.AdminName = adminName;
            newAdmin.AdminPassword = adminPassword;
            newAdmin.DepartmentID = adminRole.ToString();
            db.ADMIN_ACCOUNT.Add(newAdmin);
            db.SaveChanges();
            return RedirectToAction("/HumanResource");
        }
        public ActionResult EditAdminView(int adminId)
        {
            var departments = db.DEPARTMENTs.ToList();
            ViewBag.departments = departments;
            ViewBag.admin = db.ADMIN_ACCOUNT.Find(adminId);
            ViewBag.adminId = adminId;
            return View();
        }

        public ActionResult EditAdmin(int adminId)
        {
            int adminRole = Convert.ToInt32(Request.Form["role"]);
            ADMIN_ACCOUNT editedAdmin = db.ADMIN_ACCOUNT.Find(adminId);
            editedAdmin.DepartmentID = adminRole.ToString();
            db.SaveChanges();
            return RedirectToAction("/HumanResource");
        }
        public ActionResult DeleteAdmin(int adminId)
        {
            ADMIN_ACCOUNT deletedAdmin = db.ADMIN_ACCOUNT.Find(adminId);
            db.ADMIN_ACCOUNT.Remove(deletedAdmin);
            db.SaveChanges();
            return RedirectToAction("/HumanResource");
        }
        public ActionResult AddDepartmentView()
        {
            return View();
        }
        public ActionResult AddDepartment()
        {
            var departments = db.DEPARTMENTs.ToList();
            ViewBag.departments = departments;
            string departmentName = Request.Form["department-name"];
            var max = Convert.ToInt32(departments[0].DepartmentID);
            foreach (var department in departments)
            {
                var departmentId = Convert.ToInt32(department.DepartmentID);
                if (max < departmentId) max = departmentId;
                if (departmentName == department.DepartmentName)
                {
                    ViewBag.error = "Tên bộ phận đã tồn tại";
                    return View("~/Areas/Admin/Views/HumanResource/AddDepartmentView.cshtml");
                }
            }
            int newDepartmentId = max + 1;
            DEPARTMENT newDepartment = new DEPARTMENT();
            newDepartment.DepartmentID = newDepartmentId.ToString();
            newDepartment.DepartmentName = departmentName;
            db.DEPARTMENTs.Add(newDepartment);
            db.SaveChanges();
            return RedirectToAction("/HumanResource");
        }
        public ActionResult EditDepartmentView(string departmentId)
        {
            ViewBag.department = db.DEPARTMENTs.Find(departmentId);
            ViewBag.departmentId = departmentId;
            return View();
        }

        public ActionResult EditDepartment(string departmentId)
        {
            string departmentName = Request.Form["department-name"];
            DEPARTMENT editedDepartment = db.DEPARTMENTs.Find(departmentId);
            editedDepartment.DepartmentName = departmentName;
            db.SaveChanges();
            return RedirectToAction("/HumanResource");
        }
        public ActionResult DeleteDepartment(string departmentId)
        {
            DEPARTMENT deletedDepartment = db.DEPARTMENTs.Find(departmentId);
            db.DEPARTMENTs.Remove(deletedDepartment);
            db.SaveChanges();
            return RedirectToAction("/HumanResource");
        }
    }
}