using Calendar.Data;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;

        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAppointment(AppointmentCreate model)
        {
           // if (model.AppointmentDate > DateTime.Now)
            //{
                var entity =
                                new Appointment()
                                {
                                    OwnerID = _userId,
                                    AppointmentDate = model.AppointmentDate,
                                    StartTime = model.StartTime,
                                    EndTime = model.EndTime,
                                    TypeOfAppointment = model.TypeOfAppointment,
                                    AppointmentReason = model.AppointmentReason,
                                    ClientId = model.ClientId,
                                };
                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Appointments.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            //}
            //else
            //{

            //    return false;
            //}
        }



            public IEnumerable<AppointmentListItem> GetAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Appointments
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new AppointmentListItem
                        {
                            AppointmentID = e.AppointmentID,
                            AppointmentDate = e.AppointmentDate,
                            StartTime = e.StartTime,
                            TypeOfAppointment = e.TypeOfAppointment,
                            ClientId = e.ClientId,
                            FirstName = e.Client.FirstName,
                            LastName = e.Client.LastName,
                        }
                    );
                return query.ToArray();
            }
        }

        public AppointmentDetail GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appointments
                        .Single(e => e.AppointmentID == id && e.OwnerID == _userId);
                return
                    new AppointmentDetail
                    {
                        AppointmentID = entity.AppointmentID,
                        AppointmentDate = entity.AppointmentDate,
                        StartTime = entity.StartTime,
                        EndTime = entity.EndTime,
                        TypeOfAppointment = entity.TypeOfAppointment,
                        AppointmentReason = entity.AppointmentReason,
                        ClientId = entity.ClientId,
                        Client = entity.Client
                    };

            }
        }

        public IEnumerable<AppointmentListItem> GetAppointmentsByClientId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Appointments
                    .Where(e => e.OwnerID == _userId && e.ClientId == id)
                    .Select(
                        e =>
                        new AppointmentListItem
                        {
                            AppointmentID = e.AppointmentID,
                            AppointmentDate = e.AppointmentDate,
                            StartTime = e.StartTime,
                            TypeOfAppointment = e.TypeOfAppointment,
                            ClientId = e.ClientId,
                            Client = e.Client,
                            FirstName = e.Client.FirstName,
                            LastName = e.Client.LastName
                        }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Appointments
                    .Single(e => e.AppointmentID == model.AppointmentID && e.OwnerID == _userId);
               
                    entity.AppointmentID = model.AppointmentID;
                    entity.AppointmentDate = model.AppointmentDate;
                    entity.StartTime = model.StartTime;
                    entity.EndTime = model.EndTime;
                    entity.TypeOfAppointment = model.TypeOfAppointment;
                    entity.AppointmentReason = model.AppointmentReason;
                entity.ClientId = model.ClientId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppointment(int appointmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appointments
                        .Single(e => e.AppointmentID == appointmentId && e.OwnerID == _userId);

                ctx.Appointments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
        

