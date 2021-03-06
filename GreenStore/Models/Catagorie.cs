using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GreenStore.Models
{
    public class Catagorie
    {
        [Key]
        [DisplayName("Mã loại")]
        public int ID { get; set; }

        [DisplayName("Loại hàng")]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}