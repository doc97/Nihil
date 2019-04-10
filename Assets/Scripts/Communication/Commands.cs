using System;

public static class Commands
{
    public static event Action<string> SwitchScene;
    public static void FireSwitchScene(string name) { SwitchScene?.Invoke(name); }
    public static event Action FadeIn;
    public static void FireFadeIn() { FadeIn?.Invoke(); }
    public static event Action FadeOut;
    public static void FireFadeOut() { FadeOut?.Invoke(); }
}