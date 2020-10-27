using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class RoomPrice {
        [Key]
        public int RoomPriceID { get; set; }
        public decimal RoomPriceDesc { get; set; }


        //Relaciones uno a muchos
        public ICollection<Room> Rooms {get; set;}
    }

}