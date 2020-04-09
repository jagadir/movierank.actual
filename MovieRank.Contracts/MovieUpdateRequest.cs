using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRank.Contracts
{
    public class MovieUpdateRequest
    {
        public string MovieName { get; set; }
        public int Ranking { get; set; }
    }
}
