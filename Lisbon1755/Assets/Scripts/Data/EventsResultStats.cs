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
}
