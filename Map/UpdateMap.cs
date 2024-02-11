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
    internal class UpdateMap(
        IGlobal_Vals _globalVals,
        IModify_Segment_Position _move_Segment,
        INavigate _moveHead) : IUpdateMap
    {
        public bool UpdateMapPosition(TravelersModel travelersModel)
        {
            if (travelersModel.IsHead_Position)
                if (!_moveHead.Update_Head_Position(travelersModel)) return false;

            if (travelersModel.Should_Set_To_Empty_Field)
                travelersModel.Set_Value_To_Map = _globalVals.Open_Space;

            return true;
        }
    }
}
