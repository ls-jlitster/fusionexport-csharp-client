using System;
using System.IO;
using FusionCharts.FusionExport.Client; // Import sdk

namespace FusionExportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the ExportConfig class and add the required configurations
            ExportConfig exportConfig = new ExportConfig();
            exportConfig.Set("chartConfig", File.ReadAllText("fullpath/of/chart-config-file.json"));
            exportConfig.Set("type", "pdf");

             // Instantiate the ExportManager class
            ExportManager em = new ExportManager();
            // Call the Export() method with the export config and the respective callbacks
            em.Export(exportConfig, OnExportDone, OnExportStateChanged);
        }
        
        // Called when export is done
        static void OnExportDone(string result, ExportException error)
        {
            if(error != null)
            {
                Console.WriteLine("Error: " + error);
            } else
            {   
                Console.WriteLine("Done: " + result); // export result
            }
        }
        
        // Called on each export state change
        static void OnExportStateChanged(string state)
        {
            Console.WriteLine("State: " + state);
        }
    }
}
