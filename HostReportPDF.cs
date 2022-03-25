
using System.IO;
using System.Text;
namespace HostReport {
    class HostReportPDF {

        internal async void InitalizeReport(string reportName) {
            string[] preamble = { "\\documentclass[12pt, letterpaper]{article}", " \\begin{document}" };
            File.AppendAllLines(reportName, preamble);
        }
        internal async void FinishReport(string reportName) {
             File.AppendAllText(reportName, "\\end{document}");

        }
    }
}