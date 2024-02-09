using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Move_Caterpillar(IGlobal_Vals globalVals)
    {
        private readonly IGlobal_Vals _globalVals = globalVals;
        private readonly Radar_Scope _radar_Scope = new (globalVals);
        private readonly Move_Segment _move_Segment = new (globalVals);
        private readonly DisplayRadarMap _displayRadar = new(globalVals);
        private readonly ModifySegmentsCollection _modifySegments = new(globalVals);
        private readonly UpdateMap updateMap = new(globalVals);
        public  bool New_Head_N_Segments_Position(TravelersModel travelersModel)
        {
            Console.Clear();
            travelersModel.IsTail_Already_Init = false;

            _radar_Scope.Generate_Scanned_Sections(travelersModel);
            _globalVals.Body_Parts_Position.Clear();

            for (int y = 0; y < _globalVals.Scope_Diameter; y++)
            {
                travelersModel.Y_axis = y;
                for (int x = 0; x < _globalVals.Scope_Diameter; x++)
                {
                    travelersModel.X_axis = x;

                    if(!updateMap.UpdateMapPosition(travelersModel)) return false;
                }
            }

            _displayRadar.DisplayRadarSection(travelersModel);

            return true;
        }
    }
}
