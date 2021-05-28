using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Parser
{
    public class NewsModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Theme { get; set; }
        public string  Text { get; set; }
        public DateTime newsDate { get; set; }

    }

}
