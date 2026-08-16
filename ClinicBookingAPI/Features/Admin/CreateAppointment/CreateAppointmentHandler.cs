using System;
using MediatR;

namespace ClinicBookingAPI;

public sealed class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentResponse>
{
    private readonly AppointmentsDbContext _context;
    public CreateAppointmentHandler(AppointmentsDbContext context)
    {
        _context = context;
    }
    public async Task<CreateAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = new AppointmentEntity(
            request.Name,
            request.Age,
            request.Sex,
            request.Condition,
            request.Date,
            request.StartTime,
            request.DurationInMinutes
        );

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateAppointmentResponse(
            appointment.Id,
            appointment.Name,
            appointment.Age,
            appointment.Sex,
            appointment.Condition,
            appointment.Treatment,
            appointment.Reference,
            appointment.Date,
            appointment.StartTime,
            appointment.EndTime,
            appointment.DurationInMinutes,
            appointment.Amount,
            appointment.BillNumber,
            appointment.Status,
            appointment.PaymentStatus
        );
    }
}
