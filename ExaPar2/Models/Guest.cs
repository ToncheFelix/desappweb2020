using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class Guest {
        [Key]
        [Display(Name="ID")]
        public int GuestID  { get; set; }
        [Display(Name="Title")]
        public string GuestTitle  { get; set; }
        [Display(Name="Last Name")]
        public string GuestForenames  { get; set; }
        [Display(Name="Name")]
        public string GuestSurnames  { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="Birth Day")]
        public DateTime GuestDOB  { get; set; }
        [StringLength(50)]
        [Display(Name="Street Address")]
        public string GuestAddressStreet  { get; set; }
        [StringLength(50)]
        [Display(Name="Town Address")]
        public string GuestAddressTown  { get; set; }
        [StringLength(50)]
        [Display(Name="Country Address")]
        public string GuestAddressCountry  { get; set; }
        [StringLength(50)]
        [Display(Name="Postal Code")]
        public string GuestAddressPostalCode  { get; set; }
        [StringLength(50)]
        [Display(Name="Phone")]
        public string GuestContactPhone  { get; set; }

        //Relaciones uno a muchos
        public ICollection<BookingRoom> BookingRooms {get; set;}
    }

}