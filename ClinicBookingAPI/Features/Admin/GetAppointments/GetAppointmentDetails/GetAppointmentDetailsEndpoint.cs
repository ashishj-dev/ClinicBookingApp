using System;
using MediatR;

namespace ClinicBookingAPI;

public static class GetAppointmentDetailsEndpoint
{
    public static IEndpointRouteBuilder MapGetAppointmentDetailsEndpoint (this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/appointments/{id}", async(Guid id, ISender mediatr)=>
        {
            var query = new GetAppointmentDetailsQuery(id);

            var response = await mediatr.Send(query);

            return Results.Ok(response);
        });

        return endpoints;
    }
}
