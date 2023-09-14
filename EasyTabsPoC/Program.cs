using System.ComponentModel;
using EasyTabs;
using EasyTabsTests;
using FormLogging.Logging;

namespace EasyTabsPoC;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static int Main(string[] args)
    {
        IDefaultTextContainer? textContainer = null;
        FormLogger.Instance.RunApplicationWithFormLogging(() => TabbedApplicationHelper.CreateTabbedApplication(() =>
        {
            var tabbedApplicationForm = new TabbedApplicationForm
            {
                Text = "Test Form with a title very very long"
            };

            textContainer.CloseApplicationOnFirstTabClosing(tabbedApplicationForm);
            return tabbedApplicationForm;
        }, out textContainer));
        return 0;
    }

}