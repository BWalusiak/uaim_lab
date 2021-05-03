//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

using ExaminationRoomsSelector.Web.Application.Dtos;

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IData
  {
    public string SearchText
    {
      get { return this.searchText; }
      set
      {
        this.searchText = value;

        this.RaisePropertyChanged( "SearchText" );
      }
    }
    private string searchText;

    public List<MatchDto> NodeList
    {
      get { return this.nodeList; }
      private set
      {
        this.nodeList = value;

        this.RaisePropertyChanged( "NodeList" );
      }
    }
    private List<MatchDto> nodeList = new List<MatchDto>( );

    public MatchDto SelectedNode
    {
      get { return this.selectedNode; }
      set
      {
        this.selectedNode = value;

        this.RaisePropertyChanged( "SelectedNode" );
      }
    }
    private MatchDto selectedNode;
  }
}
