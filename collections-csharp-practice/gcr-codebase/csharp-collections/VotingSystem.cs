using System;
using System.Collections.Generic;

namespace BridgelabzTraining.csharp_collections
{
    internal class VotingSystem
    {
        private Dictionary<string, int> _voteCounter;
        private List<string> _votingHistory;

        public VotingSystem()
        {
            _voteCounter = new Dictionary<string, int>();
            _votingHistory = new List<string>();
        }

        private void RecordVote(string voter)
        {
            _votingHistory.Add(voter);
            if (_voteCounter.ContainsKey(voter))
                _voteCounter[voter]++;
            else
                _voteCounter[voter] = 1;
        }

        private void DisplaySortedResults()
        {
            SortedDictionary<string, int> orderedResults = new SortedDictionary<string, int>(_voteCounter);
            Console.WriteLine("Voting Results (Alphabetically Sorted):");
            foreach (var entry in orderedResults)
                Console.WriteLine($"{entry.Key}: {entry.Value} votes");
        }

        public static void Main(string[] args)
        {
            VotingSystem system = new VotingSystem();
            system.RecordVote("Alice");
            system.RecordVote("Bob");
            system.RecordVote("Alice");
            system.RecordVote("Charlie");
            system.RecordVote("Bob");
            system.RecordVote("Alice");
            system.DisplaySortedResults();
        }
    }
}
