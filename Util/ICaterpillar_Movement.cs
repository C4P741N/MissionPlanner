
namespace Spice_n_Booster_Gobler.Util
{
    internal interface ICaterpillar_Movement
    {
        EnumsFactory.EnumsFactory.Direction Direction { get; set; }
        Dictionary<char, int> Commands { get; set; }
    }
}