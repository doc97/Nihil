using System;

public static class Signals
{
    public static event Action OnFadeInFinished;
    public static void EmitFadeInFinished() { OnFadeInFinished?.Invoke(); }
    public static event Action OnFadeOutFinished;
    public static void EmitFadeOutFinished() { OnFadeOutFinished?.Invoke(); }
    public static event Action OnIntroFinished;
    public static void EmitIntroFinished() { OnIntroFinished?.Invoke(); }
    public static event Action OnPlayRequested;
    public static void EmitPlayRequested() { OnPlayRequested?.Invoke(); }
    public static event Action OnQuitRequested;
    public static void EmitQuitRequested() { OnQuitRequested?.Invoke(); }
}