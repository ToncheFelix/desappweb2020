using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class RoomBand {
        [Key]
        public int RoombandID { get; set; }
        public string BandDesc { get; set; }

        //Relaciones uno a muchos
        public ICollection<Room> Rooms {get; set;}
    }

}