using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservacionesHotel.Models
{

    public class Booking {
        [Key]
        [Display(Name="ID")]
        public int BookingID { get; set; }
        [Display(Name="ID Customer")]
        public int CustomerID { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name="Booking Made")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateBookingMade { get; set; }
        [DataType(DataType.Time)]
        [Display(Name="Time Made")]
        public DateTime TimeBookingMade { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name="Booked Start")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookedStartDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name="Booked End")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookedEndDate { get; set; }

        [Display(Name="Payment Due")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TotalPaymentDueDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        [Display(Name="Price")]
        public decimal TotalPaymentDueAmount { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Payment Made")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TotalPaymentMadeOn { get; set; }
        [StringLength(50)]
        [Display(Name="Comments")]
        public string BookingComments { get; set; }

        //Relaciones uno a muchos
        public ICollection<BookingRoom> BookingRooms {get; set;}
        public ICollection<Payment> Payments {get; set;}

        //Relación Muchos a Uno
        public Customer Customer {get; set;}


    }

}