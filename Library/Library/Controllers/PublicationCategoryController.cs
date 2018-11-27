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
    public class PublicationCategoryController : Controller
    {
        
        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT CategoryID,Name FROM PublicationCategory";
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
            return View(new PublicationCategory());
        }
        
        
        [HttpPost]
        public ActionResult Create(PublicationCategory publicationCategory)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "INSERT INTO PublicationCategory (CategoryID,Name) values (@CategoryID,@Name)";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@CategoryID", publicationCategory.CategoryID);
            sqlcommand.Parameters.AddWithValue("@Name", publicationCategory.Name);
            sqlcommand.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
      

  

        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            PublicationCategory publicationCategory = new PublicationCategory();

            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM PublicationCategory WHERE CategoryID = @CategoryID" ;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@CategoryID", id);
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                publicationCategory.CategoryID = dataTable.Rows[0][0].ToString();
                publicationCategory.Name = dataTable.Rows[0][1].ToString();
                return View(publicationCategory);
            }

            else
            {
                return RedirectToAction("Index");
            }


        }
        
        [HttpPost]
        public ActionResult Edit(PublicationCategory publicationCategory)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "UPDATE PublicationCategory SET CategoryID =@CategoryID, Name=@Name";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@CategoryID", publicationCategory.CategoryID);
            sqlcommand.Parameters.AddWithValue("@Name", publicationCategory.Name);
            sqlcommand.ExecuteNonQuery();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "DELETE FROM PublicationCategory WHERE CategoryID =@CategoryID";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@CategoryID", id);
            sqlcommand.ExecuteNonQuery();
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
