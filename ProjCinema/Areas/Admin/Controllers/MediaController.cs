using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjCinema.Models;
namespace ProjCinema.Areas.Admin.Controllers
{
    public class MediaController : Controller
    {
        CinemaDB db = new CinemaDB();
        // GET: Admin/Media
        public ActionResult Media()
        {

            var ID = (Session["Role"]).ToString();
            if (ID == "1" || ID == "3")
            {
                ViewBag.name = Session["AdminID"];
                ViewBag.sobaidang = db.POSTs.ToList();
                ViewBag.soblog = db.Database.SqlQuery<MovieItem>("exec GetAllBlog").ToList();
                ViewBag.sobaibl = db.Database.SqlQuery<MovieItem>("exec GetAllReview").ToList();
                ViewBag.sobaitin = db.Database.SqlQuery<MovieItem>("exec GetAllSale").ToList();
                ViewBag.phanhoi = db.Database.SqlQuery<FeedbackList>("exec GetFeedBack").ToList();/*select fb.FeedbackID, fb.FeedbackContent, us.email from FEEDBACK fb inner join USER_ACCOUNT us on fb.UserID = us.UserID*/
                return View();
            }
            else
                return RedirectToAction("Homepage", "Admin");

        }

        public ActionResult AddPostView()
        {
            ViewBag.admins = db.ADMIN_ACCOUNT.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(POST data)
        {
            /* ViewBag.admins = db.ADMIN_ACCOUNT.ToList();
             string postName = Request.Form["post-name"];
             string postCategory = Request.Form["post-category"];
             string adminId = Request.Form["admin-id"];
             string max = db.Database.SqlQuery<String>("exec GetMaxPostId").ToList()[0];
             int intMax = Int32.Parse(max.Substring(4, max.Length - 4)) + 1;
             string sign = "POST";
             for (int i = 1; i <= (max.Length - (Int32.Parse(max.Substring(4, max.Length - 4))).ToString().Length) - 4; i++)
             {
                 sign += "0";
             }
             string newPostId = sign + intMax.ToString();
             POST newPost = new POST();
             newPost.PostID = newPostId;
             newPost.PostTitle = postName;
             newPost.PostCategory = postCategory;
             newPost.AdminID = Convert.ToInt32(adminId);
             newPost.CreateAt = DateTime.Now.ToLocalTime();
             db.POSTs.Add(newPost);
             db.SaveChanges();
             return RedirectToAction("/Media");*/
            ViewBag.admins = db.ADMIN_ACCOUNT.ToList();
            string postName = Request.Form["post-name"];
            string postCategory = Request.Form["post-category"];
            string adminId = Request.Form["admin-id"];
            string max = db.Database.SqlQuery<String>("exec GetMaxPostId").ToList()[0];
            int intMax = Int32.Parse(max.Substring(4, max.Length - 4)) + 1;
            string sign = "POST";
            for (int i = 1; i <= (max.Length - (Int32.Parse(max.Substring(4, max.Length - 4))).ToString().Length) - 4; i++)
            {
                sign += "0";
            }
            
            string newPostId = sign + intMax.ToString();
            POST newPost = new POST();
            newPost.PostID = newPostId;
            newPost.PostTitle = data.PostTitle;
            newPost.PostCategory = data.PostCategory;
            newPost.AdminID = Convert.ToInt32(adminId);
            newPost.CreateAt = DateTime.Now.ToLocalTime();
            db.POSTs.Add(newPost);
            db.SaveChanges();
            return RedirectToAction("/Media");
        }
        public ActionResult EditPostView(string postId)
        {
            ViewBag.admins = db.ADMIN_ACCOUNT.ToList();
            ViewBag.post = db.POSTs.Find(postId);
            ViewBag.postId = postId;
            return View();
        }

        public ActionResult EditPost(string postId)
        {
            var admins = db.ADMIN_ACCOUNT.ToList();
            ViewBag.admins = admins;
            string postName = Request.Form["post-name"];
            string postCategory = Request.Form["post-category"];
            string adminId = Request.Form["admin-id"];
            POST editedPost = db.POSTs.Find(postId);
            editedPost.PostTitle = postName;
            editedPost.PostCategory = postCategory;
            editedPost.AdminID = Convert.ToInt32(adminId);
            db.SaveChanges();
            return RedirectToAction("/Media");
        }
        public ActionResult DeletePost(string postId)
        {
            POST deletedPost = db.POSTs.Find(postId);
            db.POSTs.Remove(deletedPost);
            db.SaveChanges();
            return RedirectToAction("/Media");
        }
    }
}