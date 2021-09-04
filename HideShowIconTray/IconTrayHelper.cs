using PInvoke;
using System;

namespace HideShowIconTray
{
  public class IconTrayHelper
  {
    public static void ShowIconTray()
    {
      ShowIconTrayInternal(true);
    }
    public static void HideIconTray()
    {
      ShowIconTrayInternal(false);
    }

    private static void ShowIconTrayInternal(bool show)
    {
      Console.WriteLine((show ? "Showing" : "Hiding") + " the icon tray");

      IntPtr taskBar = User32.FindWindow("Shell_TrayWnd", null);

      IntPtr iconTray = User32.FindWindowEx(taskBar, IntPtr.Zero, "TrayNotifyWnd", null);

      IntPtr overflowButton = User32.FindWindowEx(iconTray, IntPtr.Zero, "Button", null);

      var windowShowStyle = show ? User32.WindowShowStyle.SW_SHOW : User32.WindowShowStyle.SW_HIDE;

      if (overflowButton != IntPtr.Zero)
      {
        User32.ShowWindow(overflowButton, windowShowStyle);
      }

      if (iconTray != IntPtr.Zero)
      {
        User32.ShowWindow(iconTray, windowShowStyle);
      }
    }
  }
}