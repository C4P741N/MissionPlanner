using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Models
{
    internal class TravelersModel(IGlobal_Vals globalVals)
    {
        public int X_axis { get; set; }
        public int Y_axis { get; set; }
        private int new_Map_X_axis_Position = 0;
        public int Map_X_axis_Position
        {
            get
            {
                int xPosition = Map_Radar_Section[Y_axis, 1, X_axis] + new_Map_X_axis_Position;
                new_Map_X_axis_Position = 0;
                return (xPosition + globalVals.Max_Dimension) % globalVals.Max_Dimension;
            }
            set
            {
                new_Map_X_axis_Position = value;
            }
        }
        private int new_Map_Y_axis_Position = 0;
        public int Map_Y_axis_Position
        {
            get
            {
                int yPosition = Map_Radar_Section[Y_axis, 0, X_axis] + new_Map_Y_axis_Position;
                new_Map_Y_axis_Position = 0;
                return (yPosition + globalVals.Max_Dimension) % globalVals.Max_Dimension;
            }
            set
            {
                new_Map_Y_axis_Position = value;
            }
        }
        public int Head_X_axis_Position { get; set; }
        public int Head_Y_axis_Position { get; set; }
        public int Scope_Radius
        {
            get
            {
                return globalVals.Scope_Radius;
            }
        }
        public char[][] Map_Full_Dimension { get; set; } = [];
        public int[,,] Map_Radar_Section { get; set; }
        public char Position_Value
        {
            get
            {
                return Map_Full_Dimension[Map_Y_axis_Position][Map_X_axis_Position];
            }
        }
        public bool IsTail_Already_Init { get; set; }
        public bool IsHead_Position
        {
            get
            {
                return (Y_axis == Scope_Radius && X_axis == Scope_Radius);
            }
        }
        public bool IsOkayToModifyTail_And_Segments
        {
            get
            {
                return ((Y_axis == Scope_Radius - 1 && X_axis == Scope_Radius)
                    || (X_axis == Scope_Radius - 1 && Y_axis == Scope_Radius))
                    && !IsHead_Position && !IsTail_Already_Init;
            }
        }

        public bool IsIrreplaceable_Resource
        {
            get
            {
                return (Position_Value == globalVals.Booster || Position_Value == globalVals.Spice);
            }
        }
        public bool IsObstacle
        {
            get
            {
                return Position_Value == globalVals.Obstacle;
            }
        }
        public bool Should_Set_To_Empty_Field
        {
            get
            {
                //return (!globalVals.Body_Parts_Position.ContainsValue((Map_Y_axis_Position, Map_X_axis_Position))
                //&& (Position_Value == globalVals.Segment
                //    || Position_Value == globalVals.Tail
                //    || Position_Value == globalVals.Head));

                return (globalVals.Irreplaceable_Resources_List.ContainsValue((Map_Y_axis_Position, Map_X_axis_Position)))
                    && (Position_Value == globalVals.Spice || Position_Value == globalVals.Booster);
                //&& (!globalVals.Body_Parts_Position.ContainsValue((Map_Y_axis_Position, Map_X_axis_Position)));
                //&& (Position_Value != globalVals.Segment
                //    && Position_Value != globalVals.Tail
                //    && Position_Value != globalVals.Head));
            }
        }
        public char Set_Value_To_Map
        {
            //get => Full_Map[Map_Y_axis_Position][Map_X_axis_Position];
            set => Map_Full_Dimension[Map_Y_axis_Position][Map_X_axis_Position] = value;
        }
    }
}
