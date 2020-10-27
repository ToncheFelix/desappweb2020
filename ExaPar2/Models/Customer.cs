using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReservacionesHotel.Models
{

    public class Customer {
        [Key]
        [Display(Name="ID")]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Title")]
        public string CustomerTitle { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name="Last Name")]
        public string CustomerForenames { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name=" Name")]
        public string CustomerSurnames { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name="DOB")]
        public DateTime CustomerDOB { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Street Address")]
        public string CustomerAddressStreet { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Town")]
        public string CustomerAddressTown { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Country")]
        public string CustomerAddressCountry { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Postal Code")]
        public string CustomerAddressPostalCode { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Home phone")]
        public string CustomerHomePhone { get; set; }
        [StringLength(50)]
        [Display(Name="Work phone")]
        public string CustomerWorkPhone { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name="Mobile")]
        public string CustomerMobilPhone { get; set; }
        [StringLength(50)]
        [Display(Name="E-mail")]
        public string CustomerEmail { get; set; }

    //Relaciones uno a muchos
        public ICollection<Booking> Bookings {get; set;}
        public ICollection<Payment> Payments {get; set;}
        


    }

}