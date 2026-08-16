using System;
using MediatR;

namespace ClinicBookingAPI;

public sealed record GetAppointmentDetailsQuery(Guid id) : IRequest<GetAppointmentDetailsResponse>;

