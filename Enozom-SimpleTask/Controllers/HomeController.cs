using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;

namespace Enozom_SimpleTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Stores()
        {
            return View();
        }

        public int InsertRecord()
        {
            int ret = 0; 
            var Data = Request.Form;
            var Image = Request.Files["img"];
            var ImageName = Path.GetFileName(Image.FileName);
            var path = Path.Combine(Server.MapPath("~/Resources"), ImageName);
            Image.SaveAs(path);

            HttpClient App = new HttpClient();
            Store NewS = new Store() { StoreName = Request.Form["sname"], StoreDescription = Request.Form["sdes"], StoreLogo = "..\\Resources\\" + ImageName };
            var Response = App.PostAsync("http://localhost:61757/api/Stores/InsertNewStore", new StringContent(
             new JavaScriptSerializer().Serialize(NewS), Encoding.UTF8, "application/json")).Result;

            ret = (int.Parse(Response.Content.ReadAsStringAsync().Result) != 0 ? 1 : 0); 



            return ret;
        }

        public int UpdateRecord()
        {
            int ret = 0;
            var Response = (HttpResponseMessage)null;
            Store NewS;
            if (!Request.Form.AllKeys.Contains("imgname"))
            {
                var Data = Request.Form;
                var Image = Request.Files["img"];
                var ImageName = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("~/Resources"), ImageName);
                var Existed = System.IO.File.Exists(path);
                if (!Existed)
                {
                    Image.SaveAs(path);
                }

                NewS = new Store() { StoreId = int.Parse(Request.Form["id"]), StoreName = Request.Form["sname"], StoreDescription = Request.Form["sdes"], StoreLogo = "..\\Resources\\" + ImageName };

            }
            else
            {
                NewS = new Store()
                { StoreId = int.Parse(Request.Form["id"]), StoreName = Request.Form["sname"], StoreDescription = Request.Form["sdes"], StoreLogo = Request.Form["imgname"] };
            }


            HttpClient App = new HttpClient();
            Response = App.PostAsync("http://localhost:61757/api/Stores/UpdateEixtedObject", new StringContent(
             new JavaScriptSerializer().Serialize(NewS), Encoding.UTF8, "application/json")).Result;


            ret = (int.Parse(Response.Content.ReadAsStringAsync().Result) != 0 ? 1 : 0);
            return ret;

        }


    }
}