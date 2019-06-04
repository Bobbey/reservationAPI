using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace reservationAPI.Model
{
    public class Meetingroom
    {
        [Key]
        public int IdMeetingroom { get; set; }
        public string Roomname { get; set; }
        public int? Capacity { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
