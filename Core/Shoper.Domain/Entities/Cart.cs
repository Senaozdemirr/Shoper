using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }    //musteri kayıt olmadan da sepet olusturabilsin diye null da olabilir diyoruz o yuzden ?
        public ICollection<CartItem> CartItems { get; set; }
    }
}
