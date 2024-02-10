


namespace Spice_n_Booster_Gobler.Util
{
    internal class Global_Vals : ICaterpillar_Parts, ICaterpillar_Movement, IDimensions, IMap_Obstacles, IGlobal_Vals
    {
        public char Head => 'H';
        public char Segment => '0';
        public char Tail => 'T';
        public EnumsFactory.EnumsFactory.Direction Direction { get; set; } = EnumsFactory.EnumsFactory.Direction.None;
        public int Max_Dimension => 30;
        public int Scope_Diameter => 11;
        public int Scope_Radius => 5;
        public char Booster => 'B';
        public char Obstacle => '#';
        public char Open_Space => '*';
        public char Spice => '$';
        public int Segment_Count { get; set; }
        public Dictionary<string, (int, int)> Body_Parts_Position { get; set; } = [];
        public List<string> Commands { get; set; } = [];
        public int Steps_To_Take { get; set; }
        public Dictionary<int, (int, int)> Irreplaceable_Resources_List { get; set; } = [];
    }
}
