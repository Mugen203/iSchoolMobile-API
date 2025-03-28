namespace iSchool_Solution.Features.Research.Delete;

public class Models
{
    /// <summary>
    /// Request model for deleting a research document
    /// </summary>
    public class DeleteResearchDocumentRequest
    {
        public int DocumentID { get; set; }
    }
    
    /// <summary>
    /// Request model for deleting a research project
    /// </summary>
    public class DeleteResearchProjectRequest
    {
        public int ProjectID { get; set; }
    }
    
    /// <summary>
    /// Generic response for deletion operations
    /// </summary>
    public class DeleteResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}