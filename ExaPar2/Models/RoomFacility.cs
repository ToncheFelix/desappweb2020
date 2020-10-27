using System;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class RoomFacility {
        public int RoomID { get; set; }
        public int FacilityID { get; set; }
        [StringLength(50)]
        public string FacilityDetails { get; set; }

        //Relación Muchos a Uno
        public FacilitieList FacilitieList {get; set;}
        public Room Room {get; set;}
    }

}