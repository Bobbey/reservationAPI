using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace reservationAPI.Model
{
    public partial class RoomdisplayContext : DbContext
    {
        public RoomdisplayContext()
        {

        }

        public RoomdisplayContext(DbContextOptions<RoomdisplayContext> options) : base(options)
        {

        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Meetingroom> Meetingroom { get; set; }


  
    }
}
