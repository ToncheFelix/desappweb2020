using ReservacionesHotel.Models;
using Microsoft.EntityFrameworkCore;


namespace ReservacionesHotel.Data {

public class Context: DbContext {

public Context(DbContextOptions<Context> options) 
         : base(options)
         {

         }
          public DbSet<Customer> Customers { get; set;}
          public DbSet<Guest> Guests { get; set;}
          public DbSet<Room> Rooms { get; set;}
          public DbSet<Booking> Bookings { get; set;}
          public DbSet<Payment> Payments { get; set;}
          public DbSet<PaymentMethod> PaymentMethods { get; set;}
          public DbSet<RoomType> RoomTypes { get; set;}
          public DbSet<RoomPrice> RoomPrices { get; set;}
          public DbSet<RoomBand> RoomBands { get; set;}
          public DbSet<BookingRoom> BookingRooms { get; set;}
          public DbSet<RoomFacility> RoomFacilities { get; set;}
          public DbSet<FacilitieList> FacilitieLists { get; set;}

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<RoomPrice>().ToTable("RoomPrice");
            modelBuilder.Entity<RoomBand>().ToTable("RoomBand");
            modelBuilder.Entity<BookingRoom>().ToTable("BookingRoom");
            modelBuilder.Entity<RoomFacility>().ToTable("RoomFacility");
            modelBuilder.Entity<FacilitieList>().ToTable("FacilitieList");

            
            modelBuilder.Entity<BookingRoom>().HasKey(c => new {c.BookingID, c.RoomID,c.GuestID});

            modelBuilder.Entity<RoomFacility>().HasKey(c => new {c.RoomID, c.FacilityID});



        }
    }


}