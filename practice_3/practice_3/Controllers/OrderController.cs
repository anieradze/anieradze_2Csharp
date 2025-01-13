using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using practice_3.Models;

namespace practice_3.Controllers
{
    public class OrderController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-59H1E8\\SQLEXPRESS;Initial Catalog=orders;Integrated Security=True;Trust Server Certificate=True";

        // GET: OrderController
        public ActionResult Index()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from [Orders].[dbo].[Xelshekruleba]", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order()
                    {
                        xelshekrulebaID = reader["xelshelrulebaID"].ToString(),
                        personaliID = reader["personaliID"].ToString(),
                        shemkvetiID = reader["shemkvetiID"].ToString(),
                        gadasaxdeli_l = reader["gadasaxdeli_l"].ToString(),
                        gadasaxdeli_d = reader["gadasaxdeli_d"].ToString(),
                        gadaxdili_l = reader["gadaxdili_l"].ToString(),
                        gadaxdili_d = reader["gadaxdili_d"].ToString(),
                        vali_l = reader["vali_l"].ToString(),
                        vali_d = reader["vali_d"].ToString(),
                        kursi = reader["kursi"].ToString(),
                        tarigi_dawyebis = reader["tarigi_dawyebis"].ToString(),
                        tarigi_shesrulebis = reader["tarigi_shesrulebis"].ToString(),
                        tarigi_damtavrebis = reader["tarigi_damtavrebis"].ToString(),
                        shesruleba = reader["shesruleba"].ToString(),
                        visi_mizezit = reader["visi_mizezit"].ToString(),

                    };
                    orders.Add(order);

                }
            }
            return View(orders);

        }

        // GET: OrderController/Details/5
        public ActionResult Details(string id)
        {

            Order order = new Order();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"Select * from [Orders].[dbo].[Xelshekruleba] where xelshekrulebaID = {id}", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    {
                        order.xelshekrulebaID = reader["xelshelrulebaID"].ToString();
                        order.personaliID = reader["personaliID"].ToString();
                        order.shemkvetiID = reader["shemkvetiID"].ToString();
                        order.gadasaxdeli_l = reader["gadasaxdeli_l"].ToString();
                        order.gadasaxdeli_d = reader["gadasaxdeli_d"].ToString();
                        order.gadaxdili_l = reader["gadaxdili_l"].ToString();
                        order.gadaxdili_d = reader["gadaxdili_d"].ToString();
                        order.vali_l = reader["vali_l"].ToString();
                        order.vali_d = reader["vali_d"].ToString();
                        order.kursi = reader["kursi"].ToString();
                        order.tarigi_dawyebis = reader["tarigi_dawyebis"].ToString();
                        order.tarigi_shesrulebis = reader["tarigi_shesrulebis"].ToString();
                        order.tarigi_damtavrebis = reader["tarigi_damtavrebis"].ToString();
                        order.shesruleba = reader["shesruleba"].ToString();
                        order.visi_mizezit = reader["visi_mizezit"].ToString();


                    }
                }
            }
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand($"" +
                        $"insert into [Orders].[dbo].[Xelshekruleba] ([personalID],[shemkvetiID],[gadasaxdeli_l],[gadasaxdeli_d],[gadaxdili_l],[gadaxdili_d],[vali_l]),[vali_d],[kursi],[tarigi_dawyebis],[tarigi_shesrulebis],[tarigi_damtavrebis],[shesruleba],[visi_mizezit] values");
                     SqlDataReader reader = cmd.ExecuteReader();
                }
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

