using System;
using MediatR;

namespace ClinicBookingAPI;

public sealed record GetAppointmentSummariesQuery( DateOnly? Date, 
    int? Month, 
    int? Year, 
    int Skip, 
    int Take) : IRequest<List<GetAppointmentSummariesResponse>>;


