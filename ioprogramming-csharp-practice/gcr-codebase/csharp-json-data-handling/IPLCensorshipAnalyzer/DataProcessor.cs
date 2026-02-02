using System;
using System.Collections.Generic;
using IPLCensorshipAnalyzer.Models;

namespace IPLCensorshipAnalyzer.Services
{
    public class DataProcessor
    {
        private readonly JsonDataHandler _jsonHandler;
        private readonly CsvDataHandler _csvHandler;
        private readonly CensorshipRulesEngine _censorshipEngine;

        public DataProcessor(JsonDataHandler jsonHandler, CsvDataHandler csvHandler, CensorshipRulesEngine censorshipEngine)
        {
            _jsonHandler = jsonHandler;
            _csvHandler = csvHandler;
            _censorshipEngine = censorshipEngine;
        }

        public void ProcessAllData(string inputFolder, string outputFolder)
        {
            Console.WriteLine("");
            Console.WriteLine("  IPL Censorship Analyzer is starting");
            Console.WriteLine("\n");

            string inputJsonPath = System.IO.Path.Combine(inputFolder, "ipl_matches.json");
            string outputJsonPath = System.IO.Path.Combine(outputFolder, "ipl_matches_censored.json");

            var jsonMatches = _jsonHandler.LoadMatchesFromJson(inputJsonPath);
            if (jsonMatches.Count > 0)
            {
                var censoredJsonMatches = _jsonHandler.ApplyCensorshipToMatches(jsonMatches);
                _jsonHandler.SaveMatchesToJson(censoredJsonMatches, outputJsonPath);
                DisplayMatchStats(censoredJsonMatches, "JSON");
            }

            Console.WriteLine();
            string inputCsvPath = System.IO.Path.Combine(inputFolder, "ipl_matches.csv");
            string outputCsvPath = System.IO.Path.Combine(outputFolder, "ipl_matches_censored.csv");

            var csvMatches = _csvHandler.LoadMatchesFromCsv(inputCsvPath);
            if (csvMatches.Count > 0)
            {
                var censoredCsvMatches = _jsonHandler.ApplyCensorshipToMatches(csvMatches);
                _csvHandler.SaveMatchesToCsv(censoredCsvMatches, outputCsvPath);
                DisplayMatchStats(censoredCsvMatches, "CSV");
            }

            Console.WriteLine("");
            Console.WriteLine("Processing Complete");
            Console.WriteLine("");
        }

        private void DisplayMatchStats(List<MatchRecord> matches, string sourceFormat)
        {
            Console.WriteLine($"\n📊 {sourceFormat} Processing Summary:");
            Console.WriteLine($"   Total matches processed: {matches.Count}");

            if (matches.Count > 0)
            {
                Console.WriteLine($"\n   Sample censored match:");
                var sampleMatch = matches[0];
                Console.WriteLine($"   Match ID: {sampleMatch.MatchId}");
                Console.WriteLine($"   Teams: {sampleMatch.HomeTeam} vs {sampleMatch.AwayTeam}");
                Console.WriteLine($"   Winner: {sampleMatch.WinningTeam}");
                Console.WriteLine($"   Player of Match: {sampleMatch.StarPlayer}");
            }
        }
    }
}
