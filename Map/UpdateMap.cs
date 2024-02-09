using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Map
{
    internal class UpdateMap(IGlobal_Vals globalVals)
    {
        private readonly IGlobal_Vals _globalVals = globalVals;
        private readonly Move_Segment _move_Segment = new(globalVals);
        private readonly ModifySegmentsCollection _segmentsCollection = new(globalVals);
        private readonly ModifySegmentsCollection _modifySegments = new(globalVals);
        private readonly int _scope_Radius = globalVals.Scope_Radius;
        public bool Update(TravelersModel travelersModel)
        {
            int x, y;

            x = travelersModel.X_axis;
            y = travelersModel.Y_axis;

            if (((y == _scope_Radius - 1 && x == _scope_Radius)
                || (x == _scope_Radius - 1 && y == _scope_Radius))
                && !travelersModel.IsHead_Position && !travelersModel.IsTail_Already_Init)
            {
                travelersModel.IsTail_Already_Init = _move_Segment.New_Segment_Position(travelersModel);
            }

            if (travelersModel.IsHead_Position)
            {
                if (travelersModel.IsIrreplaceable_Resource)
                {
                    travelersModel.Set_Value_To_Map = _globalVals.Open_Space;
                    if (_globalVals.Segment_Count < 5) _globalVals.Segment_Count++;
                }
                if (travelersModel.IsObstacle)
                {
                    Console.WriteLine("\nYou disintegrated your caterpillar !");
                    return false;
                }
                travelersModel.Set_Value_To_Map = _globalVals.Head;

                _modifySegments.Add_Segment_Location_To_Collection(travelersModel);
            }

            if (travelersModel.Should_Set_To_Empty_Field)
            {
                travelersModel.Set_Value_To_Map = _globalVals.Open_Space;
            }

            return true;
        }
    }
}
