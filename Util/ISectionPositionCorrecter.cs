using Spice_n_Booster_Gobler.Models;

namespace Spice_n_Booster_Gobler.Util
{
    internal interface ISectionPositionCorrecter
    {
        bool ShouldCorrect(TravelersModel travelersModel, int ySection_Position, int xSection_Position);
    }
}