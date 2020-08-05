using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpeedDoesMatter.DataAccess.Entities
{

    [Table("PageSpeedTest")]
    public class PageSpeedTest
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("WebsiteURL")]
        public string WebsiteURL { get; set; }

        [Column("PageSpeedTestMobileScore")]
        public int PageSpeedTestMobileScore { get; set; }

        [Column("PageSpeedTestDesktopScore")]
        public int PageSpeedTestDesktopScore { get; set; }
    }
}
