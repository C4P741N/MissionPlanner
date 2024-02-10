using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Map
{
    internal class Radar_Scope(IGlobal_Vals _globalVals) : IRadar_Scope
    {
        private readonly int _scope_Radius = _globalVals.Scope_Radius;
        private readonly int _scope_Diameter = _globalVals.Scope_Diameter;
        private readonly int _max_Dimension = _globalVals.Max_Dimension;
        public void Generate_Scanned_Sections(TravelersModel travelersModel)
        {
            int Hx, Hy;

            Hx = travelersModel.Head_X_axis_Position;
            Hy = travelersModel.Head_Y_axis_Position;
 
            int zeroY = Hy - _scope_Radius;

            int[,,] Radar_3d = new int[_scope_Diameter, 2, _scope_Diameter];

            //int[,,] arr3D = new int[2, 2, 3] 
            //{ 
            //    { 
            //        { 24, 24, 24 }, 
            //        { -5, -4, -3 } 
            //    }, 
            //    {
            //        { 7, 8, 9 }, x    
            //        { 10, 11, 12 } 
            //    } 
            //};

            for (int y = 0; y < _scope_Diameter; y++)
            {
                zeroY = (zeroY + _max_Dimension) % _max_Dimension;

                int zeroX = Hx - _scope_Radius; //Radius edge of H from left to right 

                for (int x = 0; x < _scope_Diameter; x++)
                {
                    zeroX = (zeroX + _max_Dimension) % _max_Dimension; //collect x-axis by 30*30

                    Radar_3d[y, 0, x] = zeroY;
                    Radar_3d[y, 1, x] = zeroX;

                    zeroX++;
                }

                zeroY++;
            }

            //24.-5  24.0  24.5
            //29.-5  29.0  29.5
            //-4.-5  -4.0  -4.5

            travelersModel.Map_Radar_Section = Radar_3d;
        }
    }
}
