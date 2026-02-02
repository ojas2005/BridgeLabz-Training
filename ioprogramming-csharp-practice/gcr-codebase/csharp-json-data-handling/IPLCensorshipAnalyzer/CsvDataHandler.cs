using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IPLCensorshipAnalyzer.Models;

namespace IPLCensorshipAnalyzer.Services
{
    public class CsvDataHandler
    {
        private readonly CensorshipRulesEngine _censorshipEngine;

        public CsvDataHandler(CensorshipRulesEngine censorshipEngine)
        {
            _censorshipEngine = censorshipEngine;
        }

        public List<MatchRecord> LoadMatchesFromCsv(string csvFilePath)
        {
            var matchList = new List<MatchRecord>();

            try
            {
                if (!File.Exists(csvFilePath))
                {
                    Console.WriteLine($"CSV file not found: {csvFilePath}");
                    return matchList;
                }

                var lines = File.ReadAllLines(csvFilePath);
                if (lines.Length < 2)
                {
                    Console.WriteLine(" CSV file is empty or invalid");
                    return matchList;
                }

                var headers = lines[0].Split(',');
                
                for (int lineNum = 1; lineNum < lines.Length; lineNum++)
                {
                    var values = lines[lineNum].Split(',');
                    
                    if (values.Length < headers.Length)
                        continue;

                    var match = new MatchRecord
                    {
                        MatchId = int.Parse(values[0]),
                        HomeTeam = values[1].Trim(),
                        AwayTeam = values[2].Trim(),
                        WinningTeam = values[5].Trim(),
                        StarPlayer = values[6].Trim()
                    };

                    match.FinalScores[values[1].Trim()] = int.Parse(values[3]);
                    match.FinalScores[values[2].Trim()] = int.Parse(values[4]);

                    matchList.Add(match);
                }

                Console.WriteLine($"Loaded {matchList.Count} matches from CSV");
                return matchList;
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error reading CSV file: {error.Message}");
                return matchList;
            }
        }

        public bool SaveMatchesToCsv(List<MatchRecord> matches, string outputPath)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (var writer = new StreamWriter(outputPath))
                {
                    writer.WriteLine("match_id,team1,team2,score_team1,score_team2,winner,player_of_match");

                    foreach (var match in matches)
                    {
                        string team1 = match.HomeTeam;
                        string team2 = match.AwayTeam;
                        
                        int score1 = match.FinalScores.ContainsKey(team1) ? match.FinalScores[team1] : 0;
                        int score2 = match.FinalScores.ContainsKey(team2) ? match.FinalScores[team2] : 0;

                        var csvLine = $"{match.MatchId},{team1},{team2},{score1},{score2},{match.WinningTeam},{match.StarPlayer}";
                        writer.WriteLine(csvLine);
                    }
                }

                Console.WriteLine($" Censored CSV saved to: {outputPath}");
                return true;
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error saving CSV file: {error.Message}");
                return false;
            }
        }
    }
}
