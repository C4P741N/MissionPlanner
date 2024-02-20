using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Map
{
    internal class MapSettings : IMapSettings
    {
        public EnumsFactory.EnumsFactory.MapCoordinates GetMapSettings()
        {
            return GetMapCommand();
        }
        private EnumsFactory.EnumsFactory.MapCoordinates GetMapCommand()
        {
            while (true)
            {
                Console.Write("Press E to use default map or C to import a local file map: ");

                var mapCom = (Console.ReadLine()?.ToUpper() ?? "").Trim();

                if (mapCom == "E" || mapCom == "C")
                {
                    var enumMap = mapCom switch
                    {
                        "C" => EnumsFactory.EnumsFactory.MapCoordinates.Import,
                        _ => EnumsFactory.EnumsFactory.MapCoordinates.Default
                    };

                    return enumMap;
                }

                Console.WriteLine("Invalid command");
            }
        }
    }
}
