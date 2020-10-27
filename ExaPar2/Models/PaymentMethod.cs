using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class PaymentMethod {
        [Key]
        public int PaymentMethodID { get; set; }
        public string PaymentMethodDesc { get; set; }

        
        //Relaciones uno a muchos
        public ICollection<Payment> Payments {get; set;}

    }

}