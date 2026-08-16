using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClinicBookingAPI;

public sealed class GetAppointmentDetailsHandler : IRequestHandler<GetAppointmentDetailsQuery, GetAppointmentDetailsResponse>
{
    private readonly AppointmentsDbContext _context;

    public GetAppointmentDetailsHandler(AppointmentsDbContext context)
    {
        _context = context;
    }
    public async Task<GetAppointmentDetailsResponse> Handle(GetAppointmentDetailsQuery request, CancellationToken cancellationToken)
    {
        var response = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == request.id);

        if(response is not null)
        {
                var appointmentDetails = new GetAppointmentDetailsResponse(
                response.Id,
                response.Name,
                response.Age,
                response.Sex,
                response.Condition,
                response.Treatment,
                response.Reference,
                response.Date,
                response.StartTime,
                response.EndTime,
                response.DurationInMinutes,
                response.Amount,
                response.BillNumber,
                response.Status,
                response.PaymentStatus
            );

            return appointmentDetails;
        }
        
        throw new NullReferenceException();

        
    }
}
