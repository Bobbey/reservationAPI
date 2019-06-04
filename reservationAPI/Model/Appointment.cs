using System;
using System.Collections.Generic;

namespace reservationAPI.Model
{
    public class Appointment
    {
        public int IdAppointment { get; set; }
        public string Title { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public Meetingroom Meetingroom { get; set; }
    }
}
