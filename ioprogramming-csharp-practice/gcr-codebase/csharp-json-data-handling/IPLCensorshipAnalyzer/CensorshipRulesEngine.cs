using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IPLCensorshipAnalyzer.Services
{
    public class CensorshipRulesEngine
    {
        private readonly List<string> _teamsToCensor;

        public CensorshipRulesEngine()
        {
            _teamsToCensor = new List<string>
            {
                "Mumbai Indians",
                "Chennai Super Kings",
                "Royal Challengers Bangalore",
                "Delhi Capitals",
                "Kolkata Knight Riders",
                "Rajasthan Royals",
                "Punjab Kings",
                "Sunrisers Hyderabad"
            };
        }

        public string CensorTeamName(string originalTeamName)
        {
            if (string.IsNullOrEmpty(originalTeamName))
                return originalTeamName;

            foreach (var teamName in _teamsToCensor)
            {
                if (originalTeamName.Equals(teamName, StringComparison.OrdinalIgnoreCase))
                {
                    var words = teamName.Split(' ');
                    if (words.Length > 1)
                    {
                        return words[0] + " ***";
                    }
                    return "*** " + words[0];
                }
            }

            return originalTeamName;
        }

        public string RedactPlayerName(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
                return playerName;

            return "REDACTED";
        }

        public bool ShouldCensorTeam(string teamName)
        {
            return _teamsToCensor.Contains(teamName, StringComparer.OrdinalIgnoreCase);
        }
    }
}
