using Spice_n_Booster_Gobler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Forward_Command(IGlobal_Vals _globalVals) : IForward_Command
    {
        public bool Move_Forward(
            string direction_command,
            ref int Hy, ref int Hx)
        {
            int steps;//, Hy, Hx;

            //Hy = travelersModel.Head_Y_axis_Position;
            //Hx = travelersModel.Head_X_axis_Position;

            try
            {
                steps = int.Parse(direction_command.Substring(1));

                _globalVals.Steps_To_Take = steps;
            }
            catch (Exception)
            {
                Console.WriteLine("Caterpillar does not understand, try imputing a valid command this time");
                return false;
            }

            switch (direction_command[0])
            {
                case 'U':
                    if (Hy == 0) Hy = 30;

                    Hy -= steps;
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Up;
                    return true;
                case 'R':
                    Hx += steps;
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Right;
                    return true;
                case 'D':
                    Hy += steps;
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Down;
                    return true;
                case 'L':
                    if (Hx == 0) Hx = 30;

                    Hx -= steps;
                    _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Left;
                    return true;
                default:
                    Console.WriteLine("Caterpillar does not understand, try imputing a valid command this time");
                    return false;
            }
        }
    }
}
