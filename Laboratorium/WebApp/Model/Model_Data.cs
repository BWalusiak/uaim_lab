namespace Model
{
    using System.Collections.Generic;
    using Data;

    public partial class Model : IData
    {
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;

                RaisePropertyChanged("SearchText");
            }
        }

        private string _searchText;

        public List<MatchData> MatchByNumberList
        {
            get => _matchDataByNumberList;
            set
            {
                _matchDataByNumberList = value;
                RaisePropertyChanged("MatchByNumberList");
            }
        }

        private List<MatchData> _matchDataByNumberList = new List<MatchData>();

        public List<MatchData> MatchList
        {
            get => _matchList;
            set
            {
                _matchList = value;
                RaisePropertyChanged("MatchList");
            }
        }

        private List<MatchData> _matchList = new List<MatchData>();

        public MatchData SelectedMatch
        {
            get => _selectedMatch;
            set
            {
                _selectedMatch = value;
                RaisePropertyChanged("SelectedMatch");
            }
        }

        private MatchData _selectedMatch = new MatchData();
    }
}