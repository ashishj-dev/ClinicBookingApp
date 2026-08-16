using System;

namespace ClinicBookingAPI;

public sealed record GetAppointmentDetailsResponse(

    Guid Id,
    string Name,
    int Age,
    GenderType Sex,
    string Condition,
    string Treatment,
    string Reference ,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    int DurationInMinutes,
    decimal Amount,
    string BillNumber,
    StatusType Status,
    PaymentStatusType PaymentStatus
);

