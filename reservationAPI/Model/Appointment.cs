using System;
using System.ComponentModel.DataAnnotations;

namespace reservationAPI.Model
{
    public class Appointment
    {
        [Key]
        public int IdAppointment { get; set; }
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public Meetingroom Meetingroom { get; set; }
    }
}
