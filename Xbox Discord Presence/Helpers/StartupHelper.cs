using System;
using System.IO;
using IWshRuntimeLibrary;

namespace Xbox_Discord_Presence.Helpers
{
    public static class StartupHelper
    {
        private static string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        private static string shortcutPath = Path.Combine(startupFolder, "Xbox Discord Presence" + ".lnk");
        public static void AddAppToStartup()
        {
            var shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

            shortcut.TargetPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            shortcut.WorkingDirectory = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            shortcut.Save();
        }

        public static void RemoveAppFromStartup()
        {
            if (System.IO.File.Exists(shortcutPath))
                System.IO.File.Delete(shortcutPath);
        }
    }
}
