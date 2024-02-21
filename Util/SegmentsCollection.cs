using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Util
{
    internal class SegmentsCollection(IGlobal_Vals _globalVals) : ISegmentsCollection
    {
        public bool CointainsKey(string segment)
        {
            return _globalVals.Body_Parts_Position.ContainsKey(segment);
        }
        public void Get_Stored_Segment_Location(
            string segment,
            out int map_y,
            out int map_x)
        {
            map_y = 0;
            map_x = 0; // Initialize the out parameters in case the segment is not found

            if (_globalVals.Body_Parts_Position.TryGetValue(segment, out var coordinates))
            {
                map_y = coordinates.Item1;
                map_x = coordinates.Item2;
            }
        }
        public void Add_Segment_Location_To_Collection(
            string label,
            int map_y,
            int map_x)
        {
            Add(map_y, map_x, label);
        }
        public void Add_Segment_Location_To_Collection(
            TravelersModel travelersModel, 
            string label)
        {
            Add(travelersModel.Map_Y_axis_Position, travelersModel.Map_X_axis_Position, label);
        }
        public void Add_Segment_Location_To_Collection(TravelersModel travelersModel)
        {
            Add(travelersModel.Map_Y_axis_Position, travelersModel.Map_X_axis_Position, travelersModel.Position_Value.ToString());
        }
        private void Add(
            int map_y, 
            int map_x,
            string segment)
        {
            if (_globalVals.Body_Parts_Position.ContainsKey(segment))
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
