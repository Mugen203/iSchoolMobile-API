using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iSchool_Solution.Enums;

namespace iSchool_Solution.Entities;

public class ResourceBorrowing
{
    [Key] public int Id { get; set; }

    [ForeignKey(nameof(LibraryResource))] public int LibraryResourceID { get; set; }

    public LibraryResource Resource { get; set; }

    [ForeignKey(nameof(Student))] public string StudentId { get; set; }

    public ApiUser Student { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public BorrowStatus Status { get; set; }

    public decimal? LateFee { get; set; }

    public string? Notes { get; set; }
}