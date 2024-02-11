using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Logger(IGlobal_Vals _globalVals) : ILogger
    {
        private readonly string filePath = "caterpillar_commands.txt";
        public void Logg_Commands_To_File()
        {
            string comma = ",";
            int commands_count = _globalVals.Commands.Count;
            // Write the lists to the text file
            using StreamWriter writer = new(filePath, append: true);

            int i = 0;
            foreach (var cmd in _globalVals.Commands)
            {
                if (i == commands_count - 1) comma = "";

                writer.Write($"{cmd.Key}{cmd.Value}{comma}");
                i++;
            }

            //for (int i = 0; i < commands_count; i++)
            //{
            //    if(i == commands_count - 1) comma = "";

            //    writer.Write($"{_globalVals.Commands[i]}{comma}");
            //}
            // Add an empty line between the lists
            writer.WriteLine();
        }
        public void ClearLogCommands()
        {
            _globalVals.Commands.Clear();
        }
        public void AddLogCommandsToCollection()
        {
            switch (_globalVals.Direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:

                    if (_globalVals.Commands.ContainsKey('U'))
                        _globalVals.Commands['U']++;
                    else
                        _globalVals.Commands.Add('U', 1);
                    return;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    if (_globalVals.Commands.ContainsKey('R'))
                        _globalVals.Commands['R']++;
                    else
                        _globalVals.Commands.Add('R', 1);
                    return;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    if (_globalVals.Commands.ContainsKey('D'))
                        _globalVals.Commands['D']++;
                    else
                        _globalVals.Commands.Add('D', 1);
                    return;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    if (_globalVals.Commands.ContainsKey('L'))
                        _globalVals.Commands['L']++;
                    else
                        _globalVals.Commands.Add('L', 1);
                    return;
            }
        }
    }
}
