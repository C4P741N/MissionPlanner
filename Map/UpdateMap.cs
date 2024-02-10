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
    internal class UpdateMap(IGlobal_Vals globalVals) : IUpdateMap
    {
        private readonly IGlobal_Vals _globalVals = globalVals;
        private readonly Move_Segment _move_Segment = new(globalVals);
        private readonly MoveHead _moveHead = new(globalVals);
        public bool UpdateMapPosition(TravelersModel travelersModel)
        {
            if (travelersModel.IsOkayToModifyTail_And_Segments)
                travelersModel.IsTail_Already_Init = _move_Segment.New_Segment_Position(travelersModel);

            if (travelersModel.IsHead_Position)
                if (!_moveHead.Update_Head_Position(travelersModel)) return false;

            if (travelersModel.Should_Set_To_Empty_Field)
                travelersModel.Set_Value_To_Map = _globalVals.Open_Space;

            return true;
        }
    }
}
