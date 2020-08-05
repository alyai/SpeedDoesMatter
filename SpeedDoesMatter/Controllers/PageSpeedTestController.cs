using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpeedDoesMatter.Models;
using SpeedDoesMatter.Models.PageSpeedTest;
using SpeedDoesMatter.DataAccess.Entities;
using SpeedDoesMatter.DataAccess.Repositories;

using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Utilities;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace SpeedDoesMatter.Controllers
{
    public class PageSpeedTestController : Controller
    {
        private readonly PageSpeedTestRepository _pagespeedtestRepository;
        public PageSpeedTestController()
        {
            _pagespeedtestRepository = new PageSpeedTestRepository();

        }

        //public class RootObject
        //{
        //public string ErrorMessage { get; set; }
        //public int Status { get; set; }
        //}

        public IActionResult Index()
        {
            // List PagespeedTests logic
            var pagespeedtests = _pagespeedtestRepository.GetPageSpeedTests();

            List<PageSpeedTestModel> pagespeedModels = new List<PageSpeedTestModel>();
            
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Index(PageSpeedTestModel sm)
        {

            HttpClient client = new HttpClient();
            string WebsiteURL = sm.WebsiteURL;
            string API_KEY = "&key=AIzaSyDNuOKUCHAVGzMLEhcbOLIyWFXCwlnB7zU";

            string sURL;


            sURL = "https://pagespeedonline.googleapis.com/pagespeedonline/v5/runPagespeed?category=PERFORMANCE&strategy=MOBILE&url=" + WebsiteURL + API_KEY;


            //if (ModelState.IsValid)
            // {


            // try
            // {

            HttpResponseMessage homeResponseMessage = await client.GetAsync(sURL);
            homeResponseMessage.EnsureSuccessStatusCode();
            var homeValue = await homeResponseMessage.Content.ReadAsStringAsync();
            // Deserialize the response




            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            var homePageScore = Newtonsoft.Json.JsonConvert.DeserializeObject<PageSpeedTestModel>(homeValue);



            return View(homePageScore);



            //  }

            // catch (Exception ex)
            // {

            //  ModelState.AddModelError("", "Error");
            //  ex.ToString();
            //  }

            //  return View("Index");


            //  }
            //  else
            //  {


            //    ModelState.AddModelError("", "Error");

            // //     return View("Index");
            //  }



        }


    }

}
