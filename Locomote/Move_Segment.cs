using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Move_Segment(IGlobal_Vals globalVals)
    {
        private readonly IGlobal_Vals _globalVals = globalVals;
        public bool New_Segment_Position(
            int y, int x,
            int map_y, int map_x,
            ref char[][] map,
            ref int segments_map_y,
            ref int segments_map_x,
            ref bool isSegements_Init)
        {
            int _max = _globalVals.Max_Dimension;
            int radius = _globalVals.Scope_Radius;
            var direction = _globalVals.Direction;

            switch (direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:
                    if (x < radius) return false;
                    map_y = (map_y + 2) % _max;
                    break;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    if (y < radius) return false;
                    break;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    if (x < radius) return false;
                    break;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    if (y < radius) return false;
                    map_x = (map_x + 2) % _max;
                    break;
                default: return false;
            }

            int segmentCount = _globalVals.Segment_Count;

            while (segmentCount > 0)
            {
                map[map_y][map_x] = _globalVals.Segment;

                string newSegment = _globalVals.Segment.ToString() + segmentCount;

                if (_globalVals.Body_Parts_Position.ContainsKey(newSegment))
                {
                    _globalVals.Body_Parts_Position[newSegment] = (map_y, map_x);
                }
                else
                {
                    _globalVals.Body_Parts_Position.Add(newSegment, (map_y, map_x));
                }

                switch (direction)
                {
                    case EnumsFactory.EnumsFactory.Direction.Up:
                        map_y = (map_y + 1) % _max;
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Right:
                        map_x = (map_x - 1) % _max;
                        if (map_x < 0) map_x += _max;
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Down:
                        map_y = (map_y -1) % _max;
                        if(map_y < 0) map_y += _max;
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Left:
                        map_x = (map_x + 1) % _max;
                        break;
                }

                segmentCount--;
                isSegements_Init = true;
            }

            segments_map_y = map_y;
            segments_map_x = map_x;

            map[map_y][map_x] = _globalVals.Tail;

            if (_globalVals.Body_Parts_Position.ContainsKey(_globalVals.Tail.ToString()))
            {
                _globalVals.Body_Parts_Position[_globalVals.Tail.ToString()] = (map_y, map_x);
            }
            else
            {
                _globalVals.Body_Parts_Position.Add(_globalVals.Tail.ToString(), (map_y, map_x));
            }

            return true;
        }
    }
}
