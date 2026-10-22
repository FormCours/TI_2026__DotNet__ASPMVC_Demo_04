using DemoCinema.DAL.Entities;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.DAL.Repositories
{
    public class MovieStaticRepository : IMovieRepository
    {
        #region Static data
        private static List<MovieEntity> _movies = [
            new MovieEntity
            {
                Id = 1,
                Title = "Begotten",
                ReleaseDate = new DateTime(1989, 10, 24),
                Director = "E. Elias|Merhige",
                Genres = ["Horreur", "Expérimental", "Fantasy"],
                Desc = "Une œuvre muette et surréaliste en noir et blanc ultra-contrasté, illustrant la mort de Dieu et la naissance de la Terre-Mère.",
                Rating = 3.5
            },
            new MovieEntity
            {
                Id = 2,
                Title = "L'Empereur Tomate-Cru (Tomato Kechappu Kōtei)",
                ReleaseDate = new DateTime(1971, 01, 01),
                Director = "Shūji|Terayama",
                Genres = ["Expérimental", "Satire", "Drame"],
                Desc = "Un moyen-métrage avant-gardiste japonais où les enfants renversent les adultes et prennent le contrôle de la société.",
                Rating = 4.5
            },
            new MovieEntity
            {
                Id = 3,
                Title = "Le Sang d'un poète",
                ReleaseDate = new DateTime(1932, 01, 20),
                Director = "Jean|Cocteau",
                Genres = ["Avant-garde", "Fantastique"],
                Desc = "Le premier film de Cocteau. Un voyage onirique à travers l'esprit d'un artiste, un miroir traversé et des statues qui parlent.",
                Rating = 2
            },
            new MovieEntity
            {
                Id = 4,
                Title = "La Cicatrice de la vieille dette (Aranyer Din Ratri)",
                ReleaseDate = new DateTime(1970, 04, 15),
                Director = "Satyajit|Ray",
                Genres = ["Drame"],
                Desc = "Quatre citadins de Calcutta partent se perdre dans une forêt tribale pour fuir la modernité. Un chef-d'œuvre méconnu du cinéma bengali.",
                Rating = 4
            },
            new MovieEntity
            {
                Id = 5,
                Title = "Decoder",
                ReleaseDate = new DateTime(1984, 02, 18),
                Director = "Klaus|Muscha",
                Genres = ["Science-Fiction", "Cyberpunk", "Underground"],
                Desc = "Film ouest-allemand basé sur les écrits de William S. Burroughs. Un hacker découvre que la musique industrielle peut provoquer des émeutes contre le contrôle mental corporatiste.",
                Rating = 1.5
            },
            new MovieEntity
            {
                Id = 6,
                Title = "Monty Python et le Sacré Graal (Monty Python and the Holy Grail)",
                ReleaseDate = new DateTime(1975, 04, 03),
                Director = "Terry|Gilliam",
                Genres = ["Comédie", "Parodie", "Aventure"],
                Desc = "Une parodie burlesque et culte de la quête du Roi Arthur, impliquant des noix de coco, un lapin tueur et des chevaliers qui disent 'Ni !'.",
                Rating = 5
            }
        ];

        private static int _nextId = 7;
        #endregion


        public IEnumerable<MovieEntity> GetAll()
        {
            return _movies.AsReadOnly();
        }

        public MovieEntity? GetById(int id)
        {
            return _movies.SingleOrDefault(m => m.Id == id);
        }

        public int Insert(MovieEntity data)
        {
            MovieEntity movieToAdd = new MovieEntity
            {
                Id = _nextId,
                Title = data.Title,
                Desc = data.Desc.IsWhiteSpace() ? null : data.Desc,
                Director = data.Director,
                Genres = data.Genres,
                Rating = data.Rating,
                ReleaseDate = data.ReleaseDate
            };
            _nextId++;

            _movies.Add(movieToAdd);

            return movieToAdd.Id;
        }
    }
}
