using UnityEngine.EventSystems;

public interface IStatusFinished : IEventSystemHandler
{
    void OnFinish();
}