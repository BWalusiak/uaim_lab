namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Data;

    public interface IData : INotifyPropertyChanged
    {
        string SearchText { get; set;  }

        List<MatchData> MatchByNumberList { get; set;  }

        List<MatchData> MatchList { get; set;  }

        MatchData SelectedMatch { get; set;  }
    }
}