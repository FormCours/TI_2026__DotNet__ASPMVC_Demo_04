using System.ComponentModel;

namespace DemoCinema.WebApp.Models
{
    public class MovieViewModel
    {
        [DisplayName("Identifiant")]
        public required int Id { get; set; }
        [DisplayName("Titre")]
        public required string Title { get; set; }
        [DisplayName("Date de sortie")]
        public required DateOnly ReleaseDate { get; set; }
        [DisplayName("Réalisateur")]
        public required string Director { get; set; }
        [DisplayName("Genres")]
        public required List<string> Genres { get; set; }
        [DisplayName("Description")]
        public required string Desc { get; set; }
        [DisplayName("Avis")]
        public required int Rating { get; set; } /* 0 - 10 */
    }
}
