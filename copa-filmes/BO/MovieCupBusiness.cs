using System.Collections.Generic;

namespace copa_filmes
{
  public class MovieCupBusiness
  {
    public MovieCupBusiness() { }

    public IEnumerable<string> RunCup(ICollection<Movie> competitors) =>
      new MovieCup(competitors).Podium;
  }
}