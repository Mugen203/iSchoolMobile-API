using iSchool_Solution.Repository;
using iSchool_Solution.Enums;
using static iSchool_Solution.Features.Library.BorrowedResources.Models;
using static iSchool_Solution.Features.Library.SearchResources.Models;


namespace iSchool_Solution.Services
{
    public class LibraryService
    {
        private readonly LibraryRepository _libraryRepository;
        private readonly ILogger<LibraryService> _logger;

        public LibraryService(LibraryRepository libraryRepository, ILogger<LibraryService> logger)
        {
            _libraryRepository = libraryRepository;
            _logger = logger;
        }

        public async Task<SearchResourcesResponse> SearchResourcesAsync(SearchResourcesRequest request)
        {
            int skip = (request.Page - 1) * request.PageSize;
            int take = request.PageSize;

            var resources = await _libraryRepository.SearchResourcesAsync(request.Query, request.Category, request.ResourceType, skip, take);
            var totalCount = await _libraryRepository.GetResourceCountAsync(request.Query, request.Category, request.ResourceType);

            var response = new SearchResourcesResponse
            {
                Resources = resources.Select(r => new LibraryResourceSummary
                {
                    Id = r.Id,
                    Title = r.Title,
                    Author = r.Author,
                    Category = r.Category,
                    ResourceType = r.ResourceType,
                    IsAvailable = r.AvailableCopies > 0, // Simple availability check
                    Location = r.Location
                }).ToList(),
                TotalCount = totalCount,
                CurrentPage = request.Page,
                PageSize = request.PageSize,
                TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
            };

            _logger.LogInformation("Found {Count} library resources matching query.", response.Resources.Count);
            return response;
        }

         public async Task<MyBorrowedResourcesResponse> GetStudentBorrowedResourcesAsync(string studentId)
         {
             var borrowedItems = await _libraryRepository.GetBorrowedByStudentAsync(studentId);

             var response = new MyBorrowedResourcesResponse
             {
                 BorrowedItems = borrowedItems.Select(b => new BorrowedResourceInfo
                 {
                     BorrowingId = b.Id,
                     ResourceId = b.LibraryResourceID,
                     Title = b.Resource.Title,
                     Author = b.Resource.Author,
                     BorrowDate = b.BorrowDate,
                     DueDate = b.DueDate,
                     Status = b.Status,
                     ResourceType = b.Resource.ResourceType,
                     LateFee = (b.DueDate < DateTime.UtcNow && b.Status != BorrowStatus.Returned) ? CalculateLateFee(b.DueDate) : (b.LateFee ?? 0m) // Calculate if overdue
                 }).ToList()
             };

             _logger.LogInformation("Retrieved {Count} borrowed items for StudentID: {StudentID}", response.BorrowedItems.Count, studentId);
             return response;
         }

         // Example late fee calculation - adjust as needed
         private decimal CalculateLateFee(DateTime dueDate)
         {
             var daysOverdue = (DateTime.UtcNow - dueDate).Days;
             if (daysOverdue <= 0) return 0m;
             return daysOverdue * 0.50m; // 0.50 GHS per day
         }
    }
}