
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using HostReport;
using System.Net.Http;

using System.Collections.Generic;
using System;
using System.IO;
using System.Net.Sockets;
using System.Diagnostics;
namespace InfoRetrieval {
    class HostRetrieveInfo : HostReportPDF {
        private static readonly HttpClient client = new HttpClient();
        int timeout;
        int buffersize;
        int ttl;
        byte[] data;
        public HostRetrieveInfo(int timeout = 10000, int ttl = 30, int buffersize = 32) {
            this.timeout = timeout;
            this.ttl = ttl;
            this.buffersize = buffersize;
            string bfr = new string(' ', buffersize);
            this.data = System.Text.Encoding.ASCII.GetBytes(bfr);
        }

        public string retrieveAllAdressInfo(List<string> adresses) {
            /* The default folder (and as a consequence, the output location of the latex pdf) is the location of the program itself.
             Therefore, we change the working directory to the current user's directory, so that the pdf is created in the desired folder location*/
            Directory.SetCurrentDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            string fpath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)  + "\\" + (DateTime.Now.ToString(@"dd\-MM\-yyyy-h-mmtt") + "-hostreport.tex"));
            TcpClient scan = new TcpClient();
            PingOptions options = new PingOptions(this.ttl, true);
            this.InitalizeReport(fpath);
                using (var pinger = new Ping()) {
                    foreach (string adress in adresses) {
                        File.AppendAllText(fpath, "\\section{" + "Summary of " + adress + "} \n");
                        File.AppendAllText(fpath, "\\begin{enumerate} \n");
                    for (int i = 0; i < this.ttl; i++) {
                        try { 
                            PingReply reply = pinger.Send(adress, this.timeout, this.data, options);
                            if (reply.Status == IPStatus.Success || reply.Status == IPStatus.TtlExpired) {
                            string[] pingInfo = { "\\item ", "Reply Adress " + reply.Address.ToString(), "Result: " + reply.Status.ToString(), "RTT(ms): "+ reply.RoundtripTime.ToString(), "TTL: " + reply.Options.Ttl.ToString(), "Don't fragment: " + reply.Options.DontFragment.ToString(), "Reply buffer size: " + reply.Buffer.Length.ToString() };
                            File.AppendAllLines(fpath, pingInfo);
                        }    
                            if (reply.Status != IPStatus.TtlExpired && reply.Status != IPStatus.TimedOut) {
                            break;
                        }
                              
                        } catch (PingException) {
                            this.WriteErrornousHost(fpath);
                            break;
                        }
                    }
                    
                    File.AppendAllText(fpath, "\\end{enumerate} \n");
                }
                }



           this.FinishReport(fpath);
            Console.WriteLine("pdflatex " + fpath);
            Process latexCompilation = Process.Start("pdflatex ", fpath);
            return fpath;

            
        }
    }
}
