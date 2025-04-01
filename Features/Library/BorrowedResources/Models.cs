using iSchool_Solution.Enums;

namespace iSchool_Solution.Features.Library.BorrowedResources;

public class Models
{
    // No request model needed, uses authenticated user

    public class MyBorrowedResourcesResponse
    {
        public List<BorrowedResourceInfo> BorrowedItems { get; set; } = [];
    }

    public class BorrowedResourceInfo
    {
        public int BorrowingId { get; set; }
        public int ResourceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public BorrowStatus Status { get; set; }
        public ResourceType ResourceType { get; set; }
        public decimal LateFee { get; set; }
    }
}