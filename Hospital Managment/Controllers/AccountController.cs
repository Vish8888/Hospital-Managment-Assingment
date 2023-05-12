using Hospital_Managment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Hospital_Managment.Areas.User.Views
{
    public class AccountController : Controller 
    {
        #region Globle Connection String
        SqlConnection conn = new SqlConnection("Data Source=VISHAL_CHIMKAR\\SQLEXPRESS;Initial Catalog=\"Hospital Management\";Integrated Security=True");
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model, IFormCollection form)
          {
            SqlCommand cmd = new SqlCommand("usp_GetLogin", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailId", model.UserName);
            cmd.Parameters.AddWithValue("@Password", model.Password);
            string Name = form["Login".ToString()];

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {


                if (Name == "User")
                {
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
                else if (Name == "Admin")
                {
                    {
                        return RedirectToAction("Index","Home", new { area = "Admin" });
                    }
                }

            }
            conn.Close();

            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationModel model)
        {
            string comttxt = $"insert into [User Management] values('{model.FirstName}','{model.LastName}','{model.EmailId}','{model.Password}'" +
                $",'{model.UserRole}',{model.IsActive})";

            SqlCommand cmd = new SqlCommand(comttxt, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
