using Spice_n_Booster_Gobler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Util
{
    internal class ResourceCollection(IGlobal_Vals _globalVals) : IResourceCollection
    {
        public void Modify(TravelersModel travelersModel)
        {
            if (_globalVals.Irreplaceable_Resources_List.ContainsValue((travelersModel.Map_Y_axis_Position, travelersModel.Map_X_axis_Position)))
            {
                return;
            }
            else
            {
                int collectionCOunt = _globalVals.Irreplaceable_Resources_List.Count;

                _globalVals.Irreplaceable_Resources_List.Add(collectionCOunt++, (travelersModel.Map_Y_axis_Position, travelersModel.Map_X_axis_Position));
            }
        }
    }
}
