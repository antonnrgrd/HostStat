
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

        internal async void WriteErrornousHost(string reportName) {
            /* We have to write a single item and end the enumerate table since at this point if an error occurs,
             we have already in the .tex file declared an enumerate and latex cannot handle empty enumerate tables*/
            
            File.AppendAllText(reportName, "\\item Error, host could no be resolved. Terminating");
        }
    }
}