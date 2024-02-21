namespace Spice_n_Booster_Gobler.Models
{
    internal interface ICaterpillar_Movement
    {
        EnumsFactory.EnumsFactory.Direction Direction { get; set; }
        Dictionary<string, (char, int)> Commands { get; set; }
    }
}