using System;
using MediatR;

namespace ClinicBookingAPI;

public static class CreateAppointmentEndpoint
{
    public static IEndpointRouteBuilder MapCreateAppointmentEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/appointments/", async (CreateAppointmentCommand command, ISender mediatr) =>
        {
            CreateAppointmentResponse response = await mediatr.Send(command);

            return Results.Created($"/api/appointments/{response.Id}", response);
        });
        return endpoints;
    }
}
