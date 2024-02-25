using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_OrderDetail")]
    public class OrderDetail
    {
        [Required]
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        [Required]
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}