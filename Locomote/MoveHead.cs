﻿using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class MoveHead(
        IGlobal_Vals _globalVals,
        ISegmentsCollection _modifySegments,
        IResourceCollection resourceCollection) : IMoveHead
    {
        public bool Update_Head_Position(TravelersModel travelersModel)
        {
            if (travelersModel.IsIrreplaceable_Resource)
            {
                travelersModel.Set_Value_To_Map = _globalVals.Open_Space;
                if (_globalVals.Segment_Count < 5) _globalVals.Segment_Count++;

                resourceCollection.Modify(travelersModel);
            }
            if (travelersModel.IsObstacle)
            {
                Console.WriteLine("\nYou disintegrated your caterpillar !");
                return false;
            }
            travelersModel.Set_Value_To_Map = _globalVals.Head;

            //int Hx = travelersModel.Head_X_axis_Position;
            //int Hy = travelersModel.Head_Y_axis_Position;

            //travelersModel.Map_Full_Dimension[Hy][Hx] = _globalVals.Head;

            _modifySegments.Add_Segment_Location_To_Collection(travelersModel);

            return true;
        }
    }
}
