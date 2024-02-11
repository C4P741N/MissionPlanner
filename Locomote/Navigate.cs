using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Navigate(
        IGlobal_Vals _globalVals,
        ISegmentsCollection _segments,
        IResourceCollection _resourceCollection,
        IModify_Segment_Position _move_Segment) : INavigate
    {
        public bool Update_Head_Position(TravelersModel travelersModel)
        {
            if (travelersModel.IsIrreplaceable_Resource)
            {
                if (_globalVals.Segment_Count < 5) _globalVals.Segment_Count++;

                travelersModel.Set_Value_To_Map = _globalVals.Open_Space;
                _resourceCollection.UpdateCollectedResources(travelersModel);
            }
            if (travelersModel.IsObstacle)
            {
                Console.WriteLine("\nYou disintegrated your caterpillar !");
                return false;
            }

            travelersModel.Set_Value_To_Map = _globalVals.Head;
            _segments.Add_Segment_Location_To_Collection(travelersModel);

            travelersModel.Head_Y_axis_Position = travelersModel.Map_Y_axis_Position;
            travelersModel.Head_X_axis_Position = travelersModel.Map_X_axis_Position;

            string tailKey = _globalVals.Tail.ToString();

            if (!_segments.CointainsKey(tailKey))
                _segments.Add_Segment_Location_To_Collection(travelersModel,tailKey);
            else
                travelersModel.IsTail_Already_Init = _move_Segment.New_Segment_Position(travelersModel);

            return true;
        }
    }
}
