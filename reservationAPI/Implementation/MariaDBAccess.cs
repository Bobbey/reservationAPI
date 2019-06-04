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
        private readonly RoomdisplayContext _database;

        public MariaDBAccess(RoomdisplayContext database)
        {
            _database = database;
        }

        public Meetingroom GetMeetingroom(int id)
        {
            var room = _database.Meetingroom.Find(id);
            return room;
        }

        public Meetingroom CreateMeetingroom(string name, int capacity)
        {
            var newRoom = new Meetingroom() { Roomname = name, Capacity = capacity };
            _database.Meetingroom.Add(newRoom);
            _database.SaveChanges();
            return newRoom;
        }

        public bool EditMeetingroom(string id, string name = "", int capacity = 0)
        {
            var roomToEdit = _database.Meetingroom.Find(id);

            if (!string.IsNullOrEmpty(name))
            {
                roomToEdit.Roomname = name;
            }
            if (capacity > 0)
            {
                roomToEdit.Capacity = capacity;
            }

            int changes = _database.SaveChanges();
            bool success = changes > 0;

            return success;
        }

        public bool DeleteMeetingroom(int id)
        {
            _database.Meetingroom.RemoveRange(_database.Meetingroom.Where(room => room.IdMeetingroom == id));
            int changes = _database.SaveChanges();
            bool success = changes > 0;

            return success;
        }

        public Appointment GetAppointment(int id)
        {
            var appointment = _database.Appointment.Find(id);
            return appointment;
        }

        public Appointment GetAppointmentAndRoom(int id)
        {
            var appointment = _database.Appointment.Where(x => x.IdAppointment == id).Include(appointment => appointment.);
            return appointment;
        }

        public ICollection<Appointment> GetDailyAppointmentByRoomId(int id)
        {
            ICollection<Appointment> appointment = _database.Appointment.Where(x => x.MeetingroomId == id && x.StartTime.Date == DateTime.Today.Date).ToList();
            return appointment;
        }

        public Appointment CreateAppointment(string title, int roomId, DateTime endDateTime, DateTime startDateTime)
        {
            var newAppointment = new Appointment() { Title = title, MeetingroomId = roomId, StartTime = startDateTime, EndTime = endDateTime };
            _database.Appointment.Add(newAppointment);
            _database.SaveChanges();
            return newAppointment;
        }

        public bool EditAppointment(string id, DateTime endDateTime, DateTime startDateTime, string title, int roomId)
        {
            var appointmentToEdit = _database.Appointment.Find(id);

            appointmentToEdit.EndTime = endDateTime;
            appointmentToEdit.StartTime = startDateTime;

            if (!string.IsNullOrEmpty(title))
            {
                appointmentToEdit.Title = title;
            }

            if (roomId > 0)
            {
                appointmentToEdit.MeetingroomId = roomId;
            }

            int changes = _database.SaveChanges();

            bool success = changes > 0;
            return success;
        }

        public bool DeleteAppointment(int id)
        {
            _database.Meetingroom.RemoveRange(_database.Meetingroom.Where(room => room.MeetingroomId == id));
            int changes = _database.SaveChanges();
            bool success = changes > 0;
            return success;
        }

        public ICollection<Appointment> GetDailyAppointmentsByRoomId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
