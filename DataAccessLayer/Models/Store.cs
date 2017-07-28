using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
   public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreDescription { get; set; }
        public string StoreLogo { get; set; }
    }
}
