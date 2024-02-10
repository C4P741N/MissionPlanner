using Spice_n_Booster_Gobler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Util
{
    internal class SectionPositionCorrecter(IGlobal_Vals globalVals) : ISectionPositionCorrecter
    {
        private readonly int _max = globalVals.Max_Dimension;
        public bool ShouldCorrect(
            TravelersModel travelersModel,
            int ySection_Position,
            int xSection_Position)
        {
            int ySection = ((ySection_Position + _max) % _max);
            int xSection = ((xSection_Position + _max) % _max);
            int yMap_Section = ((travelersModel.Map_Y_axis_Position + _max) % _max);
            int xMap_Section = ((travelersModel.Map_X_axis_Position + _max) % _max);

            int yDiff = ySection - yMap_Section;
            int xDiff = xSection - xMap_Section;

            if (yDiff < 0) yDiff += _max;
            if (xDiff < 0) xDiff += _max;

            if (yDiff > _max/2) yDiff = _max- yDiff;
            if (xDiff > _max/2) xDiff = _max- xDiff;

            bool yShouldCatchUp = yDiff > 1;
            bool xShouldCatchUp = xDiff > 1;

            return yShouldCatchUp || xShouldCatchUp;
        }
    }
}
