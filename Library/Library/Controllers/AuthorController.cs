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
    public class AuthorController : Controller
    {
        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Author";
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
            return View(new Author());
        }


        [HttpPost]
        public ActionResult Create(Author author)
        {
            author.AuthorID = (author.Name).Substring(0, 4);


            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "INSERT INTO Author (AuthorID,Name,Nationality,BirthDate,Birthplace,DeathDate,Remark) values " +
                              "(@AuthorID, @Name, @Nationality, @BirthDate, @Birthplace, @DeathDate, @Remark)";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@AuthorID", author.AuthorID);
            sqlcommand.Parameters.AddWithValue("@Name", author.Name);
            sqlcommand.Parameters.AddWithValue("@Nationality", author.Nationality);
            sqlcommand.Parameters.AddWithValue("@BirthDate", author.BirthDate);
            sqlcommand.Parameters.AddWithValue("@Birthplace", author.Birthplace);
            sqlcommand.Parameters.AddWithValue("@DeathDate", author.DeathDate);
            sqlcommand.Parameters.AddWithValue("@Remark", author.Remark);



            sqlcommand.ExecuteNonQuery();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            Author author = new Author();

            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Author WHERE AuthorID = @AuthorID";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);

            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@AuthorID", id);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Name", author.Name);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Nationality", author.Nationality);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@BirthDate", author.BirthDate);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Birthplace", author.Birthplace);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@DeathDate", author.DeathDate);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Remark", author.Remark);



            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                author.AuthorID = dataTable.Rows[0][0].ToString();
                author.Name = dataTable.Rows[0][1].ToString();
                return View(author);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "UPDATE Author SET AuthorID=@AuthorID, Name=@Name , Nationality=@Nationality ,BirthDate=@BirthDate  , Birthplace=@Birthplace, DeathDate=@DeathDate, Remark=@Remark ";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);

            sqlcommand.Parameters.AddWithValue("@AuthorID", author.AuthorID);
            sqlcommand.Parameters.AddWithValue("@Name", author.Name);
            sqlcommand.Parameters.AddWithValue("@Nationality", author.Nationality);
            sqlcommand.Parameters.AddWithValue("@BirthDate", author.BirthDate);
            sqlcommand.Parameters.AddWithValue("@Birthplace", author.Birthplace);
            sqlcommand.Parameters.AddWithValue("@DeathDate", author.DeathDate);
            sqlcommand.Parameters.AddWithValue("@Remark", author.Remark);

            sqlcommand.ExecuteNonQuery();

            return RedirectToAction("Index");

        }


        public bool AuthorIsNull()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT Authors FROM Publication";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (AuthorIsNull())
            {
                DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
                SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
                sqlConnection.Open();
                string sqlquery = "DELETE FROM Author WHERE AuthorID =@AuthorID";
                SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
                sqlcommand.Parameters.AddWithValue("@AuthorID", id);

                sqlcommand.ExecuteNonQuery();

            }
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
