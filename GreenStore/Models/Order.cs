using GreenStore.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GreenStore.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {

        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ")]
        [DisplayName("Họ và tên đệm")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [DisplayName("Tên")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [StringLength(70)]
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thành phố")]
        [StringLength(40)]
        [DisplayName("Thành phố")]
        public string City { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập quận")]
        [StringLength(40)]
        [DisplayName("Quận")]
        public string State { get; set; }

        //[Required(ErrorMessage = "Postal Code is required")]
        //[DisplayName("Postal Code")]
        //[StringLength(10)]
        //public string PostalCode { get; set; }

        //[Required(ErrorMessage = "Country is required")]
        //[StringLength(40)]
        //public string Country { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điênj thoại")]
        [StringLength(24)]
        [DisplayName("Số điẹn thoại")]
        public string Phone { get; set; }

        //[Display(Name = "Experation Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime Experation { get; set; }

        //[Display(Name = "Credit Card")]
        //[NotMapped]
        //[Required]
        //[DataType(DataType.CreditCard)]
        //public String CreditCard { get; set; }

        //[Display(Name = "Credit Card Type")]
        //[NotMapped]
        //public String CcType { get; set; }
        [DisplayName("Lưu thông tin")]
        public bool SaveInfo { get; set; }


        [DisplayName("Địa chỉ Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email không đúng.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Tổng tiền")]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

       

        public string ToString(Order order)
        {
            StringBuilder bob = new StringBuilder();

            bob.Append("<p>Thông tin đơn hàng: "+ order.OrderId +"<br>Ngày đặt: " + order.OrderDate +"</p>").AppendLine();
            bob.Append("<p>Họ tên: " + order.FirstName + " " + order.LastName + "<br>");
            bob.Append("Địa chỉ: " + order.Address + " " + order.City + " " + order.State + " " + "<br>");
            bob.Append("Liên hệ: " + order.Email + "     " + order.Phone + "</p>");
            //bob.Append("<p>Charge: " + order.CreditCard + " " + order.Experation.ToString("dd-MM-yyyy") + "</p>");
            //bob.Append("<p>Credit Card Type: " + order.CcType + "</p>");

            bob.Append("<br>").AppendLine();
            bob.Append("<Table>").AppendLine();
            // Display header 
            string header = "<tr> <th>Tên sản phẩm</th>" + "<th>Số lượng</th>" + "<th>Đơn giá</th> <th></th> </tr>";
            bob.Append(header).AppendLine();

            String output = String.Empty;
			try
			{
                foreach (var item in order.OrderDetails)
                {
                    bob.Append("<tr>");
                    output = "<td>" + item.Item.Name + "</td>" + "<td>" + item.Quantity + "</td>" + "<td>" + item.Quantity * item.UnitPrice + "</td>";
                    bob.Append(output).AppendLine();
                    Console.WriteLine(output);
                    bob.Append("</tr>");
                }
            }
            catch (Exception)
			{
                output = "Chưa có sản phẩm được đặt.";
            }
            bob.Append("</Table>");
            bob.Append("<b>");
            // Display footer 
            string footer = String.Format("{0,-12}{1,12}\n",
                                          "Tổng tiền", order.Total);
            bob.Append(footer).AppendLine();
            bob.Append("</b>");

            return bob.ToString();
        }
    }
}