using Spice_n_Booster_Gobler.Models;
using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Spice_n_Booster_Gobler.EnumsFactory.EnumsFactory;

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

        private static int count = 0;
        public void AddLogCommandsToCollection()
        {
            switch (_globalVals.Direction)
            {
                case EnumsFactory.EnumsFactory.Direction.Up:
                    UpdateCollection('U');
                    return;
                case EnumsFactory.EnumsFactory.Direction.Right:
                    UpdateCollection('R');
                    return;
                case EnumsFactory.EnumsFactory.Direction.Down:
                    UpdateCollection('D');
                    return;
                case EnumsFactory.EnumsFactory.Direction.Left:
                    UpdateCollection('L');
                    return;
            }
        }
        private void UpdateCollection(char direction)
        {
            string key = $"{direction}{count}";

            if (_globalVals.Commands.TryGetValue(key, out var command))
            {
                _globalVals.Commands[key] = (command.Item1, command.Item2 + 1);
            }
            else
            {
                count++;
                key = $"{direction}{count}";
                _globalVals.Commands.Add(key, (direction, 1));
            }
        }
    }
}
