using System.Collections.Generic;
using System.Linq;

namespace copa_filmes
{
  public class Match
  {
    public Match(IEnumerable<Movie> competitors) =>
      this.Competitors = competitors;
    public IEnumerable<Movie> Competitors { get; }

    // Partida é uma disputa entre dois filmes, onde o filme com maior
    // nota é o vencedor. Caso existam disputas entre filmes com mesma
    // nota o vencedor será definido pela ordem alfabética.
    public IEnumerable<Movie> Result => this.Competitors
      .OrderByDescending(c => c.Score)
      .ThenBy(c => c.Title);

    public Movie Winner => this.Result.First();
    public IEnumerable<Movie> Others => this.Result
      .Skip(1)
      .ToList();
  }
}