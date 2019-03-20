using OpenQA.Selenium;
using System.Threading;

namespace AgeRangerWebUi.Steps
{
    public class BaseClass
    {
        public static IWebDriver driver { get; set; } = null;


        public static void Sleep(int Seconds)
        {
            Thread.Sleep(Seconds * 1000);
        }
    }
}
