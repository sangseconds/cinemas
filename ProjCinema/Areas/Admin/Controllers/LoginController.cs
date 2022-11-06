
using ProjCinema.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjCinema.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel model)
        {
            //var result = new AccountModel().Login(model.AdminName, model.Password);
            var data = db.ADMIN_ACCOUNT.Where(s => s.AdminName.Equals(model.AdminName) && s.AdminPassword.Equals(model.Password)).ToList();
            if (ModelState.IsValid && data.Count() > 0)
            {
                Session["AdminID"] = (model.AdminName).ToString();
                var x = db.Database.SqlQuery<String>($"exec getRole '{model.AdminName}'").FirstOrDefault();
                Session["Role"] = x;
                //JSON.stringify(Session["Role"]);
                return RedirectToAction("Homepage", "Admin");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session["AdminID"] = null;
            return RedirectToAction("Index", "Admin/Login");
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}