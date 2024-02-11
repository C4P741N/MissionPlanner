using Spice_n_Booster_Gobler.Models;

namespace Spice_n_Booster_Gobler.Util
{
    internal interface ISectionPositionCorrecter
    {
        bool ShouldCorrect(int map_y, int map_x, int ySection_Position, int xSection_Position);
    }
}