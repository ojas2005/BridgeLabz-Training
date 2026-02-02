using System;
using System.Collections.Generic;

namespace IPLCensorshipAnalyzer.Models
{
    public class MatchRecord
    {
        public int MatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public Dictionary<string, int> FinalScores { get; set; }
        public string WinningTeam { get; set; }
        public string StarPlayer { get; set; }

        public MatchRecord()
        {
            FinalScores = new Dictionary<string, int>();
        }

        public override string ToString()
        {
            return $"Match {MatchId}: {HomeTeam} vs {AwayTeam} - Winner: {WinningTeam}, Player: {StarPlayer}";
        }
    }
}
