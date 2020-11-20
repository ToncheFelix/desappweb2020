using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DVDCollection.Models;

namespace DVDCollection.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DVDContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Actors.
            if (context.Actors.Any())
            {
                return;   // DB has been seeded
            }

// Actors
            var actors = new Actor[]
            {
                new Actor { 
                    ActorID = 101,   
                    ActorFullName = "Leonardo DiCaprio",
                    ActorNotes = "Es un actor, productor de cine."},
                new Actor { 
                    ActorID = 102,   
                    ActorFullName = "Katherine Elizabeth Winslet",
                    ActorNotes = "Nacida en una familia de actores."},
                new Actor { 
                    ActorID = 103,   
                    ActorFullName = "Billy Zane ",
                    ActorNotes = "Conocido como Billy Zane, es un actor y director estadounidense."},
                new Actor { 
                    ActorID = 104,   
                    ActorFullName = "Frances Fisher ",
                    ActorNotes = "Ha aparecido en películas como Unforgiven, Titanic, Gone in Sixty Seconds y True Crime (1999)."},
                new Actor { 
                    ActorID = 105,   
                    ActorFullName = "Gloria Stuart ",
                    ActorNotes = "Actriz estadounidense, adquirió reconocimiento internacional por su papel de Rose DeWitt Bukater en la película Titanic (1997)."}   

            };

            foreach (Actor s in actors)
            {
                context.Actors.Add(s);
            }
            context.SaveChanges();

// RoleType 
          
            var roleTypes = new RoleType[]
            {
                new RoleType { 
                    RoleTypeID = 1, 
                    RoleTypes = " Jack Dawson, Principal"},
                new RoleType { 
                    RoleTypeID = 2, 
                    RoleTypes = " Rose DeWitt Bukater, Principal"},
                new RoleType { 
                    RoleTypeID = 3, 
                    RoleTypes = " Caledon Nathan , Secundario"},
                new RoleType { 
                    RoleTypeID = 4, 
                    RoleTypes = " Ruth DeWitt Bukater, Secundario"},
                new RoleType { 
                    RoleTypeID = 5, 
                    RoleTypes = " Rose Dawson (Anciana), Principal"}

            };

            foreach (RoleType i in roleTypes)
            {
                context.RoleTypes.Add(i);
            }
            context.SaveChanges();

// Producers
            var producers = new Producer[]
            {
                new Producer { 
                    ProducerID = 1,
                    ProducerName = "James Cameron",
                    ContactEmailAddress = "JamesCameron@gmail.com",
                    Website = "https://www.imdb.com/name/nm0000116/"                
                    },
                new Producer { 
                    ProducerID = 2,
                    ProducerName = "Jon Landau ",
                    ContactEmailAddress = "JonLa@gmail.com",
                    Website = "https://www.imdb.com/name/nm0484457/"                
                    },
                new Producer { 
                    ProducerID = 3,
                    ProducerName = "Guillermo del Toro",
                    ContactEmailAddress = "RealGDT@gmail.com",
                    Website = "https://deltorofilms.com/"                
                    },
                new Producer { 
                    ProducerID = 4,
                    ProducerName = "Steven S. DeKnight",
                    ContactEmailAddress = "Steven7eKnic@gmail.com",
                    Website = "https://www.imdb.com/name/nm0000116/"                
                    },
            };

            foreach (Producer i in producers)
            {
                context.Producers.Add(i);
            }
            context.SaveChanges();

// FilmCertificate
            var filmCertificates = new FilmCertificate[]
            {
                new FilmCertificate { 
                    CertificateID   = 1,
                    Certificate = "PG-13"
                    },
                new FilmCertificate { 
                    CertificateID   = 2,
                    Certificate = "PG"
                    },
                new FilmCertificate { 
                    CertificateID   = 3,
                    Certificate = "G"
                    },
                new FilmCertificate { 
                    CertificateID   = 4,
                    Certificate = "R"
                    },
                new FilmCertificate { 
                    CertificateID   = 5,
                    Certificate = "NR"
                    }
            };

            foreach (FilmCertificate i in filmCertificates)
            {
                context.FilmCertificates.Add(i);
            }
            context.SaveChanges(); 

