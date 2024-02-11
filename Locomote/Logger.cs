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

                writer.Write($"{cmd.Value.Item1}{cmd.Value.Item2}{comma}");
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

        private int count = 0;
        public void AddLogCommandsToCollection()
        {
            switch (_globalVals.Direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:

                    if (_globalVals.Commands.ContainsKey(count))
                    {
                        var currentCount = _globalVals.Commands[count].Item2;
                        _globalVals.Commands[count] = ('U', currentCount + 1);
                    }
                    else
                        _globalVals.Commands.Add(count++, ('U', 1));
                    return;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    if (_globalVals.Commands.ContainsKey(count))
                    {
                        var currentCount = _globalVals.Commands[count].Item2;
                        _globalVals.Commands[count] = ('R', currentCount + 1);
                    }
                    else
                        _globalVals.Commands.Add(count++, ('R', 1));
                    return;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    if (_globalVals.Commands.ContainsKey(count))
                    {
                        var currentCount = _globalVals.Commands[count].Item2;
                        _globalVals.Commands[count] = ('D', currentCount + 1);
                    }
                    else
                        _globalVals.Commands.Add(count++, ('D', 1));
                    return;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    if (_globalVals.Commands.ContainsKey(count))
                    {
                        var currentCount = _globalVals.Commands[count].Item2;
                        _globalVals.Commands[count] = ('L', currentCount + 1);
                    }
                    else
                        _globalVals.Commands.Add(count++, ('L', 1));
                    return;
            }
        }
    }
}
