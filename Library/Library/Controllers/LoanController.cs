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
    public class LoanController : Controller
    {

        public ActionResult Index()
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);


            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Loan";
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
            return View(new Loan());
        }


        [HttpPost]
        public ActionResult Create(Loan loan)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "INSERT INTO Loan (LibMember,Name) values (@LibMember,@Name)";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@LibMember", loan);
            sqlcommand.Parameters.AddWithValue("@Name", loan.Memberp);
            sqlcommand.ExecuteNonQuery();
            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Edit(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);

            DataTable dataTable = new DataTable();
            Loan loan = new Loan();

            sqlConnection.Open();
            string sqlQuery = "SELECT * FROM Loan WHERE LibMember = @LibMember";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, sqlConnection);
            sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@LibMember", id);
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                loan.Memberp = (Member)dataTable.Rows[0][0];
               
                return View(loan);
            }

            else
            {
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public ActionResult Edit(Loan loan)
        {

            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "UPDATE Loan SET LibMember =@LibMember, Name=@Name";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@LIbMember", loan.Memberp);
            sqlcommand.Parameters.AddWithValue("@Name", loan.Memberp);
            sqlcommand.ExecuteNonQuery();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            DbConnection dbConnection = DbConnection.GetDbConnectionInstance();
            SqlConnection sqlConnection = new SqlConnection(dbConnection.ConnectionString);
            sqlConnection.Open();
            string sqlquery = "DELETE FROM Loan WHERE LIbMember =@LIbMember";
            SqlCommand sqlcommand = new SqlCommand(sqlquery, sqlConnection);
            sqlcommand.Parameters.AddWithValue("@LIbMember", id);
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
