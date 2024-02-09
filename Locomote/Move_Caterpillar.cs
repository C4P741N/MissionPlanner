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
        public  bool New_Head_N_Segments_Position(TravelersModel travelersModel)
        {
            Console.Clear();
            int _scope_Radius = _globalVals.Scope_Radius;
            int _max = _globalVals.Max_Dimension;
            travelersModel.Map_Radar_Section = _radar_Scope.Generate_Scanned_Sections(travelersModel.Head_X_axis_Position, travelersModel.Head_Y_axis_Position);
            bool isSegements_Init = false, isTail_Init = false;
            int segment_x=-1, segment_y=-1;
            _globalVals.Body_Parts_Position.Clear();

            char[][] map = travelersModel.Map_Full_Dimension;

            for (int y = 0; y < _globalVals.Scope_Diameter; y++)
            {
                for (int x = 0; x < _globalVals.Scope_Diameter; x++)
                {
                    int map_y = travelersModel.Map_Radar_Section[y, 0, x];
                    int map_x = travelersModel.Map_Radar_Section[y, 1, x];

                    if (map_y < 0) map_y = (map_y + _max) % _max;
                    if (map_x < 0) map_x = (map_x + _max) % _max;

                    bool isHeadPosition = y == _scope_Radius && x == _scope_Radius;

                    char position_value = map[map_y][map_x];

                    if (((y == _scope_Radius-1 && x == _scope_Radius) 
                        || (x == _scope_Radius-1 && y == _scope_Radius))
                        && !isHeadPosition && !isTail_Init)
                    {
                        isTail_Init = _move_Segment.New_Segment_Position(y, x, map_y, map_x, ref map, ref segment_y, ref segment_x, ref isSegements_Init);
                    }

                    if (isHeadPosition)
                    {
                        if (position_value == _globalVals.Booster || position_value == _globalVals.Spice)
                        {
                            map[map_y][map_x] = _globalVals.Open_Space;
                            if(_globalVals.Segment_Count < 5) _globalVals.Segment_Count++;
                        }
                        if (position_value == _globalVals.Obstacle)
                        {
                            Console.WriteLine("\nYou disintegrated your caterpillar !");
                            return false;
                        }
                        map[map_y][map_x] = _globalVals.Head;
                        if (_globalVals.Body_Parts_Position.ContainsKey(_globalVals.Head.ToString()))
                        {
                            _globalVals.Body_Parts_Position[_globalVals.Head.ToString()] = (map_y, map_x);
                        }
                        else
                        {
                            _globalVals.Body_Parts_Position.Add(_globalVals.Head.ToString(), (map_y, map_x));
                        }
                    }

                    if (!_globalVals.Body_Parts_Position.ContainsValue((map_y, map_x))
                        && (position_value == _globalVals.Segment 
                            || position_value == _globalVals.Tail
                            || position_value == _globalVals.Head))
                    {
                        map[map_y][map_x] = _globalVals.Open_Space;
                    }
                }
            }

            _displayRadar.DisplayRadarSection(travelersModel);

            return true;
        }
    }
}
