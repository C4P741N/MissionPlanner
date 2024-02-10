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
            int map_y, map_x, segmentCount;
            char[][] map = travelersModel.Map_Full_Dimension;

            map_y = travelersModel.Map_Y_axis_Position;
            map_x = travelersModel.Map_X_axis_Position;

            segmentCount = _globalVals.Segment_Count;


            int loopCount = 0;
            while (segmentCount > loopCount)
            {
                string newSegment = _globalVals.Segment.ToString() + loopCount;

                GetSegmentPosition(travelersModel, _globalVals.Segment, map, ref map_y, ref map_x, newSegment);

                loopCount++;
            }

            GetSegmentPosition(travelersModel, _globalVals.Tail, map, ref map_y, ref map_x);

            return true;
        }
        public void GetSegmentPosition(
            TravelersModel travelersModel,
            char segment,
            char[][] map,
            ref int map_y,
            ref int map_x,
            string segmentString = "")
        {
            string sgmtString = segmentString == "" ? segment.ToString() : segmentString;

            _segments.Get_Segment_Location(sgmtString, out int tail_map_y, out int tail_map_x);

            bool correctPosition = _correcter.ShouldCorrect(travelersModel, tail_map_y, tail_map_x);

            switch (_globalVals.Direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:
                    if (correctPosition)
                        map_y = ((map_y + 1) + _max) % _max;
                    else
                    {
                        map_y = (tail_map_y + _max) % _max;
                        map_x = (tail_map_x + _max) % _max;
                    }
                    break;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    if (correctPosition)
                        map_x = ((map_x - 1) + _max) % _max;
                    else
                    {
                        map_y = (tail_map_y + _max) % _max;
                        map_x = (tail_map_x + _max) % _max;
                    }
                    break;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    if (correctPosition)
                        map_y = ((map_y - 1) + _max) % _max;
                    else
                    {
                        map_y = (tail_map_y + _max) % _max;
                        map_x = (tail_map_x + _max) % _max;
                    }
                    break;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    if (correctPosition)
                        map_x = ((map_x + 1) + _max) % _max;
                    else
                    {
                        map_y = (tail_map_y + _max) % _max;
                        map_x = (tail_map_x + _max) % _max;
                    }
                    break;
                default: return;
            }

            map[map_y][map_x] = segment;

            travelersModel.Map_Y_axis_Position = map_y;
            travelersModel.Map_X_axis_Position = map_x;

            _segments.Add_Segment_Location_To_Collection(sgmtString, map_y, map_x);
        }
    }
}
