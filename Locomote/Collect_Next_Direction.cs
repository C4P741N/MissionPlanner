using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Collect_Next_Direction(IGlobal_Vals globalVals)
    {
        private readonly IGlobal_Vals _globalVals = globalVals;
        private readonly Forward_Command _forwardCommand = new(globalVals);
        private readonly Reverse_Command _reverseCommand = new(globalVals);
        public bool Update_Head_Position(TravelersModel travelersModel)
        {
            bool ask_for_command= true;
            while (ask_for_command)
            {
                Console.WriteLine();
                Console.Write("Input command, press R to revert or N to exit: ");
                string direction_command = Console.ReadLine()?.ToUpper() ?? "";

                int Hy, Hx;
                Hy = travelersModel.Head_Y_axis_Position;
                Hx = travelersModel.Head_X_axis_Position;

                if (string.IsNullOrEmpty(direction_command))
                {
                    Console.WriteLine("Invalid command");
                    continue;
                }

                if (direction_command == "N") return false;

                bool isSuccess;

                if (direction_command == "R")
                {
                    if (_globalVals.Commands.Count == 0)
                    {
                        Console.WriteLine("Nothing to revert to");
                        continue;
                    }

                    isSuccess = _reverseCommand.Reverse(ref Hy, ref Hx);
                }
                else
                {
                    isSuccess = _forwardCommand.Move_Forward(direction_command, ref Hy, ref Hx);
                    if(isSuccess) _globalVals.Commands.Add(direction_command);
                }

                if (isSuccess) ask_for_command = false;

                if (Hy == 30) Hy = 0;
                if (Hx == 30) Hx = 0;

                travelersModel.Head_Y_axis_Position = Hy;
                travelersModel.Head_X_axis_Position = Hx;
            }

            return true;
        }
    }
}
