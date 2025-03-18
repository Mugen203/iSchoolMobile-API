using System.ComponentModel.DataAnnotations;

namespace iSchool_Solution.Entities.DTO.Transcript;

public record RequestTranscriptRequest(
    [Required] bool IsOfficial = true,
    [Required] string Purpose = "",
    [Required] string DeliveryMethod = "",
    string RecipientName = "",
    [EmailAddress] string RecipientEmail = "",
    string MailingAddress = "",
    int Copies = 1,
    string AdditionalInstructions = "",
    bool AcknowledgeFee = false
);