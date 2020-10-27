using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class RoomType {
        [Key]
        public int RoomTypeID { get; set; }
        public string RoomTypeDesc { get; set; }

        //Relaciones uno a muchos
        public ICollection<Room> Rooms {get; set;}
    }

}