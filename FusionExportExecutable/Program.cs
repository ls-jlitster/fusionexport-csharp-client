﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;
using System.IO;
using FusionCharts.FusionExport.Client;
using System.Threading;
using System.Text.RegularExpressions;

namespace FusionExportExecutable
{

    class Program
    {
        static void Main(string[] args)
        {
            string chartConfigFile = @"C:\Users\rousa\Desktop\Projects\fc-export-java-client\src\com\fusioncharts\chartConfig.json";
           
            ExportManager em = new ExportManager("127.0.0.1", 1337);

            ExportConfig exportConfig = new ExportConfig();
            exportConfig.Set("chartConfig", File.ReadAllText(chartConfigFile));
            Exporter exporter = em.Export(exportConfig, OnExportDone, OnExportStateChanged);

            exportConfig = exportConfig.Clone();
            exporter = em.Export(exportConfig, OnExportDone, OnExportStateChanged);

            exportConfig = exportConfig.Clone();
            exporter = em.Export(exportConfig, OnExportDone, OnExportStateChanged);

            Console.Read(); 
        }

        static void OnExportDone(string result, ExportException error)
        {

            if(error != null)
            {
                Console.WriteLine("ERROR: " + error);
            } else
            {
                Console.WriteLine("DONE: " + result);
            }
        }

        static void OnExportStateChanged(string state)
        {
            Console.WriteLine("STATE: " + state);
        }
    }
}