// FilmGenres
            var filmGenres = new FilmGenre[]
            {
                new FilmGenre { 
                    GenreID = 1, 
                    Genre = "Drama"            
                    },
                new FilmGenre { 
                    GenreID = 2, 
                    Genre = "Romance"            
                    },
                new FilmGenre { 
                    GenreID = 3, 
                    Genre = "Comedia"            
                    },
                new FilmGenre { 
                    GenreID = 4, 
                    Genre = "Ficción"            
                    },
                new FilmGenre { 
                    GenreID = 5, 
                    Genre = "Acción"            
                    },
                new FilmGenre { 
                    GenreID = 6, 
                    Genre = "Documental"            
                    }
            };

            foreach (FilmGenre i in filmGenres)
            {
                context.FilmGenres.Add(i);
            }
            context.SaveChanges();
// Film Titles         

            var filmTitles = new FilmTitle[]
            {
                new FilmTitle { 
                    FilmTitleID = 10,
                    FilmTitles = "Titanic",
                    FilmStory = "Jack, un joven artista, en una partida de cartas gana un pasaje para América, en el Titanic, el trasatlántico más grande y seguro jamás construido.",
                    FilmReleaseDate = DateTime.Parse("1997-12-19"),
                    FilmDuration    = 195,
                    GenreID = filmGenres.Single(c => c.GenreID == 1).GenreID,
                    CertificateID   = filmCertificates.Single(c => c.CertificateID == 1).CertificateID,
                    FilmAdditionalInfo = "Titanic obtuvo muy buenas críticas tras su estreno."    
                    }
            };

            foreach (FilmTitle i in filmTitles)
            {
                context.FilmTitles.Add(i);
            }
            context.SaveChanges();


// Film Titles Producer
            
            var filmTitlesProducers = new FilmTitlesProducer[]
            {
                new FilmTitlesProducer { 
                    ProducerID = producers.Single(c => c.ProducerID == 1).ProducerID,
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID             
                    },
                new FilmTitlesProducer { 
                    ProducerID = producers.Single(c => c.ProducerID == 2).ProducerID,
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID             
                    },   
                
            };

            foreach (FilmTitlesProducer i in filmTitlesProducers)
            {
                context.FilmTitlesProducers.Add(i);
            }
            context.SaveChanges();

// FilmsActorRoles
            var filmsActorRols = new FilmsActorRol[]
            {
                new FilmsActorRol { 
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID, 
                    ActorID = actors.Single(c => c.ActorID == 101).ActorID,
                    RoleTypeID = roleTypes.Single(c => c.RoleTypeID == 1).RoleTypeID,
                    CharacterName = " Jack Dawson",
                    CharacterDescription = "Un sujeto de Wisconsin de clase baja que ha viajado por varias partes del mundo."
                    },
                new FilmsActorRol { 
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID, 
                    ActorID = actors.Single(c => c.ActorID == 102).ActorID,
                    RoleTypeID = roleTypes.Single(c => c.RoleTypeID == 2).RoleTypeID,
                    CharacterName = "Kate Winslet",
                    CharacterDescription = "Una joven de diecisiete años originaria de Filadelfia."
                    },
                new FilmsActorRol { 
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID, 
                    ActorID = actors.Single(c => c.ActorID == 103).ActorID,
                    RoleTypeID = roleTypes.Single(c => c.RoleTypeID == 3).RoleTypeID,
                    CharacterName = "Billy Zane ",
                    CharacterDescription = "Un adinerado de treinta años de edad, funge como el antagonista de la película."
                    },
                new FilmsActorRol { 
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID, 
                    ActorID = actors.Single(c => c.ActorID == 104).ActorID,
                    RoleTypeID = roleTypes.Single(c => c.RoleTypeID == 4).RoleTypeID,
                    CharacterName = "Ruth DeWitt Bukater ",
                    CharacterDescription = "Desea que su hija contraiga matrimonio con Cal."
                    },
                new FilmsActorRol { 
                    FilmTitleID = filmTitles.Single(c => c.FilmTitleID == 10).FilmTitleID, 
                    ActorID = actors.Single(c => c.ActorID == 105).ActorID,
                    RoleTypeID = roleTypes.Single(c => c.RoleTypeID == 5).RoleTypeID,
                    CharacterName = "Rose Dawson Calvert",
                    CharacterDescription = "La misma protagonista solo que con una edad de 100 años."
                    }    
                    
                
            };

            foreach (FilmsActorRol i in filmsActorRols)
            {
                context.FilmsActorRols.Add(i);
            }
            context.SaveChanges(); 
// --------------------------------------------------------------------------------------------------
        }
    }
}