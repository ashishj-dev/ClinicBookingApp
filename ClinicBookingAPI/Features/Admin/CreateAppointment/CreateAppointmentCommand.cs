using System;
using MediatR;

namespace ClinicBookingAPI;

public sealed record CreateAppointmentCommand(
    string Name,
    int Age,
    GenderType Sex,
    string Condition,
    DateOnly Date,
    TimeOnly StartTime,
    int DurationInMinutes
) : IRequest<CreateAppointmentResponse>;
