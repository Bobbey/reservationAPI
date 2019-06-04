using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using reservationAPI.Interfaces;
using reservationAPI.Model;

namespace reservationAPI.Implementation
{
    public class MariaDBAccess : IDataAccess
    {
        private readonly ReservationContext database;

        public MariaDBAccess(ReservationContext database)
        {
            this.database = database;
        }

        public Meetingroom GetMeetingroom(int id)
        {
            var room = database.Meetingroom.Find(id);
            return room;
        }

        public Meetingroom CreateMeetingroom(string name, int capacity)
        {
            var newRoom = new Meetingroom() { Roomname = name, Capacity = capacity };
            database.Meetingroom.Add(newRoom);
            database.SaveChanges();
            return newRoom;
        }

        public bool EditMeetingroom(string id, string name = "", int capacity = 0)
        {
            var roomToEdit = database.Meetingroom.Find(id);

            if (!string.IsNullOrEmpty(name))
            {
                roomToEdit.Roomname = name;
            }
            if (capacity > 0)
            {
                roomToEdit.Capacity = capacity;
            }

            int changes = database.SaveChanges();
            bool success = changes > 0;

            return success;
        }

        public bool DeleteMeetingroom(int id)
        {
            database.Meetingroom.RemoveRange(database.Meetingroom.Where(room => room.IdMeetingroom == id));
            int changes = database.SaveChanges();
            bool success = changes > 0;

            return success;
        }

        public Appointment GetAppointment(int id)
        {
            var appointment = database.Appointment.Find(id);
            return appointment;
        }

        public Appointment GetAppointmentAndRoom(int id)
        {
            var appointment = database.Appointment.Find(id);
            return appointment;
        }

        public ICollection<Appointment> GetDailyAppointmentByRoomId(int id)
        {
            ICollection<Appointment> appointment = database.Meetingroom.Find(id).Appointments;
            return appointment;
        }

        public Appointment CreateAppointment(string title, int roomId, DateTime endDateTime, DateTime startDateTime)
        {
            var newAppointment = new Appointment() { Title = title, Start = startDateTime, End = endDateTime, Meetingroom = database.Meetingroom.Find(roomId) };
            database.Appointment.Add(newAppointment);
            database.SaveChanges();
            return newAppointment;
        }

        public bool EditAppointment(string id, DateTime endDateTime, DateTime startDateTime, string title, int roomId)
        {
            var appointmentToEdit = database.Appointment.Find(id);

            appointmentToEdit.End = endDateTime;
            appointmentToEdit.Start = startDateTime;

            if (!string.IsNullOrEmpty(title))
            {
                appointmentToEdit.Title = title;
            }

            int changes = database.SaveChanges();

            bool success = changes > 0;
            return success;
        }

        public bool DeleteAppointment(int id)
        {
            var appointment = new Appointment() { IdAppointment = id };
            database.Entry(appointment).State = EntityState.Deleted;
            int changes = database.SaveChanges();
            bool success = changes > 0;
            return success;
        }

        public ICollection<Appointment> GetDailyAppointmentsByRoomId(int id)
        {
            return database.Meetingroom.Find(id).Appointments;
        }
    }
}
