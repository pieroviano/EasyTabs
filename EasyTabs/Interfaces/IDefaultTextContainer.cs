using System.ComponentModel;
using System.Windows.Forms;

namespace EasyTabs;

/// <summary>
/// ITitleBarTabsHelper interface.
/// </summary>
public interface IDefaultTextContainer

{
    /// <summary>
    /// The default tab text.
    /// </summary>
    string? DefaultText

    {
        get;
        set;
    }

    /// <summary>
    /// Returns the information saying if is the first tab form.
    /// </summary>
    /// <param name="form">The form</param>
    /// <returns>the information saying if is the first tab form</returns>
    bool IsFirstTabForm(Form? form);
}