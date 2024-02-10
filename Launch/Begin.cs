using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Launch
{
    internal class Begin(
        IGlobal_Vals globalVals,
        ILogger logger,
        IMove_Caterpillar _move_Head,
        ICollect_Next_Direction _movement_Direction,
        IMap_Co_ordinates _co_ordinates) : IBegin
    {
        private readonly TravelersModel _travelersModel = new(globalVals);
        public void Lets_Catch_Them_All()
        {
            _travelersModel.Map_Full_Dimension = _co_ordinates.Lets_Look_At_The_Map(EnumsFactory.EnumsFactory.MapCoordinates.Default);

            int Hx = 0, Hy = 29; //Starting position

            _travelersModel.Head_X_axis_Position = Hx;
            _travelersModel.Head_Y_axis_Position = Hy;

            while (true)
            {
                bool isCaterpillarAlive = _move_Head.New_Head_N_Segments_Position(_travelersModel);

                if (!isCaterpillarAlive) break;

                if (!_movement_Direction.Update_Head_Position(_travelersModel)) break;
            }

            logger.Logg_Commands();

            Console.Write("GAME OVER");
        }
    }
}