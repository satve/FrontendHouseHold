using HouseHoldFront.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HouseHoldFront.Controllers
{
    public class HouseHoldsController : Controller
    {
        // GET: HouseHolds
        public ActionResult Index()
        {
            var cookie = Request.Cookies["token"];
            if (cookie == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var accessToken = cookie.Value;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var result =
               httpClient.GetAsync("http://localhost:58110/api/households/View").Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = result.Content.ReadAsStringAsync().Result;
                var houseHolds = JsonConvert
                   .DeserializeObject<List<ViewHouseHoldViewModel>>(jsonString);
                return View(houseHolds);
            }
            return View();
        }

        public ActionResult Create(CreateHouseHoldViewModel model)
        {
            var cookie = Request.Cookies["token"];
            if (cookie == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var accessToken = cookie.Value;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("Name", model.Name));
            var formEncodedValues = new FormUrlEncodedContent(parameters);
            var result =
               httpClient.PostAsync("http://localhost:58110/api/households/PostHouseHolds", formEncodedValues).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = result.Content.ReadAsStringAsync().Result;
                var houseHold = JsonConvert
                   .DeserializeObject<HouseHolds>(jsonString);
                return View(houseHold);
            }
            return View();
        }
        //public ActionResult Edit(int id)
        //{
        //    var cookie = Request.Cookies["token"];
        //    var accessToken = cookie.Value;
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization =
        //       new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        //    var result =
        //       httpClient.GetAsync("http://localhost:58110/api/households/PutHouseHolds?id" + id).Result;
        //    var jsonString = result.Content.ReadAsStringAsync().Result;
        //    var houseHold = JsonConvert
        //       .DeserializeObject<EditHouseHoldViewModel>(jsonString);
        //    return View(houseHold);
        //}

        public ActionResult Edit(EditHouseHoldViewModel model)
        {
            var cookie = Request.Cookies["token"];
            if (cookie == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var accessToken = cookie.Value;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("Name", model.Name));
            var formEncodedValues = new FormUrlEncodedContent(parameters);
            var result =
               httpClient.PostAsync("http://localhost:58110/api/households/PutHouseHolds?id", formEncodedValues).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = result.Content.ReadAsStringAsync().Result;
                var houseHold = JsonConvert
                   .DeserializeObject<EditHouseHoldViewModel>(jsonString);
                return View(houseHold);
            }
            return View();
        }

        public ActionResult ViewMembers()
        {
            var cookie = Request.Cookies["token"];
            if (cookie == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var accessToken = cookie.Value;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var result =
               httpClient.GetAsync("http://localhost:58110/api/households/ViewMembers").Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = result.Content.ReadAsStringAsync().Result;
                var houseHolds = JsonConvert
                   .DeserializeObject<List<HouseHoldMembersViewModel>>(jsonString);
                return View(houseHolds);
            }
            return View();
        }

        //public ActionResult InviteMembers(int id)
        //{
        //    var cookie = Request.Cookies["token"];
        //    if (cookie == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    var accessToken = cookie.Value;
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization =
        //       new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        //    var result =
        //       httpClient.PostAsync("http://localhost:58110/api/households/HouseHoldInvites?id=" +id , null).Result;
        //    if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var jsonString = result.Content.ReadAsStringAsync().Result;
        //        var houseHolds = JsonConvert
        //           .DeserializeObject<HouseHolds>(jsonString);
        //        return View(houseHolds);
        //    }
        //    return View();
        //}

        public ActionResult Leave(int Id)
        {
            var cookie = Request.Cookies["token"];
            if (cookie == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var accessToken = cookie.Value;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var result =
               httpClient.PostAsync("http://localhost:58110/api/HouseHolds/Leave?Id=" + Id, null).Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = result.Content.ReadAsStringAsync().Result;
                var houseHold = JsonConvert
                   .DeserializeObject<HouseHolds>(jsonString);
                return View(houseHold);
            }
            return View();
        }

        //public ActionResult HouseHoldJoin(int Id)
        //{
        //    var cookie = Request.Cookies["token"];
        //    if (cookie == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }
        //    var accessToken = cookie.Value;
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Authorization =
        //       new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        //    var result =
        //       httpClient.PostAsync("http://localhost:58110/api/households/HouseHoldJoin?InvitedUserId", formEncodedValues).Result;
        //    if (result.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        var jsonString = result.Content.ReadAsStringAsync().Result;
        //        var houseHold = JsonConvert
        //           .DeserializeObject<HouseHolds>(jsonString);
        //        return View(houseHold);
        //    }
        //   return View();
        // }
    }
}