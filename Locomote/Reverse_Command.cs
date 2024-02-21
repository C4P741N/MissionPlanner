using Spice_n_Booster_Gobler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Reverse_Command(IGlobal_Vals _globalVals) : IReverse_Command
    {
        public bool Reverse(ref int Hy, ref int Hx)
        {
            int steps, commands_count = _globalVals.Commands.Count;
            string direction_command="";

            while (true)
            {
                Console.Write($"How many of the {commands_count} commands do you want to reverse? ");

                try
                {
                    steps = Convert.ToInt32(Console.ReadLine());
                    if (steps <= 0) continue;

                    int loopCount = 0;

                    while (steps > loopCount)
                    {
                        var latestValue = _globalVals.Commands.Last();

                        _globalVals.Commands.Remove(latestValue.Key);
                        loopCount++;
                    }

                    direction_command = _globalVals.Commands.Last().Value.Item1.ToString() + _globalVals.Commands.Last().Value.Item2;

                    //direction_command = _globalVals.Commands[commands_count - step];
                    //steps = int.Parse(direction_command.Substring(1));

                    //_globalVals.Commands.RemoveRange(commands_count - step, commands_count);
                }
                catch (Exception)
                {
                    Console.WriteLine("Caterpillar does not understand");
                    continue;
                }

                switch (direction_command[0])
                {
                    case 'U':
                        if (Hy == 0) Hy = 30;

                        Hy -= steps;
                        _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Up;
                        return true;
                    case 'R':
                        Hx -= steps;
                        _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Right;
                        return true;
                    case 'D':
                        Hy -= steps;
                        _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Down;
                        return true;
                    case 'L':
                        if (Hx == 0) Hx = 30;

                        Hx += steps;
                        _globalVals.Direction = EnumsFactory.EnumsFactory.Direction.Left;
                        return true;
                    default:
                        Console.WriteLine("Caterpillar does not understand, try imputing a valid command this time");
                        return false;
                }
            }
        }
    }
}
