﻿namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Service;

    public partial class Model : IOperations
    {
        public void LoadMatchesByNumber()
        {
            Task.Run(LoadMatchesByNumberTask);
        }

        private void LoadMatchesByNumberTask()
        {
            var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);

            try
            {
                var matches = networkClient.GetMatches().Where(x => x.ExaminationRoom.Number.Contains(_searchText));
                MatchByNumberList = matches.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadMatches()
        {
            Task.Run(LoadMatchesTask);
        }

        private void LoadMatchesTask()
        {
            var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);

            try
            {
                IEnumerable<MatchData> matches = networkClient.GetMatches();
                MatchList = matches.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}