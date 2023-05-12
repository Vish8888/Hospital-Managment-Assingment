using Hospital_Managment.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Hospital_Managment.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        #region Globle Connection String
        SqlConnection conn = new SqlConnection("Data Source=VISHAL_CHIMKAR\\SQLEXPRESS;Initial Catalog=\"Hospital Management\";Integrated Security=True");
        #endregion

        //public IActionResult Index()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult User()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult User(UserModel userModel)
        //{

        //    SqlCommand cmd = new SqlCommand($"insert into Users values('{userModel.MedicineName}','{userModel.Price}','{userModel.TotalStock}')", conn);
        //    cmd.ExecuteReader();
        //    conn.Open();
        //    int count = cmd.ExecuteNonQuery();
        //    if (count > 0)
        //    {
        //        return RedirectToAction("User");
        //    }
        //    return View();
        //}
        
        [HttpGet]
        public IActionResult Addpatiant()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult Addpatiant(PatiantModel model)
        {
            string cmdtext = $"insert into Patiant values('{model.FirstName}','{model.LastName}','{model.PhoneNumber}','{model.Email}','{model.Address}','{model.MedicalCondition}','{model.Followup}')";
            SqlCommand cmd = new SqlCommand(cmdtext,conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                return RedirectToAction("index");
            }
            return View();
        }

    }
}
