using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;

namespace Spice_n_Booster_Gobler.Launch
{
    internal class Begin : IBegin
    {
        private readonly IGlobal_Vals _globalVals;
        private readonly ILogger _logger;
        private readonly IMove_Caterpillar _move_Head;
        private readonly ICollect_Next_Direction _movement_Direction;   
        private readonly TravelersModel _travelersModel;
        private readonly IMapSettings _mapSettings;

        public Begin(
            IGlobal_Vals globalVals,
            ILogger logger,
            IMove_Caterpillar move_Head,
            ICollect_Next_Direction movement_Direction,
            IMapSettings mapSettings)
        {
            _globalVals = globalVals;
            _logger = logger;
            _move_Head = move_Head;
            _movement_Direction = movement_Direction;
            _mapSettings = mapSettings;

            //default starting point
            _globalVals.Steps_To_Take = 1;
            _travelersModel = new(_globalVals)
            {
                Head_X_axis_Position = 0,
                Head_Y_axis_Position = 29
            };
        }

        public void Lets_Begin()
        {
            EnumsFactory.EnumsFactory.MapCoordinates enumMap = _mapSettings.GetMapSettings();

            while (true)
            {
                var isCaterpillarAlive = _move_Head.New_Head_N_Segments_Position(_travelersModel, enumMap);

                if (!isCaterpillarAlive) break;

                if (!_movement_Direction.Update_Head_Position(_travelersModel)) break;
            }

            _logger.Logg_Commands_To_File();
        }
    }
}