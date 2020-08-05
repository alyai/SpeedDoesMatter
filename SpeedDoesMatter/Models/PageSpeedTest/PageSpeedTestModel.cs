using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

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


}