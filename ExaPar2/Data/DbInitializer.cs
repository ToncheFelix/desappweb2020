using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservacionesHotel.Models;

namespace ReservacionesHotel.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

// Customers
            var customers = new Customer[]
            {
                new Customer { 
                    CustomerID = 100,   
                    CustomerTitle = "Standard",
                    CustomerForenames = "Hernandez",
                    CustomerSurnames = "Pedro",
                    CustomerDOB = DateTime.Parse("1992-09-01"),
                    CustomerAddressStreet = "Calle 1",
                    CustomerAddressTown   = "Zacatecas",
                    CustomerAddressCountry = "Mexico",
                    CustomerAddressPostalCode = "98000",
                    CustomerHomePhone = "4928896558",
                    CustomerWorkPhone = "4927796251",
                    CustomerMobilPhone = "4988898521",
                    CustomerEmail     = "Pedro1992hz@gmail.com"}
            };

            foreach (Customer s in customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();
// Booking *
          
            var bookings = new Booking[]
            {
                new Booking { 
                    BookingID = 10, 
                    CustomerID = customers.Single( c => c.CustomerSurnames == "Pedro").CustomerID,
                    DateBookingMade = DateTime.Parse("2020-09-01"),
                    TimeBookingMade = DateTime.Parse("2020-09-01"),
                    BookedStartDate = DateTime.Parse("2020-09-02"),
                    BookedEndDate   = DateTime.Parse("2020-09-06"),
                    TotalPaymentDueDate = DateTime.Parse("2020-09-06"),
                    TotalPaymentDueAmount = 2500,
                    TotalPaymentMadeOn   = DateTime.Parse("2020-09-06"),
                    BookingComments = "Reservación correcta"
                    }
            };

            foreach (Booking i in bookings)
            {
                context.Bookings.Add(i);
            }
            context.SaveChanges();
// FacilitieList
            var facilitieLists = new FacilitieList[]
            {
                new FacilitieList { 
                    FacilityID = 1,
                    FacilityDesc = "Jacuzzi"                
                    }
            };

            foreach (FacilitieList i in facilitieLists)
            {
                context.FacilitieLists.Add(i);
            }
            context.SaveChanges();
// PaymentMethod
            var paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod { 
                    PaymentMethodID   = 1,
                    PaymentMethodDesc = "Debit Card"
                    }
            };

            foreach (PaymentMethod i in paymentMethods)
            {
                context.PaymentMethods.Add(i);
            }
            context.SaveChanges(); 
// Payment
            var payments = new Payment[]
            {
                new Payment { 
                    PaymentID = 1, 
                    BookingID = bookings.Single(c => c.BookingID == 10).BookingID,
                    CustomerID = customers.Single(c => c.CustomerID == 100).CustomerID, //PEdro
                    PaymentMethodID = paymentMethods.Single(p => p.PaymentMethodID == 1).PaymentMethodID,
                    PaymentAmount = 5000,
                    PaymentComments = "Todo en orden"                 
                    }
            };

            foreach (Payment i in payments)
            {
                context.Payments.Add(i);
            }
            context.SaveChanges();
// Guests         

            var guests = new Guest[]
            {
                new Guest { 
                    GuestID = 123,
                    GuestTitle = "Teacher",
                    GuestForenames = "Perez",
                    GuestSurnames = "Pancho",
                    GuestDOB    = DateTime.Parse("1996-09-01"),
                    GuestAddressStreet = "Calle primavera 5",
                    GuestAddressTown   = "Zacatecas",
                    GuestAddressCountry = "Mexico",
                    GuestAddressPostalCode = "98600",
                    GuestContactPhone      = "1651254305"    
                    }
            };

            foreach (Guest i in guests)
            {
                context.Guests.Add(i);
            }
            context.SaveChanges();
// RoomType
            
            var roomtypes = new RoomType[]
            {
                new RoomType { 
                    RoomTypeID = 1,
                    RoomTypeDesc =  "Suite 5 stars"            
                    }
                
            };

            foreach (RoomType i in roomtypes)
            {
                context.RoomTypes.Add(i);
            }
            context.SaveChanges();

// RoomBand
            var roomBands = new RoomBand[]
            {
                new RoomBand { 
                    RoombandID = 1, 
                    BandDesc = "5 beds"      
                    }
            };

            foreach (RoomBand i in roomBands)
            {
                context.RoomBands.Add(i);
            }
            context.SaveChanges(); 

// RoomPrice
            var roomPrices = new RoomPrice[]
            {
                new RoomPrice { 
                    RoomPriceID = 1,
                    RoomPriceDesc = 5000
                    },
                new RoomPrice { 
                    RoomPriceID = 2,
                    RoomPriceDesc = 2500
                    }
            };

            foreach (RoomPrice i in roomPrices)
            {
                context.RoomPrices.Add(i);
            }
            context.SaveChanges();



// Rooms *
            var rooms = new Room[]
            {
                new Room { 
                    RoomID = 502,
                    RoomTypeID = roomtypes.Single(c => c.RoomTypeID == 1).RoomTypeID,
                    RoomBandID = roomBands.Single(i => i.RoombandID == 1).RoombandID,
                    RoomPriceID = roomPrices.Single(r => r.RoomPriceID == 2).RoomPriceID,
                    Floor = "5th Floor",
                    AdditionalNotes = "Excellent View"                 
                    }
            };

            foreach (Room i in rooms)
            {
                context.Rooms.Add(i);
            }
            context.SaveChanges();

// RoomFacility
            var roomFacilities = new RoomFacility[]
            {
                new RoomFacility { 
                    RoomID = rooms.Single(c => c.RoomID == 502).RoomID,
                    FacilityID = facilitieLists.Single(c => c.FacilityID == 1).FacilityID,
                    FacilityDetails =  "Realizado con exito",                 
                    }
            };

            foreach (RoomFacility i in roomFacilities)
            {
                context.RoomFacilities.Add(i);
            }
            context.SaveChanges();

//BookingRoom
            var bookingRooms = new BookingRoom[]
            {
                new BookingRoom { 
                    BookingID = bookings.Single(c => c.BookingID == 10).BookingID,
                    RoomID = rooms.Single(c => c.RoomID == 502).RoomID,
                    GuestID = guests.Single(c => c.GuestID == 123).GuestID                  
                    }
            };

            foreach (BookingRoom i in bookingRooms)
            {
                context.BookingRooms.Add(i);
            }
            context.SaveChanges();



        }
    }
}