using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SpeedDoesMatter.Controllers;

namespace SpeedDoesMatter.Models.PageSpeedTest
{

    public class PageSpeedTestModel
    {

        [Key]
        [ScaffoldColumn(false)]
        public int RecordID { get; set; }

        [Required(ErrorMessage = "Website URL is required")]
        [Display(Name = "WebsiteURL")]
        public string WebsiteURL { get; set; }
        public string API_KEY { get; set; }


        public int Id { get; set; }

        public int PageSpeedTestMobileScore { get; set; }

        public int PageSpeedTestDesktopScore { get; set; }
    }

    public class PageSpeedEntity
    {
        public string kind { get; set; }
        public string Id { get; set; }
        public int responseCode { get; set; }
        public string title { get; set; }
        public int score { get; set; }
        public PageStats pageStats { get; set; }
    }

    public class PageStats
    {
        public int numberResources { get; set; }
        public int numberHosts { get; set; }
        public double totalRequestBytes { get; set; }
        public int numberStaticResources { get; set; }
        public double htmlResponseBytes { get; set; }
        public double cssResponseBytes { get; set; }
        public double imageResponseBytes { get; set; }
        public double javascriptResponseBytes { get; set; }
        public int numberJsResources { get; set; }
        public int numberCssResources { get; set; }
    }


}