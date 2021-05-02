using UnityEngine;

[CreateAssetMenu(menuName = "EventsResultStats")]
public class EventsResultStats : ScriptableObject
{
    [SerializeField]
    private EventResult[] eventsResult;
   
    public EventResult[] EventsResult
    {
        get => eventsResult;
        set => eventsResult = value;
    }

    public void ResetStats()
    {
        for(int i = 0; i < eventsResult.Length; i++)
        {
            eventsResult[i] = EventResult.None;
        }
    }
}
