using System;
using System.IO;
using System.Linq;
using FusionCharts.FusionExport.Client; // Import sdk

namespace FusionExportTest
{
    public static class InjectJsCallback
    {
        public static void Run()
        {
            // Instantiate the ExportConfig class and add the required configurations
            ExportConfig exportConfig = new ExportConfig();
            exportConfig.Set("chartConfig", File.ReadAllText("./resources/dashboard_charts.json"));
            exportConfig.Set("templateFilePath", "./resources/template.html");
            exportConfig.Set("callbackFilePath", "./resources/callback.js");

            // Instantiate the ExportManager class
            ExportManager em = new ExportManager();
            // Call the Export() method with the export config and the respective callbacks
            em.Export(exportConfig, OnExportDone, OnExportStateChanged);
        }

        // Called when export is done
        static void OnExportDone(ExportEvent ev, ExportException error)
        {
            if (error != null)
            {
                Console.WriteLine("Error: " + error);
            }
            else
            {
                var fileNames = ev.exportedFiles.data.Select((tmp) => tmp.realName);
                Console.WriteLine("Done: " + fileNames); // export result
            }
        }

        // Called on each export state change
        static void OnExportStateChanged(ExportEvent ev)
        {
            Console.WriteLine("State: " + ev.state.customMsg);
        }
    }
}
