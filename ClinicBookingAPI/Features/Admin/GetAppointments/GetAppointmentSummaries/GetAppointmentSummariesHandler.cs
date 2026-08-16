using System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingAPI;

public sealed class GetAppointmentSummariesHandler : IRequestHandler<GetAppointmentSummariesQuery, List<GetAppointmentSummariesResponse>>
{
    private readonly AppointmentsDbContext _context;

    public GetAppointmentSummariesHandler(AppointmentsDbContext context)
    {
        _context = context;
    }


    public async Task<List<GetAppointmentSummariesResponse>> Handle(GetAppointmentSummariesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Appointments.AsNoTracking().AsQueryable();

        if(request.Date.HasValue)
        {
            query = query.Where(a => a.Date == request.Date.Value);
        }
        else if(request.Month.HasValue && request.Year.HasValue)
        {
            query = query.Where(a => a.Date.Month == request.Month.Value && a.Date.Year == request.Year.Value);
        }

        var appointments = await query.OrderBy(a => a.Date)
            .ThenBy(a => a.StartTime)
            .Skip(request.Skip)
            .Take(request.Take)
            .Select(a => new GetAppointmentSummariesResponse(
                a.Id,
                a.Name,
                a.Age,
                a.Condition,
                a.Date,
                a.StartTime,
                a.EndTime
            )).ToListAsync(cancellationToken);

        return appointments;
    }
}
