using Spice_n_Booster_Gobler.Models;

namespace Spice_n_Booster_Gobler.Util
{
    internal interface ISegmentsCollection
    {
        bool CointainsKey(string segment);
        void Get_Segment_Location(string segment, out int map_y, out int map_x);
        void Add_Segment_Location_To_Collection(string label, int map_y, int map_x);
        void Add_Segment_Location_To_Collection(TravelersModel travelersModel);
        void Add_Segment_Location_To_Collection(TravelersModel travelersModel, string label);
    }
}