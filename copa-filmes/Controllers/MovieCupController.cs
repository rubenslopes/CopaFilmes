using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace copa_filmes.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MovieCupController : ControllerBase
  {
    private readonly MovieCupBusiness _movieCupBusiness;

    public MovieCupController()
    {
      _movieCupBusiness = new MovieCupBusiness();
    }

    [HttpPost]
    public IEnumerable<string> PostAsync(ICollection<Movie> competitors) =>
      _movieCupBusiness.RunCup(competitors);
  }
}
