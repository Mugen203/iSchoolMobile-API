using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Dashboard.Models;

namespace iSchool_Solution.Features.Dashboard;

[Authorize]
public class Endpoint : EndpointWithoutRequest<DashboardSummaryResponse>
{
    private readonly DashboardService _dashboardService;

    public Endpoint(DashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }
    
    public override void Configure()
    {
        Get("/students/{studentID}/dashboard");
        Roles("Student");
        Description(description => description
            .WithName("GetStudentDashboard")
            .WithSummary("Gets a student's dashboard information")
            .WithTags("Dashboard")
            .Produces<DashboardSummaryResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentID = Route<string>("studentID");
        
        try
        {
            if (studentID != null)
            {
                var dashboardSummary = await _dashboardService.GetDashboardSummaryAsync(studentID);
                await SendOkAsync(dashboardSummary, cancellation: cancellationToken);
            }
        }
        catch (StudentNotFoundException ex)
        {
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status404NotFound, cancellation: cancellationToken);
        }
        catch (Exception ex)
        {
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellation: cancellationToken);
        }
    }
}