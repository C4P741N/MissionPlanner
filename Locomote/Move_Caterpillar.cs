using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Move_Caterpillar(
        IGlobal_Vals _globalVals,
        IRadar_Scope _radar_Scope,
        IDisplayRadarMap _displayRadar,
        IUpdateMap _updateMap,
        IMap_Co_ordinates _co_ordinates) : IMove_Caterpillar
    {
        public bool New_Head_N_Segments_Position(TravelersModel travelersModel)
        {
            Console.Clear();
            travelersModel.IsTail_Already_Init = false;

            _radar_Scope.Generate_Scanned_Sections(travelersModel);
            //_globalVals.Body_Parts_Position.Clear();
            travelersModel.Map_Full_Dimension = _co_ordinates.Lets_Look_At_The_Map(EnumsFactory.EnumsFactory.MapCoordinates.Default);

            for (int y = 0; y < _globalVals.Scope_Diameter; y++)
            {
                travelersModel.Y_axis = y;
                for (int x = 0; x < _globalVals.Scope_Diameter; x++)
                {
                    travelersModel.X_axis = x;

                    if (!_updateMap.UpdateMapPosition(travelersModel)) return false;
                }
            }

            _displayRadar.DisplayRadarSection(travelersModel);

            return true;
        }
    }
}
