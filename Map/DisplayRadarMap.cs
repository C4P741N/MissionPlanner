using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Map
{
    internal class DisplayRadarMap(IGlobal_Vals globalVals)
    {
        private readonly IGlobal_Vals _globalVals = globalVals;
        public void DisplayRadarSection(TravelersModel travelersModel)
        {
            Console.WriteLine("Mission Control v.0.0.1");
            Console.WriteLine();

            int[,,] scanned_section = travelersModel.Map_Radar_Section;

            for (int y = 0; y < _globalVals.Scope_Diameter; y++)
            {
                for (int x = 0; x < _globalVals.Scope_Diameter; x++)
                {
                    int mapY = scanned_section[y, 0, x];
                    int mapX = scanned_section[y, 1, x];

                    if (mapY < 0) mapY = (mapY + _globalVals.Max_Dimension) % _globalVals.Max_Dimension;
                    if (mapX < 0) mapX = (mapX + _globalVals.Max_Dimension) % _globalVals.Max_Dimension;

                    Console.Write(travelersModel.Map_Full_Dimension[mapY][mapX]);
                }
                Console.WriteLine();
            }
        }
    }
}
