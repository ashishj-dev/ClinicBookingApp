using System;

namespace ClinicBookingAPI;

public sealed record GetAppointmentSummariesResponse(
    Guid Id,
    string Name,
    int Age,
    string Condition,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime
);

