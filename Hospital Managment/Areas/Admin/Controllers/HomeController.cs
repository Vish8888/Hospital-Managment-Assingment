using Hospital_Managment.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.Data.SqlClient;
using System.Reflection;

namespace Hospital_Managment.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        #region Globle Connection String
        SqlConnection conn = new SqlConnection("Data Source=VISHAL_CHIMKAR\\SQLEXPRESS;Initial Catalog=\"Hospital Management\";Integrated Security=True");
        #endregion


       
        public IActionResult Index(PatiantModel model)
        {
            List<PatiantModel> list = new List<PatiantModel>();
            string txt = $"Select * from Patiant";
            SqlCommand cmd = new SqlCommand(txt, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    list.Add(new PatiantModel()
                    {
                        Id = (int)reader["id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Email = (string)reader["Email"],
                        Address = (string)reader["Address"],
                        MedicalCondition = (string)reader["MedicalCondition"],
                        Followup = (string)reader["Followup"]
                    });
                }
            }

            conn.Close();
            return View(list);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatiantModel model)
        {
            string txt = $"insert into Patiant values('{model.FirstName}','{model.LastName}','{model.PhoneNumber}'," +
                                   $"'{model.Email}','{model.Address}','{model.MedicalCondition}','{model.Followup}')";
            SqlCommand cmd = new SqlCommand(txt,conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();

            if(count>0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
