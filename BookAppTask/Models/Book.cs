using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAppTask.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }

        [DisplayName("Category Name")]
        public string CategoryId { get; set; }

        [DisplayName("Genre Name")]
        public string GenreId { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public string ISBN { get; set; }

        [DisplayName("Image-Link")]
        public string ImageLink { get; set; }

        [DisplayName("Page Number")]
        public int NumberOfPages { get; set; }

        [DisplayName("Library Add Date")]
        public DateTime? LibraryAddDate { get; set; } = DateTime.Now;

        [DisplayName("Published Date")]
        public DateTime? PublishedDate { get; set; }

        [DisplayName("Copies in Library")]
        public int CopiesInLibrary { get; set; }

        [DisplayName("Copies out of Library")]
        public int CopiesOutLibrary { get; set; }

        [DisplayName("Available Copies")]
        public int AvailableCopies { get; set; }
        public bool E_Version { get; set; }

        [ForeignKey("GenreId")]
        [ValidateNever]
        public Genre? Genre { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category? Category { get; set; }
    }

}
