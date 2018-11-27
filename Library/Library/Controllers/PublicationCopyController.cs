using Library.App_Start;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class PublicationCopyController : Controller
    {

        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT * From PublicationCopy";
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
            return View(new PublicationCopy());
        }


        [HttpPost]
        public ActionResult Create(PublicationCopy publicationCopy)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

      

            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            PublicationCopy publicationCopy = new PublicationCopy();

            

            if (dataTable.Rows.Count == 1)
            {
               
                return View(publicationCopy);
            }

            else
            {
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public ActionResult Edit(PublicationCopy publicationCopy)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


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
