using Spice_n_Booster_Gobler.EnumsFactory;

namespace Spice_n_Booster_Gobler.Map
{
    internal class Map_Co_ordinates(
        IDefaultMap _defaultMap) : IMap_Co_ordinates
    {
        public char[][] Lets_Look_At_The_Map(EnumsFactory.EnumsFactory.MapCoordinates mapCoordinates)
        {
            switch (mapCoordinates)
            {
                case EnumsFactory.EnumsFactory.MapCoordinates.Default:
                    return _defaultMap.GetMap();
                case EnumsFactory.EnumsFactory.MapCoordinates.Import:
                //break;
                default: return null;
            }
        }
    }
}
