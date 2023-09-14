using System.ComponentModel;
using System;
using System.Windows.Forms;

namespace EasyTabs;

/// <summary>
/// DefaultTextContainerExtensions class.
/// </summary>
public static class DefaultTextContainerExtensions
{
    /// <summary>
    /// Closes the Application on first tab closing.
    /// </summary>
    /// <param name="textContainer">The textContainer.</param>
    /// <param name="form">The form.</param>
    public static void CloseApplicationOnFirstTabClosing(this IDefaultTextContainer? textContainer, Form form)
    {
        void OnTabbedApplicationFormOnClosing(object? o, CancelEventArgs cancelEventArgs)
        {
            if (textContainer?.IsFirstTabForm(form) ?? false)
            {
                Environment.Exit(0);
            }
        }

        form.Closing += OnTabbedApplicationFormOnClosing;
    }
}