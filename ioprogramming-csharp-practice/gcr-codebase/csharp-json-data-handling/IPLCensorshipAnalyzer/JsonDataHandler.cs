using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using IPLCensorshipAnalyzer.Models;

namespace IPLCensorshipAnalyzer.Services
{
    public class JsonDataHandler
    {
        private readonly CensorshipRulesEngine _censorshipEngine;

        public JsonDataHandler(CensorshipRulesEngine censorshipEngine)
        {
            _censorshipEngine = censorshipEngine;
        }

        public List<MatchRecord> LoadMatchesFromJson(string jsonFilePath)
        {
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    Console.WriteLine($" JSON file not found: {jsonFilePath}");
                    return new List<MatchRecord>();
                }

                string jsonContent = File.ReadAllText(jsonFilePath);
                List<MatchRecord> matchRecords = JsonConvert.DeserializeObject<List<MatchRecord>>(jsonContent);

                Console.WriteLine($" Loaded {matchRecords.Count} matches from JSON");
                return matchRecords ?? new List<MatchRecord>();
            }
            catch (Exception error)
            {
                Console.WriteLine($" Error reading JSON file: {error.Message}");
                return new List<MatchRecord>();
            }
        }

        public List<MatchRecord> ApplyCensorshipToMatches(List<MatchRecord> matches)
        {
            var censoredMatches = new List<MatchRecord>();

            foreach (var match in matches)
            {
                var censoredMatch = new MatchRecord
                {
                    MatchId = match.MatchId,
                    HomeTeam = _censorshipEngine.CensorTeamName(match.HomeTeam),
                    AwayTeam = _censorshipEngine.CensorTeamName(match.AwayTeam),
                    WinningTeam = _censorshipEngine.CensorTeamName(match.WinningTeam),
                    StarPlayer = _censorshipEngine.RedactPlayerName(match.StarPlayer)
                };

                foreach (var scoreEntry in match.FinalScores)
                {
                    string censoredTeamName = _censorshipEngine.CensorTeamName(scoreEntry.Key);
                    censoredMatch.FinalScores[censoredTeamName] = scoreEntry.Value;
                }

                censoredMatches.Add(censoredMatch);
            }

            return censoredMatches;
        }

        public bool SaveMatchesToJson(List<MatchRecord> matches, string outputPath)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                
                string jsonOutput = JsonConvert.SerializeObject(matches, Formatting.Indented);
                File.WriteAllText(outputPath, jsonOutput);

                Console.WriteLine($" Censored JSON saved to: {outputPath}");
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine($" Error saving JSON file: {error.Message}");
                return false;
            }
        }
    }
}
