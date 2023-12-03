namespace Loupedeck.CloseApplicationPlugin
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    // This class implements an example command that counts button presses.

    public class CloseAppCommand : PluginDynamicCommand
    {
        public CloseAppCommand()
            : base(displayName: "Close Application", description: "Closes a running Application", groupName: "Commands")
                => this.MakeProfileAction("text;Process Names (Separated by ,):");


        protected override void RunCommand(String actionParameter)
        {
            try
            {
                var processNames = actionParameter.Split(",");

                foreach (var processName in processNames)
                {
                    var processCheck = processName;
                    if (processCheck.ToLower().EndsWith(".exe"))
                    {
                        processCheck = processCheck.Substring(0, processCheck.Length - 4);
                    }
                    var processes = Process.GetProcessesByName(processCheck);

                    if (processes != null)
                    {
                        foreach (var process in processes)
                        {
                            process.Close();
                        }
                    }
                }
            }
            catch
            { }
        }
    }
}
