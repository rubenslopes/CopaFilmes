using System;
using Xunit;
using copa_filmes;
using System.Collections.Generic;
using System.Collections;

namespace CopaFilmes.Tests
{
  public class MatchTests
  {
    public class MatchTestData : IEnumerable<object[]>
    {
      public IEnumerator<object[]> GetEnumerator()
      {
        yield return new object[] { new Match(new [] {
          new Movie() { Score = 9, Title = "B" },
          new Movie() { Score = 7, Title = "A" },
        }), "B" };
        yield return new object[] { new Match(new [] {
          new Movie() { Score = 7, Title = "B" },
          new Movie() { Score = 7, Title = "A" },
        }), "A" };
        yield return new object[] { new Match(new [] {
          new Movie() { Score = 9, Title = "E" },
          new Movie() { Score = 9, Title = "C" },
        }), "C" };
      }

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory]
    [ClassData(typeof(MatchTestData))]
    public void Higher_score_is_winner_then_alphabetical_order(Match match, string expected)
    {
      Assert.Equal(expected, match.Winner.Title);
    }
  }
}
