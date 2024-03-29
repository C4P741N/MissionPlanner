﻿using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Move_Caterpillar(
        IGlobal_Vals _globalVals,
        IRadar_Scope _radar_Scope,
        IDisplayRadarMap _displayRadar,
        IUpdateMap _updateMap,
        IMap_Co_ordinates _co_ordinates,
        ILogger logger) : IMove_Caterpillar
    {
        public bool New_Head_N_Segments_Position(
            TravelersModel travelersModel,
            EnumsFactory.EnumsFactory.MapCoordinates mapCoordinates)
        {
            int steps = _globalVals.Steps_To_Take;

            while (steps > 0)
            {
                Console.Clear();
                travelersModel.IsTail_Already_Init = false;
                CommandedHeadPosition(travelersModel);
                logger.AddLogCommandsToCollection();

                _radar_Scope.Generate_Scanned_Sections(travelersModel);
                //_globalVals.Body_Parts_Position.Clear();
                travelersModel.Map_Full_Dimension = _co_ordinates.Lets_Look_At_The_Map(mapCoordinates);

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

                steps--;

                Thread.Sleep(500);
            }

            return true;
        }

        public void CommandedHeadPosition(TravelersModel travelersModel)
        {
            int maxDimensions = _globalVals.Max_Dimension;
            int Hy = travelersModel.Head_Y_axis_Position;
            int Hx = travelersModel.Head_X_axis_Position;

            switch (_globalVals.Direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:
                    travelersModel.Head_Y_axis_Position = ((Hy-1)+maxDimensions) % maxDimensions;
                    return;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    travelersModel.Head_X_axis_Position = ((Hx + 1) + maxDimensions) % maxDimensions;
                    return;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    travelersModel.Head_Y_axis_Position = ((Hy+1) + maxDimensions) % maxDimensions; 
                    return;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    travelersModel.Head_X_axis_Position = ((Hx - 1) + maxDimensions) % maxDimensions;
                    return;
            }
        }
    }
}
