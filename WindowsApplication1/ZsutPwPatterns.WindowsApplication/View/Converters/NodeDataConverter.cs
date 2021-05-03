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

namespace ZsutPw.Patterns.WindowsApplication.View
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Windows.UI.Xaml.Data;

  using ZsutPw.Patterns.WindowsApplication.Model;

  public class NodeDataConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      MatchDto nodeData = (MatchDto)value;

      return $"{nodeData.Doctor.Name} - {nodeData.ExaminationRoom.Number}";
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      throw new NotImplementedException( );
    }
  }
}
