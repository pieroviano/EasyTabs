using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace EasyTabs;

/// <summary>
/// Extension methods for Func&lt;Form&gt;.
/// </summary>
public static class TabbedApplicationHelper
{
    /// <summary>
    /// Creates a TabbedApplication.
    /// </summary>
    /// <param name="createInitialForm">The Func that creates the initial form.</param>
    /// <param name="defaultTextContainer"></param>
    /// <returns>A TitleBarTabsApplicationContext</returns>
    public static ApplicationContext CreateTabbedApplication(this Func<Form> createInitialForm, out IDefaultTextContainer defaultTextContainer)
    {
        return CreateTabbedApplication(createInitialForm, null, out defaultTextContainer);
    }

    /// <summary>
    /// Creates a TabbedApplication.
    /// </summary>
    /// <param name="createInitialForm">The Func that creates the initial form.</param>
    /// <param name="initialize">Initializes the form when created.</param>
    /// <param name="defaultTextContainer"></param>
    /// <returns>A TitleBarTabsApplicationContext</returns>
    public static TitleBarTabsApplicationContext CreateTabbedApplication<T>(this Func<Form> createInitialForm, Func<T?, Task>? initialize, out IDefaultTextContainer defaultTextContainer)
        where T : Form
    {
        return CreateTabbedApplication(createInitialForm, null, initialize, out defaultTextContainer);
    }

    /// <summary>
    /// Creates a TabbedApplication.
    /// </summary>
    /// <param name="createInitialForm">The Func that creates the initial form.</param>
    /// <param name="createForm">The Func that creates the other forms.</param>
    /// <param name="defaultTextContainer"></param>
    /// <returns>A TitleBarTabsApplicationContext</returns>
    public static TitleBarTabsApplicationContext CreateTabbedApplication(this Func<Form> createInitialForm, Func<Form>? createForm, out IDefaultTextContainer defaultTextContainer)
    {
        return CreateTabbedApplication(createInitialForm, createForm, null, out defaultTextContainer);
    }

    /// <summary>
    /// Creates a TabbedApplication.
    /// </summary>
    /// <param name="createInitialForm">The Func that creates the initial form.</param>
    /// <param name="createForm">The Func that creates the other forms.</param>
    /// <param name="initialize">Initializes the form when created.</param>
    /// <param name="defaultTextContainer"></param>
    /// <returns>A TitleBarTabsApplicationContext</returns>
    public static TitleBarTabsApplicationContext CreateTabbedApplication(this Func<Form> createInitialForm, Func<Form>? createForm, Func<Form?, Task>? initialize, out IDefaultTextContainer defaultTextContainer)
    {
        return CreateTabbedApplication<Form>(createInitialForm, createForm, initialize, out defaultTextContainer);
    }

    /// <summary>
    /// Creates a TabbedApplication.
    /// </summary>
    /// <param name="createInitialForm">The Func that creates the initial form.</param>
    /// <param name="createForm">The Func that creates the other forms.</param>
    /// <param name="initialize">Initializes the form when created.</param>
    /// <param name="defaultTextContainer"></param>
    /// <returns>A TitleBarTabsApplicationContext</returns>
    public static TitleBarTabsApplicationContext CreateTabbedApplication<T>(Func<Form> createInitialForm, Func<Form>? createForm, Func<T?, Task>? initialize, out IDefaultTextContainer defaultTextContainer)
        where T : Form
    {
        defaultTextContainer = new DefaultTextContainer();
        return ((DefaultTextContainer)defaultTextContainer).CreateTabbedApplication(createInitialForm, createForm, initialize);
    }

    /// <summary>
    /// The caption width.
    /// </summary>
    public static int CaptionWidth
    {
        get;
    } = SystemInformation.CaptionButtonSize.Width;
}