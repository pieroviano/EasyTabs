using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyTabs;

/// <summary>
/// TitleBarTabsHelper class
/// </summary>
internal class DefaultTextContainer : IDefaultTextContainer
{
    private TitleBarTabs? _container;

    public bool IsFirstTabForm(Form? form)
    {
        var firstOrDefault = _container?.Tabs.FirstOrDefault();
        return firstOrDefault?.OriginalContent == form;
    }

    /// <summary>
    /// Creates a TabbedApplication.
    /// </summary>
    /// <param name="createInitialForm">The Func that creates the initial form.</param>
    /// <param name="createForm">The Func that creates the other forms.</param>
    /// <param name="initialize">Initializes the form when created.</param>
    /// <returns>A TitleBarTabsApplicationContext</returns>
    public ApplicationContext CreateTabbedApplication<T>(Func<Form> createInitialForm, Func<Form>? createForm, Func<T?, Task>? initialize)
        where T : Form
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        createForm ??= createInitialForm;

        _container = new TitleBarTabs();
        _container.CreatingForm += async (_, e) =>
        {
            var eForm = createForm();
            e.Form = eForm;
            if (initialize != null)
            {
                await initialize.Invoke(eForm as T);
            }
        };

        // Add the initial Tab
        _container.AddTab(createInitialForm());

        // Set initial tab the first one
        _container.SelectedTabIndex = 0;

        // Create tabs and start application
        TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
        applicationContext.Start(_container);
        return applicationContext;
    }

    /// <summary>
    /// The default tab text.
    /// </summary>
    public string? DefaultText

    {
        get => _container?.DefaultText;
        set
        {
            if (_container != null)
            {
                _container.DefaultText = value;
            }
        }
    }
}