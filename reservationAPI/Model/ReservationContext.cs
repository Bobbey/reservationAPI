using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace reservationAPI.Model
{
    public class ReservationContext : DbContext
    {
        public ReservationContext()
        {

        }

        public ReservationContext(DbContextOptions<ReservationContext> options) : base(options)
        {

        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Meetingroom> Meetingroom { get; set; }


  
    }
}
