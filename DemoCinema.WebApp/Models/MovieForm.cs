using System.ComponentModel.DataAnnotations;

namespace DemoCinema.WebApp.Models
{
    public class MovieForm
    {
        [Required]
        public required string Title { get; set; }

        [Required]
        public required DateOnly ReleaseDate { get; set; } /* Merci Julian C. */

        [Required, MinLength(2)]
        public required string DirectorFirstName { get; set; }

        [Required, MinLength(2)]
        public required string DirectorLastName { get; set; }

        [Required]
        public required List<string> Genres { get; set; }

        [MaxLength(4_000)]
        public required string? Desc { get; set; }

        [Required, Range(0, 10)]
        public required int Rating { get; set; } /* 0 - 10 */
    }
}
