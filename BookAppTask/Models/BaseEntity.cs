using System.ComponentModel;

namespace BookAppTask.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DisplayName("Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
