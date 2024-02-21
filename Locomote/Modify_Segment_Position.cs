using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Modify_Segment_Position(
        IGlobal_Vals _globalVals,
        ISegmentsCollection _segments,
        ISectionPositionCorrecter _correcter) : IModify_Segment_Position
    {
        private readonly int _max = _globalVals.Max_Dimension;
        private readonly int radius = _globalVals.Scope_Radius;
        public bool New_Segment_Position(TravelersModel travelersModel)
        {
            int map_y, map_x, segmentCount, prev_sgmnt_map_y, prev_sgmnt_map_x;
            char[][] map = travelersModel.Map_Full_Dimension;

            map_y = travelersModel.Map_Y_axis_Position;
            map_x = travelersModel.Map_X_axis_Position;

            prev_sgmnt_map_y = -1;
            prev_sgmnt_map_x = -1;

            segmentCount = _globalVals.Segment_Count;

            var storedDirection = _globalVals.Direction;

            int loopCount = 0;
            while (segmentCount > loopCount)
            {
                string newSegment = _globalVals.Segment.ToString() + loopCount;

                GetSegmentPosition(_globalVals.Segment, map, ref map_y, ref map_x,ref prev_sgmnt_map_y, ref prev_sgmnt_map_x, newSegment);

                loopCount++;
            }

            GetSegmentPosition(_globalVals.Tail, map, ref map_y, ref map_x, ref prev_sgmnt_map_y, ref prev_sgmnt_map_x);

            _globalVals.Direction = storedDirection;

            return true;
        }
        private void GetSegmentPosition(//Create a separate class for this
            char segment,
            char[][] map,
            ref int map_y,
            ref int map_x,
            ref int prev_sgmnt_map_y,
            ref int prev_sgmnt_map_x,
            string segmentString = "")
        {
            bool hasMovedDiagonal = false;
            string sgmtString = segmentString == "" ? segment.ToString() : segmentString;

            _segments.Get_Stored_Segment_Location(sgmtString, out int segment_map_y, out int segment_map_x);

            bool correctPosition = _correcter.ShouldCorrect(map_y, map_x, segment_map_y, segment_map_x);

            //int Hx, Hy;

            //Hy = travelersModel.Head_Y_axis_Position;
            //Hx = travelersModel.Head_X_axis_Position;

            if (prev_sgmnt_map_x >= 0 || prev_sgmnt_map_y >= 0)
            {
                map_x = prev_sgmnt_map_x;
                map_y = prev_sgmnt_map_y;

                if(map_x < segment_map_x)
                {
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Left;
                }
                else if (map_x > segment_map_x)
                {
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Right;
                }
                else if (map_y < segment_map_y)
                {
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Up;
                }
                else if (map_y > segment_map_y)
                {
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Down;
                }

                prev_sgmnt_map_x = -1;
                prev_sgmnt_map_y = -1;
            }
            else
            {
                switch (_globalVals.Direction)
                {
                    case EnumsFactory.EnumsFactory.Direction.Up:
                        if (correctPosition)
                        {
                            map_y = ((map_y + 1) + _max) % _max;
                            hasMovedDiagonal = map_x != segment_map_x && map_y != segment_map_y;
                        }
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Right:
                        if (correctPosition)
                        {
                            map_x = ((map_x - 1) + _max) % _max;
                            hasMovedDiagonal = map_x != segment_map_x && map_y != segment_map_y;
                        }
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Down:
                        if (correctPosition)
                        {
                            map_y = ((map_y - 1) + _max) % _max;
                            hasMovedDiagonal = map_x != segment_map_x && map_y != segment_map_y;
                        }
                        break;
                    case EnumsFactory.EnumsFactory.Direction.Left:
                        if (correctPosition)
                        {
                            map_x = ((map_x + 1) + _max) % _max;
                            hasMovedDiagonal = map_x != segment_map_x && map_y != segment_map_y;
                        }
                        break;
                    default: return;
                }
            }

            if (hasMovedDiagonal)
            {
                prev_sgmnt_map_y = segment_map_y;
                prev_sgmnt_map_x = segment_map_x;
            }

            if (!correctPosition)
            {
                map_y = (segment_map_y + _max) % _max;
                map_x = (segment_map_x + _max) % _max;
            }

            if(map[map_y][map_x]  != _globalVals.Head)
                map[map_y][map_x] = segment;

            //travelersModel.Map_Y_axis_Position = map_y;
            //travelersModel.Map_X_axis_Position = map_x;

            _segments.Add_Segment_Location_To_Collection(sgmtString, map_y, map_x);
        }
    }
}
