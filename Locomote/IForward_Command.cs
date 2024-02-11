using Spice_n_Booster_Gobler.Models;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal interface IForward_Command
    {
        bool Move_Forward(string direction_command, ref int Hy, ref int Hx);
    }
}