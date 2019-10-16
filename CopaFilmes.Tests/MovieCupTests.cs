using System;
using Xunit;
using copa_filmes;
using System.Collections.Generic;

namespace CopaFilmes.Tests
{
  public class MovieCupTests
  {
    [Fact]
    public void Competitors_must_be_alphabetically_ordered()
    {
      var competitors = new List<Movie>()
      {
        new Movie() { Title = "Os Incríveis 2" },
        new Movie() { Title = "Jurassic World: Reino Ameaçado" },
        new Movie() { Title = "Oito Mulheres e um Segredo" },
        new Movie() { Title = "Hereditário" },
        new Movie() { Title = "Vingadores: Guerra Infinita" },
        new Movie() { Title = "Deadpool 2" },
        new Movie() { Title = "Han Solo: Uma História Star Wars" },
        new Movie() { Title = "Thor: Ragnarok" },
      };

      var movieCup = new MovieCup(competitors);

      Assert.Collection(
        movieCup.Competitors,
        e => Assert.Equal("Deadpool 2", e.Title),
        e => Assert.Equal("Han Solo: Uma História Star Wars", e.Title),
        e => Assert.Equal("Hereditário", e.Title),
        e => Assert.Equal("Jurassic World: Reino Ameaçado", e.Title),
        e => Assert.Equal("Oito Mulheres e um Segredo", e.Title),
        e => Assert.Equal("Os Incríveis 2", e.Title),
        e => Assert.Equal("Thor: Ragnarok", e.Title),
        e => Assert.Equal("Vingadores: Guerra Infinita", e.Title)
      );
    }

    [Fact]
    public void Compute_Winner()
    {
      var competitors = new List<Movie>()
      {
        new Movie() { Score=8.5M, Title = "Os Incríveis 2" },
        new Movie() { Score=6.7M, Title = "Jurassic World: Reino Ameaçado" },
        new Movie() { Score=6.3M, Title = "Oito Mulheres e um Segredo" },
        new Movie() { Score=7.8M, Title = "Hereditário" },
        new Movie() { Score=8.8M, Title = "Vingadores: Guerra Infinita" },
        new Movie() { Score=8.1M, Title = "Deadpool 2" },
        new Movie() { Score=7.2M, Title = "Han Solo: Uma História Star Wars" },
        new Movie() { Score=7.9M, Title = "Thor: Ragnarok" },
      };

      Assert.Equal("Vingadores: Guerra Infinita", new MovieCup(competitors).Final.Winner.Title);
    }
  }
}
