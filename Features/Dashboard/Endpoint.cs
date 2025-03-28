using System.Security.Claims;
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
    private readonly ILogger<Endpoint> _logger;

    public Endpoint(DashboardService dashboardService, ILogger<Endpoint> logger)
    {
        _dashboardService = dashboardService;
        _logger = logger;
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
        var requestedStudentID = Route<string>("studentID");
        var authenticatedUserID = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _logger.LogInformation(
            "Dashboard requested for StudentID: {RequestedStudentID} by UserID: {AuthenticatedUserID}",
            requestedStudentID, authenticatedUserID);

        if (string.IsNullOrEmpty(requestedStudentID))
        {
            _logger.LogWarning("StudentID missing from route.");
            AddError("StudentID must be provided in the route.");
            await SendErrorsAsync(StatusCodes.Status400BadRequest, cancellationToken);
            return;
        }
        
        if (requestedStudentID != authenticatedUserID &&
            !User.IsInRole("Admin")) // An Admin role can view any dashboard
        {
            _logger.LogWarning(
                "Authorization failed: User {AuthenticatedUserID} attempted to access dashboard for {RequestedStudentID}.",
                authenticatedUserID, requestedStudentID);
            await SendForbiddenAsync(cancellationToken);
            return;
        }

        try
        {
            var dashboardSummary = await _dashboardService.GetDashboardSummaryAsync(requestedStudentID);
            _logger.LogInformation("Successfully retrieved dashboard for StudentID: {RequestedStudentID}",
                requestedStudentID);
            await SendOkAsync(dashboardSummary, cancellationToken);
        }
        catch (StudentNotFoundException ex)
        {
            _logger.LogWarning(ex, "Student not found when retrieving dashboard for StudentID: {RequestedStudentID}",
                requestedStudentID);
            AddError(ex.Message);
            await SendNotFoundAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving dashboard for StudentID: {RequestedStudentID}", requestedStudentID);
            AddError("An unexpected error occurred while retrieving the dashboard.");
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken); 
        }
    }
}