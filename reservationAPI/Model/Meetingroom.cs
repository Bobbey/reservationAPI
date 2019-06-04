using System;
using System.Collections.Generic;

namespace reservationAPI.Model
{
    public partial class Meetingroom
    {
        public int IdMeetingroom { get; set; }
        public string Roomname { get; set; }
        public int? Capacity { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
