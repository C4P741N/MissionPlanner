namespace Spice_n_Booster_Gobler.Models
{
    internal interface IGlobal_Vals
    {
        char Booster { get; }
        EnumsFactory.EnumsFactory.Direction Direction { get; set; }
        int Steps_To_Take { get; set; }
        char Head { get; }
        int Max_Dimension { get; }
        char Obstacle { get; }
        char Open_Space { get; }
        int Scope_Diameter { get; }
        int Scope_Radius { get; }
        char Segment { get; }
        public int Segment_Count { get; set; }
        char Spice { get; }
        char Tail { get; }
        int Max_Segments_Count { get; }
        Dictionary<string, (int, int)> Body_Parts_Position { get; set; }
        Dictionary<int, (int, int)> Irreplaceable_Resources_List { get; set; }
        Dictionary<string, (char, int)> Commands { get; set; }
    }
}