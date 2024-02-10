using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Modify_Segment_Position(
        IGlobal_Vals _globalVals,
        ISegmentsCollection _segments) : IModify_Segment_Position
    {
        private readonly int _max = _globalVals.Max_Dimension;
        private readonly int radius = _globalVals.Scope_Radius;
        public bool New_Segment_Position(TravelersModel travelersModel)
        {
            int x, y, map_y, map_x;
            char[][] map = travelersModel.Map_Full_Dimension;

            x = travelersModel.X_axis;
            y = travelersModel.Y_axis;
            map_y = travelersModel.Map_Y_axis_Position;
            map_x = travelersModel.Map_X_axis_Position;

            switch (_globalVals.Direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:
                    if (x < radius) return false;
                    map_y = ((map_y + 1) + _max) % _max;
                    break;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    if (y < radius) return false;
                    map_x = ((map_x - 1) + _max) % _max;
                    break;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    if (x < radius) return false;
                    map_y = ((map_y - 1) + _max) % _max;
                    break;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    if (y < radius) return false;
                    map_x = ((map_x + 1) + _max) % _max;
                    break;
                default: return false;
            }

            int Hx = travelersModel.Head_X_axis_Position;
            int Hy = travelersModel.Head_Y_axis_Position;

            _segments.Get_Segment_Location(_globalVals.Tail.ToString(),out int segment_map_y, out int segment_map_x);

            int loopCount = 0;
            while (_globalVals.Segment_Count > loopCount)
            {
                string newSegment = _globalVals.Segment.ToString() + loopCount;

                //if (_segments.CointainsKey(newSegment))
                    map[map_y][map_x] = _globalVals.Segment;

                _segments.Add_Segment_Location_To_Collection(newSegment, map_y, map_x);

                switch (_globalVals.Direction)
                {
                    case EnumsFactory.EnumsFactory.Direction.Up:
                        map_y = (map_y + 1) % _max;
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Right:
                        map_x = (map_x - 1) % _max;
                        if (map_x < 0) map_x += _max;
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Down:
                        map_y = (map_y - 1) % _max;
                        if (map_y < 0) map_y += _max;
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Left:
                        map_x = (map_x + 1) % _max;
                        break;
                }

                loopCount++;
            }

            map[map_y][map_x] = _globalVals.Tail;

            _segments.Add_Segment_Location_To_Collection(_globalVals.Tail.ToString(), map_y, map_x);

            return true;
        }
    }
}
