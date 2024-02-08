
namespace Spice_n_Booster_Gobler.Util
{
    internal interface ICaterpillar_Parts
    {
        char Head { get; }
        char Segment { get; }
        int Segment_Count { get; set; }
        char Tail { get; }
        Dictionary<string,(int,int)> Body_Parts_Position { get; set; }
    }
}