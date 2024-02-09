using Spice_n_Booster_Gobler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Util
{
    internal class ModifySegmentsCollection(IGlobal_Vals global_Vals)
    {
        private readonly IGlobal_Vals _globalVals = global_Vals;
        public void Add_Segment_Location(
            TravelersModel travelersModel, 
            string label)
        {
            int map_y, map_x;

            map_y = travelersModel.Map_Y_axis_Position;
            map_x = travelersModel.Map_X_axis_Position;

            if (_globalVals.Body_Parts_Position.ContainsKey(label))
            {
                _globalVals.Body_Parts_Position[label] = (map_y, map_x);
            }
            else
            {
                _globalVals.Body_Parts_Position.Add(label, (map_y, map_x));
            }
        }
        public void Add_Segment_Location(TravelersModel travelersModel)
        {
            char segment = travelersModel.Position_Value;
            int map_y, map_x;

            map_y = travelersModel.Map_Y_axis_Position;
            map_x = travelersModel.Map_X_axis_Position;

            if (_globalVals.Body_Parts_Position.ContainsKey(segment.ToString()))
            {
                _globalVals.Body_Parts_Position[segment.ToString()] = (map_y, map_x);
            }
            else
            {
                _globalVals.Body_Parts_Position.Add(segment.ToString(), (map_y, map_x));
            }
        }
    }
}
