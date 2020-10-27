using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservacionesHotel.Models
{

    public class Payment {
        [Key]
        [Display(Name="ID")]
        public int PaymentID { get; set; }
        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public int PaymentMethodID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal PaymentAmount { get; set; }
        
        [StringLength(50)]
        [Display(Name="Comments")]
        public string PaymentComments { get; set; }

        //Relación Muchos a Uno
        public Customer Customer {get; set;}
        public Booking Booking {get; set;}
        public PaymentMethod PaymentMethod {get; set;}
        

    }

}