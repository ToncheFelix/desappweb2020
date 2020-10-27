using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class FacilitieList {
        [Key]
        public int FacilityID { get; set; }
        public string FacilityDesc { get; set; }
        
        //Relaciones uno a muchos
        public ICollection<RoomFacility> RoomFacilities {get; set;}


    }

}