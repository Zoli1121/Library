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
    public class PublicationController : Controller
    {

        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();

            string sqlQuery = "SELECT * FROM Publication";

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
            return View(new Publication());
        }


        [HttpPost]
        public ActionResult Create(Publication publication)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();

            string sqlquery = "INSERT INTO Publication (ISBN,Title,Authors,PublicationDate,Categories,PageNumber,Remark) values (@ISBN,@Title,@Authors,@PublicationDate,@Categories,@PageNumber,@Remark)";

            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);

            sqlcommand.Parameters.AddWithValue("@ISBN", publication.ISBN);
            sqlcommand.Parameters.AddWithValue("@Title", publication.Title);
            sqlcommand.Parameters.AddWithValue("@Authors", publication.Authors);
            sqlcommand.Parameters.AddWithValue("@PublicationDate", publication.PublicationDate);
            sqlcommand.Parameters.AddWithValue("@Categories", publication.Categories);
            sqlcommand.Parameters.AddWithValue("@PageNumber", publication.PageNumber);
            sqlcommand.Parameters.AddWithValue("@Remark", publication.Remark);


            sqlcommand.ExecuteNonQuery();
            return RedirectToAction("Index");
        }


      
       


        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            Publication publication = new Publication();

            sqlConnection.Open();

            string sqlQuery = "SELECT * FROM Publication WHERE ISBN = @ISBN";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);

            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@ISBN", id);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Title", publication.Title);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Authors", publication.Authors);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@PublicationDate", publication.PublicationDate);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Categories", publication.Categories);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@PageNumber", publication.PageNumber);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Remark", publication.Remark);

            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                publication.ISBN = dataTable.Rows[0][0].ToString();
                publication.Title = dataTable.Rows[0][1].ToString();
                publication.Authors = (List<Author>) dataTable.Rows[0][2]  ;
                publication.PublicationDate = (int)dataTable.Rows[0][3];
                publication.Categories = (List<PublicationCategory>)dataTable.Rows[0][4];
                publication.PageNumber = (int)dataTable.Rows[0][5];
                publication.Remark = dataTable.Rows[0][6].ToString();

                return View(publication);
            }

            else
            {
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public ActionResult Edit(Publication publication)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();

            string sqlquery = "UPDATE Publication SET ISBN =@ISBN, Title=@Title ,Authors=@Authors,PublicationDate=@PublicationDate,Categories=@Categories,PageNumber=@PageNumber,Remark=@Remark ";

            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);

            sqlcommand.Parameters.AddWithValue("@ISBN", publication.ISBN);
            sqlcommand.Parameters.AddWithValue("@Title", publication.Title);
            sqlcommand.Parameters.AddWithValue("@Authors", publication.Authors);
            sqlcommand.Parameters.AddWithValue("@PublicationDate", publication.PublicationDate);
            sqlcommand.Parameters.AddWithValue("@Categories", publication.Categories);
            sqlcommand.Parameters.AddWithValue("@PageNumber", publication.PageNumber);
            sqlcommand.Parameters.AddWithValue("@Remark", publication.Remark);


            sqlcommand.ExecuteNonQuery();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();

            string sqlquery = "DELETE FROM Publication WHERE ISBN =@ISBN";

            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@ISBN", id);
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
