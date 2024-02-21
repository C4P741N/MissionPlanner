namespace Spice_n_Booster_Gobler.Models
{
    internal interface ICaterpillar_Parts
    {
        char Head { get; }
        char Segment { get; }
        int Segment_Count { get; set; }
        char Tail { get; }
        int Max_Segments_Count { get; }
        Dictionary<string, (int, int)> Body_Parts_Position { get; set; }
    }
}