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
    public class MemberController : Controller
    {

        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT CategoryID,Name FROM Member";
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
            return View(new Member());
        }


        [HttpPost]
        public ActionResult Create(Member member)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "INSERT INTO Member (CategoryID,Name) values (@CategoryID,@Name)";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@CategoryID", member.MemberId);
            sqlcommand.Parameters.AddWithValue("@Name", member.Name);
            sqlcommand.ExecuteNonQuery();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            Member member = new Member();

            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Member WHERE CategoryID = @CategoryID";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@CategoryID", id);
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                member.MemberId = (int)dataTable.Rows[0][0];
                member.Name = dataTable.Rows[0][1].ToString();
                return View(member);
            }

            else
            {
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public ActionResult Edit(Member member)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "UPDATE Member SET CategoryID =@CategoryID, Name=@Name";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@CategoryID", member.MemberId);
            sqlcommand.Parameters.AddWithValue("@Name", member.Name);
            sqlcommand.ExecuteNonQuery();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "DELETE FROM Member WHERE CategoryID =@CategoryID";
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
