using UnityEngine.EventSystems;

public interface IFadeListener : IEventSystemHandler
{
    void StartFadeIn();
    void StartFadeOut();
}