using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Locomote
{
    internal class Logger(IGlobal_Vals _global_Vals) : ILogger
    {
        private readonly string filePath = "caterpillar_commands.txt";
        public void Logg_Commands()
        {
            string comma = ",";
            int commands_count = _global_Vals.Commands.Count;
            // Write the lists to the text file
            using StreamWriter writer = new(filePath, append: true);

            for (int i = 0; i < commands_count; i++)
            {
                if(i == commands_count - 1) comma = "";

                writer.Write($"{_global_Vals.Commands[i]}{comma}");
            }
            // Add an empty line between the lists
            writer.WriteLine();
        }
    }
}
