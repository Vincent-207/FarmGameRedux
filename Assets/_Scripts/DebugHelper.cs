using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    public void DoDayTick()
    {
        Clock.instance.dayEndEvent.Invoke();
    }
}
