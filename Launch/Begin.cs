using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Launch
{
    internal class Begin(
        IGlobal_Vals globalVals,
        ILogger logger) : IBegin
    {
        private readonly Move_Caterpillar _move_Head = new(globalVals);
        private readonly Collect_Next_Direction _movement_Direction = new(globalVals);
        private readonly Map_Co_ordinates _co_ordinates = new();
        public void Lets_Catch_Them_All()
        {
            char[][] map = _co_ordinates.Lets_Look_At_The_Map();

            int Hx = 0, Hy = 29; //Starting position
            //Global_Vals.Segment_Positions["Tx"] = Hx;
            //Global_Vals.Segment_Positions["Ty"] = Hy;

            while (true)
            {
                bool isCaterpillarAlive = _move_Head.New_Head_N_Segments_Position(Hy, Hx, ref map);

                if (!isCaterpillarAlive) break;

                if (!_movement_Direction.Update_Head_Position(ref Hy, ref Hx)) break;
            }

            logger.Logg_Commands();

            Console.Write("GAME OVER");
        }
    }
}