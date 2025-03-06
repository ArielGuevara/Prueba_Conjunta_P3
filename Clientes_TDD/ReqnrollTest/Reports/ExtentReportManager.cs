using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ReqnrollTest.Reports
{
    public class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "/Reportes/TestResults","ExtendReport.html");


        public static void InitReport()
        {
            var sparkReport = new ExtentSparkReporter(_reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReport);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogStep(bool isSucces, string stepDetails)
        {
            if (isSucces)
                _test.Log(Status.Pass, stepDetails);
            else
                _test.Log(Status.Fail, stepDetails);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
