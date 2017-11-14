using Xunit;
using Xunit.Abstractions;
using System.Diagnostics;
using System.IO;


namespace ForexConnect
{
    public class Parameter
    {
        private readonly ITestOutputHelper output;

        public Parameter(ITestOutputHelper output)
        {
            this.output = output;
        }

        //TODO разобраться с файлами конфигурации в net core
        private string directorySample = @"C:\ForexConnectAPI\samples\";
        private const int TIME_FOR_ONE_OPERATION = 60;

        protected const string BUILD_BAT = "fxbuild.bat";
        protected const string CLEAN_BAT = "fxclean.bat";

        protected const string RUN_PARAMETR_Y_ACCOUNT = @"fxrun.bat /l fxu10d9_dev /p u10d9dev " +
        @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo";
        protected const string RUN_PARAMETR_F_ACCOUNT = @"fxrun.bat /l fxu10d5_dev /p u10d5dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo";
        protected const string RUN_PARAMETR_F_MULTY_ACCOUNT = @"fxrun.bat /l fxu100d1_dev /p u100d1dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo";
        protected const string RUN_PARAMETR_N_ACCOUNT = @"fxrun.bat /l fxu10d3_dev /p u10d3dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo";


        protected const string RUN_PARAMETR_WITH_INSTRUMENT_Y_ACCOUNT = @"fxrun.bat /l fxu10d9_dev /p u10d9dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_F_ACCOUNT = @"fxrun.bat /l fxu10d5_dev /p u10d5dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_F_MULTY_ACCOUNT = @"fxrun.bat /l fxu100d1_dev /p u100d1dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_N_ACCOUNT = @"fxrun.bat /l fxu10d3_dev /p u10d3dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD";

        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_Y_ACCOUNT = @"fxrun.bat /l fxu10d9_dev /p u10d9dev " +
        @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_F_ACCOUNT = @"fxrun.bat /l fxu10d5_dev /p u10d5dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_F_MULTY_ACCOUNT = @"fxrun.bat /l fxu100d1_dev /p u100d1dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_N_ACCOUNT = @"fxrun.bat /l fxu10d3_dev /p u10d3dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B";

        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_Y_ACCOUNT = @"fxrun.bat /l fxu10d9_dev /p u10d9dev " +
            @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B /r 0.9";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_F_ACCOUNT = @"fxrun.bat /l fxu10d5_dev /p u10d5dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B /r 0.9";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_F_MULTY_ACCOUNT = @"fxrun.bat /l fxu100d1_dev /p u100d1dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B /r 0.9";
        protected const string RUN_PARAMETR_WITH_INSTRUMENT_BUY_RATE_N_ACCOUNT = @"fxrun.bat /l fxu10d3_dev /p u10d3dev " +
                @"/u http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B /r 0.9";

        //tests accounts:
        //type y - /l fxu10d9_dev /p u10d9dev
        //type f - /l fxu10d5_dev /p u10d5dev
        //type f multi /l fxu100d1_dev /p u100d1dev
        //type n - /l fxu10d3_dev /p u10d3dev

        protected const int ACCOUNT_ID_Y = 97815;
        protected const int ACCOUNT_ID_F = 424058;
        protected const int ACCOUNT_ID_F_MULTY = 660464;
        protected const int ACCOUNT_ID_N = 205736;

        protected const int AMOUNT_Y = 10000;
        protected const int AMOUNT_F = 10000;
        protected const int AMOUNT_F_MULTY = 100000;
        protected const int AMOUNT_N = 10000;

        protected const string RUN_PARAMETR_FOR_SAMPLE_COMISSIONS = @"fxrun.bat /l cw156808 /p q " +
            @"/u http://tshosts.gehtsoft.com:22000/Hosts.jsp /i EUR/USD /c QA /d B";
        protected const string RUN_PARAMETR_FOR_SAMPLE_TWOCONNECTION = @"fxrun.bat /l fxu10d9_dev /p u10d9dev /u " +
            @"http://www.fxcorporate.com/Hosts.jsp /c Demo /i EUR/USD /d B /login2 fxu10d3_dev /password2 u10d3dev";
        protected const string RUN_PARAMETR_NETTING_OPEN_POSITION = @"fxrun.bat /l yakovlev1 /p q " +
            @"/u http://tshosts.gehtsoft.com:22000/Hosts.jsp /c QA /pin 123123 /sessionid U1R2 /i EUR/USD /d B";
        protected const string RUN_PARAMETR_FOR_GET_HIST_PRICES = "fxrun /l fxu10d9_dev /p u10d9dev /u http://www.fxcorporate.com/Hosts.jsp " +
            "/c Demo /i EUR/USD /datefrom \"10.10.2017 00:00:00\" /dateto \"10.11.2017 00:00:00\" /timeframe H1";


        protected const int TIME_FOR_TEST_STANDART = 120000;
        protected const int TIME_FOR_TEST_EXPANDED = 240000;

        protected void CheckError(string result)
        {
            string exeption = "Exception";
            string error = "Error";
            string exeptionRegistr = "exception";
            string errorRegistr = "Error";
            string timeOut = "timeout";
            string timeOutRegistr = "Timeout";
            string failed = "failed";
            string failedRegistr = "Failed";
            string cannot = "Cannot";

            Assert.False(result.Contains(exeption),
                    "Error - " + exeption);
            Assert.False(result.Contains(error),
                "Error - " + error);
            Assert.False(result.Contains(exeptionRegistr),
                "Error - " + exeptionRegistr);
            Assert.False(result.Contains(errorRegistr),
                "Error - " + errorRegistr);
            Assert.False(result.Contains(timeOut),
                "Error - " + timeOut);
            Assert.False(result.Contains(timeOutRegistr),
                "Error - " + timeOutRegistr);
            Assert.False(result.Contains(failed),
                "Error - " + failed);
            Assert.False(result.Contains(failedRegistr),
                "Error - " + failedRegistr);
            Assert.False(result.Contains(cannot),
                "Error - " + cannot);
        }

        protected string CMD(string pathSample, string actionCMD)
        {
            ProcessStartInfo procStartInfo =
                new ProcessStartInfo("cmd", "/c " + "cd " + directorySample +
                 pathSample + " && " + actionCMD);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = procStartInfo;
            process.Start();

            string result = ReadProcessOutput(process.StandardOutput,
                TIME_FOR_ONE_OPERATION);
            output.WriteLine("\r\nResult output CMD.exe:\r\n" + result);
            process.Close();

            return result;
        }

        private string ReadProcessOutput(StreamReader reader, int timeout)
        {
            var monitor = new TimeoutMonitor(timeout);
            string outputForStream = "";

            while (!monitor.CheckTimeout())
            {
                while (reader.Peek() >= 0)
                {
                    outputForStream = outputForStream + (char)reader.Read();
                }
                if (reader.EndOfStream)
                {
                    return outputForStream;
                }
            }
            return outputForStream;
        }

        protected string FindOrderID(string line, string beforeOrderID)
        {
            int amountSymbolID = 8;
            return line.Substring(line.IndexOf(beforeOrderID) +
                beforeOrderID.Length, amountSymbolID);
        }
    }
}
