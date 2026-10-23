using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoCinema.WebApp.Models
{
    public class MovieForm
    {
        // Utilisation du Scaffolding
        // → Du à un bug (ou feature) de l'outils de génération, il est necessaire d'ajouter une propriété "Id" pour créer la vue, même si celui-ci n'est pas utilisé dans le template "Create".
        public int id { get; set; }

        [Required(ErrorMessage ="Le titre du film est requis")]
        [DisplayName("Titre")]
        public required string Title { get; set; }

        [Required(ErrorMessage ="La date de sortie est requise")]
        [DataType(DataType.Date,ErrorMessage ="La date est invalide")]
        [DisplayName("Date de Sortie")]
        public required DateOnly ReleaseDate { get; set; } /* Merci Julian C. */

        [Required(ErrorMessage = "Le Prénom du réalisateur est requis")]
        [MinLength(2, ErrorMessage = "Le Prénom doit contenir au moins 2 caractères")]
        [DisplayName("Prénom du Réalisateur")]
        public required string DirectorFirstName { get; set; }

        [Required(ErrorMessage ="Le nom du réalisateur est requis")]
        [MinLength(2, ErrorMessage ="Le nom doit contenir au moins 2 caractères")]
        [DisplayName("Nom du Réalisateur")]
        public required string DirectorLastName { get; set; }

        [Required]
        [DisplayName("Genres du film (max 5)")]
        public required List<string> Genres { get; set; }

        [MaxLength(4_000,ErrorMessage ="La description est trop longue")]
        [DisplayName("Description")]
        public required string? Desc { get; set; }

        [Required(ErrorMessage ="L'avis est requis")]
        [Range(0, 10, ErrorMessage = "L'avis doit être compris entre 0 et 10")]
        [DisplayName("Avis (0 à 10)")]
        public required int Rating { get; set; } /* 0 - 10 */
    }
}
