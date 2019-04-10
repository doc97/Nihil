using System;

public static class Signals
{
    public static event Action OnFadeInFinished;
    public static void EmitFadeInFinished() { OnFadeInFinished?.Invoke(); }
    public static event Action OnFadeOutFinished;
    public static void EmitFadeOutFinished() { OnFadeOutFinished?.Invoke(); }
    public static event Action OnIntroFinished;
    public static void EmitIntroFinished() { OnIntroFinished?.Invoke(); }
}