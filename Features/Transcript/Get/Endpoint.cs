using FastEndpoints;
using iSchool_Solution.Exceptions;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.Authorization;
using static iSchool_Solution.Features.Transcript.Get.Models;

namespace iSchool_Solution.Features.Transcript.Get;

[Authorize]
public class Endpoint : EndpointWithoutRequest<TranscriptSummaryResponse>
{
    private readonly StudentService _studentService;

    public Endpoint(StudentService studentService)
    {
        _studentService = studentService;
    }

    public override void Configure()
    {
        Get("/students/{studentID}/transcript/");
        Roles("Student");
        Description(description => description
            .Produces<TranscriptSummaryResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status404NotFound)
        );
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var studentID = Route<string>("studentID");
        if (string.IsNullOrEmpty(studentID)) throw new StudentNotFoundException(studentID ?? string.Empty);

        try
        {
            var transcriptSummary = await _studentService.GetStudentTranscriptAsync(studentID);
            await SendOkAsync(transcriptSummary, cancellationToken);
        }
        catch (TranscriptNotFoundException ex)
        {
           AddError(ex.Message);
           await SendErrorsAsync(StatusCodes.Status404NotFound, cancellationToken);
        }
        catch (Exception ex)
        {
            AddError(ex.Message);
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, cancellationToken);
        }
    }
}