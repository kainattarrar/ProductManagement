using KainatDemoProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;


namespace KainatDemoProject.Controllers

{

    public class DashboardController : Controller

    {

        //

        // GET: /Home/

        Access_Products dblayer = new Access_Products();

        // View for Add record

        public ActionResult Index()

        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {
                return View();
            }


        }



        //View for Display record

        //changes
        ///*
        //public ActionResult dashboard()

        //{

        //    return View();

        //}
        //*/
        // View for Update record

        public ActionResult update_data()

        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");

            }
            else
            {
                return View();
            }

        }

        // Display all records

        [HttpGet]
        public JsonResult GetData()

        {

            DataSet ds = dblayer.get_record();

            List<register> listrs = new List<register>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listrs.Add(new register

                {

                    Sr_no = Convert.ToInt32(dr["pID"]),

                    pn = dr["pName"].ToString(),

                    pcat = dr["Category"].ToString(),

                    pprice = float.Parse(dr["Price"].ToString()),

                    pavail = dr["Availability"].ToString(),


                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }


        // Display records by id

        public JsonResult Get_databyid(int id)

        {

            DataSet ds = dblayer.get_recordbyid(id);

            List<register> listrs = new List<register>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listrs.Add(new register

                {

                    Sr_no = Convert.ToInt32(dr["pID"]),

                    pn = dr["pName"].ToString(),

                    pcat = dr["Category"].ToString(),

                    pprice = float.Parse(dr["Price"].ToString()),

                    pavail = dr["Availability"].ToString(),


                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        // Update records
        [HttpPost]
        public JsonResult update_record(register rs)
        {
            string res = string.Empty;
            try
            {
                dblayer.update_record(rs);
                res = "Updated";
              
            }

            catch (Exception)

            {
                res = "it's failed";
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        // Delete record

        public JsonResult delete_record(int id)

        {

            string res = string.Empty;

            try

            {

                dblayer.deletedata(id);

                //   res = "data deleted";

            }

            catch (Exception)

            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

        public JsonResult Add_record(register rs)

        {

            string res = string.Empty;

            try

            {

                dblayer.Add_record(rs);

                res = "Inserted";

            }

            catch (Exception)

            {

                res = "failed here";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

    }

}