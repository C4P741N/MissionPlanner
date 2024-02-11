using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;

namespace Spice_n_Booster_Gobler.Launch
{
    internal class Begin(
        IGlobal_Vals _globalVals,
        ILogger _logger,
        IMove_Caterpillar _move_Head,
        ICollect_Next_Direction _movement_Direction,
        IMap_Co_ordinates _co_ordinates) : IBegin
    {
        private readonly TravelersModel _travelersModel = new(_globalVals);
        public void Lets_Catch_Them_All()
        {
            SetupStartingPosition();
            var mapCom = GetMapCommand();
            var enumMap = mapCom switch
            {
                "C" => EnumsFactory.EnumsFactory.MapCoordinates.Import,
                _ => EnumsFactory.EnumsFactory.MapCoordinates.Default
            };

            while (true)
            {
                var isCaterpillarAlive = _move_Head.New_Head_N_Segments_Position(_travelersModel, enumMap);

                if (!isCaterpillarAlive) break;

                if (!_movement_Direction.Update_Head_Position(_travelersModel)) break;
            }

            _logger.Logg_Commands_To_File();
            Console.Write("GAME OVER");
        }

        private void SetupStartingPosition()
        {
            _globalVals.Steps_To_Take = 1;
            _travelersModel.Head_X_axis_Position = 0;
            _travelersModel.Head_Y_axis_Position = 29;
        }

        private string GetMapCommand()
        {
            while (true)
            {
                Console.Write("Press E to use default map or C to import a local file map: ");

                var mapCom = (Console.ReadLine()?.ToUpper() ?? "").Trim();

                if (mapCom == "E" || mapCom == "C") return mapCom;

                Console.WriteLine("Invalid command");
            }
        }
    }
}