using System;
using MediatR;

namespace ClinicBookingAPI;

public static class GetAppointmentSummariesEndpoint
{
    public static IEndpointRouteBuilder MapGetAppointmentSummariesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/appointments", async (
            DateOnly? date,
            int? month,
            int? year,
            int skip,
            int take,
            ISender mediatr) =>
        {
            var query = new GetAppointmentSummariesQuery(date, month, year, skip, take);

            var response = await mediatr.Send(query);

            return Results.Ok(response);

        });

        return endpoints;
    }
}
