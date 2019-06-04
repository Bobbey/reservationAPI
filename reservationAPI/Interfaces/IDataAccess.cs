using reservationAPI.Model;
using System;
using System.Collections.Generic;


namespace reservationAPI.Interfaces
{
    public interface IDataAccess
    {
        Meetingroom GetMeetingroom(int id);

        Meetingroom CreateMeetingroom(string name, int capacity);

        bool EditMeetingroom(string id, string name, int capacity);

        bool DeleteMeetingroom(int id);

        Appointment GetAppointment(int id);

        Appointment GetAppointmentAndRoom(int id);

        ICollection<Appointment> GetDailyAppointmentsByRoomId(int id);

        Appointment CreateAppointment(string title, int roomId, DateTime endDateTime, DateTime startDateTime);

        bool EditAppointment(string id, DateTime endDateTime, DateTime startDateTime, string title, int roomId);

        bool DeleteAppointment(int id);

    }
}
