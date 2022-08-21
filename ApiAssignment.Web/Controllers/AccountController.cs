using ApiAssignment.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityAuthApi.Web.Controllers
{
    public class AccountController : Controller
    {
        
        public AccountController()
        {
            
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            RestClient client = new RestClient("https://localhost:44353/api/Account/Login"); // localhost
            RestRequest request = new RestRequest();
            //var model = new LoginViewModel { UserName = username, Password =password };
            request.AddBody(model);
           
            var response = client.ExecutePost(request);
            var res = JsonConvert.DeserializeObject<ResultViewModel>(response.Content);
            if (res.IsSuccess)
            {
                HttpContext.Session.SetString("token", res.Data.ToString());
                return RedirectToAction("Index", "Student");
            }
            return View();
        }

    }
}
