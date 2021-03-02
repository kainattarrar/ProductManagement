using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using KainatDemoProject.Models;

using System.Data;

namespace KainatDemoProject.Controllers

{

    public class LoginController : Controller

    {
        Models.Database_Access dblayer = new Models.Database_Access();

        public ActionResult Index()

        {

            return View();

        }
        

        public ActionResult dashboard()

        {

            //if (Session["user"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");

        }



        public JsonResult userlogin(string userName, string passWord)

        {
            users myUser = new users();
            myUser.username = userName;
            myUser.password = passWord;


            int result = dblayer.userlogin(myUser);



            if (result == 1)

            {

                Session["user"] = myUser.username;
                //redirect function


            }

            else

            {

                result = 0;



            }

            return Json(result, JsonRequestBehavior.AllowGet);

        }









    }

}