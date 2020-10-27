using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservacionesHotel.Models
{

    public class Room {
        [Key]
        [Display(Name="ID")]
        public int RoomID { get; set; }

        public int RoomTypeID { get; set; }
        public int RoomBandID { get; set; }
        public int RoomPriceID { get; set; }
        public string Floor { get; set; }
        [StringLength(50)]
        [Display(Name="Additional Notes")]
        public string AdditionalNotes { get; set; }

        //Relación Muchos a Uno
        [Display(Name="Room Type")]
        public RoomType RoomType {get; set;}
        [Display(Name="Room Band")]
        public RoomBand RoomBand {get; set;}
        [Display(Name="Room Price")]
        public RoomPrice RoomPrice {get; set;}

        //Relaciones uno a muchos
        public ICollection<RoomFacility> RoomFacilities {get; set;}
        public ICollection<BookingRoom> BookingRooms {get; set;}

        
    }

}