using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAppTask.Models
{
    public class Review : BaseEntity
    {
        [DisplayName("Book Name")]
        public string BookId { get; set; }

        [DisplayName("Your Name")]
        public string ReviewerName { get; set; }

        [DisplayName("Review Title")]
        public string ReviewTitle { get; set; }
        public string Comment { get; set; }

        [ForeignKey(nameof(BookId))]
        [ValidateNever]
        public Book Book { get; set; }
    }
}
