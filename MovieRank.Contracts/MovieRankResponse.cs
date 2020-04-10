using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRank.Contracts
{
    public class MovieRankResponse
    {
        public string MovieName { get; set; }
        public double OverallRanking { get; set; }
    }
}
