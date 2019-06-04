using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using reservationAPI.Interfaces;
using reservationAPI.Model;

namespace reservationAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAnyPolicy")]
    public class RoomDisplayController : ControllerBase
    {

        private readonly IDataAccess _dataAccess;

        public RoomDisplayController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet("Meetingrooms/{id}")]
        public ActionResult<Meetingroom> GetMeetingroom(int id)
        {
            var room = _dataAccess.GetMeetingroom(id);
            return new ActionResult<Meetingroom>(room);
        }

        [HttpPost("Meetingrooms")]
        public ActionResult<Meetingroom> CreateMeetingroom([FromForm]string name, [FromForm]int capacity)
        {
            var newRoom = _dataAccess.CreateMeetingroom(name, capacity);
            return new ActionResult<Meetingroom>(newRoom);
        }

        [HttpPut("Meetingrooms")]
        public ActionResult<bool> EditMeetingroom([FromForm]string id, [FromForm]string name = "", [FromForm]int capacity = 0)
        {
            bool success = _dataAccess.EditMeetingroom(id, name, capacity);
            return success;
        }

        [HttpDelete("Meetingrooms/{id}")]
        public ActionResult<bool> DeleteMeetingroom(int id)
        {
            var success = _dataAccess.DeleteMeetingroom(id);
            return new ActionResult<bool>(success);
        }

        [HttpGet("AppointmentsUnjoined/{id}")]
        public ActionResult<Appointment> GetAppointment(int id)
        {
            var appointment = _dataAccess.GetAppointment(id);
            return new ActionResult<Appointment>(appointment);
        }

        [HttpGet("Appointments/{id}")]
        public ActionResult<Appointment> GetAppointmentAndRoom(int id)
        {
            var appointment = _dataAccess.GetAppointmentAndRoom(id);
            return new ActionResult<Appointment>(appointment);
        }

        [HttpGet("Appointments/Today/{id}")]
        public ActionResult<ICollection<Appointment>> GetDailyAppointmentsByRoomId(int id)
        {
            var appointment = _dataAccess.GetDailyAppointmentsByRoomId(id);
            return new ActionResult<ICollection<Appointment>>(appointment);
        }

        [HttpPost("Appointments")]
        public ActionResult<dynamic> CreateAppointment([FromForm]string title, [FromForm]int roomId, [FromForm]DateTime endDateTime, [FromForm]DateTime startDateTime)
        {

            Appointment newAppointment;           

            if (endDateTime > startDateTime)
            {
                newAppointment = _dataAccess.CreateAppointment(title, roomId, endDateTime, startDateTime);
            }
            else
            {
                newAppointment = _dataAccess.CreateAppointment(title, roomId, startDateTime, endDateTime);
            }


            if (newAppointment == null)
            {
                return new ActionResult<bool>(false);
            }
            else
            {
                return new ActionResult<Appointment>(newAppointment);
            }
        }

        [HttpPut("Appointments")]
        public ActionResult<bool> EditAppointment([FromBody]string id, [FromForm]DateTime endDateTime, [FromForm]DateTime startDateTime, [FromForm]string title = "", [FromForm]int roomId = 0)
        {
            bool success = _dataAccess.EditAppointment(id, endDateTime, startDateTime, title, roomId);
            return success;
        }

        [HttpDelete("DeleteAppointment/{id}")]
        public ActionResult<bool> DeleteAppointment(int id)
        {
            var success = _dataAccess.DeleteAppointment(id);            
            return new ActionResult<bool>(success);
        }
    }
}
