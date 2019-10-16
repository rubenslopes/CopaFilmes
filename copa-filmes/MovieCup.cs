using System;
using System.Collections.Generic;
using System.Linq;

namespace copa_filmes
{
  public class MovieCup
  {
    public MovieCup(ICollection<Movie> competitors)
    {
      if (competitors.Count % 2 != 0)
        throw new Exception("Campeonato de filmes precisa de um número par de competidores");

      if (competitors.Count < 8)
        throw new Exception("Campeonato de filmes precisa de no mínimo 8 competidores");

      this.Competitors = competitors
        .OrderBy(c => c.Title)
        .ToList();
    }

    public ICollection<Movie> Competitors { get; }
    public IEnumerable<Match> QuarterFinals =>
      this.AssembleBracket(this.Competitors);

    public IEnumerable<Match> SemiFinals
    {
      get
      {
        var previousBracketWinners = this.QuarterFinals
          .Select(m => m.Winner)
          .ToList();

        return this.AssembleBracket(previousBracketWinners);
      }
    }

    public Match Final =>
      new Match(this.SemiFinals.Select(m => m.Winner));

    public IEnumerable<string> Podium =>
      this.Final.Result.Select(r => r.Title);

    private IEnumerable<Match> AssembleBracket(ICollection<Movie> competitors)
    {
      var result = new List<Match>();

      for (var i = 0; competitors.Count / 2 > i; i++)
      {
        // Como índice começa em 0 precisamos subtrair 1 do
        // count/length além do índice atual.
        var antagonistic = competitors.Count - i - 1;

        result.Add(new Match(new[] {
          competitors.ElementAt(i),
          competitors.ElementAt(antagonistic)
        }));
      }

      return result;
    }
  }
}