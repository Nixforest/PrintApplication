using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarpyFramework.Utility
{
    /// <summary>
    /// Class handle log
    /// </summary>
    class LogManager
    {
        /// <summary>
        /// Log file name
        /// </summary>
        private const String LOG_FILE_NAME = "log.txt";

        /// <summary>
        /// Write log content
        /// </summary>
        /// <param name="msg">Log content</param>
        public static void WriteLog(string msg)
        {
            using (StreamWriter w = File.AppendText(LOG_FILE_NAME))
            {
                Log(msg, w);
            }
        }

        /// <summary>
        /// Read log content
        /// </summary>
        public static void ReadLog()
        {
            using (StreamReader r = File.OpenText(LOG_FILE_NAME))
            {
                DumpLog(r);
            }
        }

        /// <summary>
        /// Write log
        /// </summary>
        /// <param name="logMessage">Log message</param>
        /// <param name="w">Text writer objec</param>
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        /// <summary>
        /// Dump log
        /// </summary>
        /// <param name="r">Stream reader object</param>
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
