using System;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class BookingRoom {
        [Display(Name="ID")]
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }

        //Relación Muchos a Uno
        public Booking Booking {get; set;}
        public Room Room {get; set;}
        public Guest Guest {get; set;}
    }

}
