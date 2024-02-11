namespace Spice_n_Booster_Gobler.Locomote
{
    internal interface ILogger
    {
        void Logg_Commands_To_File();
        void AddLogCommandsToCollection();
        void ClearLogCommands();
    }
}