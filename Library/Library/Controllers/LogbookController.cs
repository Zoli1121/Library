using Library.App_Start;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Library.Controllers
{
    public class LogbookController : Controller
    {

        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Logbook";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlDataAdapter.Fill(dataTable);
            return View(dataTable);

        }


        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Logbook());
        }


        [HttpPost]
        public ActionResult Create(Logbook logbook)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();


            //code missing yet

            
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            Logbook logbook = new Logbook();

            //code missing yet


            if (dataTable.Rows.Count == 1)
            {
              

                return View(logbook);
            }

            else
            {
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public ActionResult Edit(Logbook logbook)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();

            //code missing yet

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            
            //code missing yet

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
