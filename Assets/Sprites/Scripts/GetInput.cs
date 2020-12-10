using UnityEngine;
using UnityEngine.EventSystems;

public class GetInput : MonoBehaviour
{
    public PlayerController player; 


    private void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);
        player.SetMaxDistance(v[1], v[3]);

        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
        trigger.triggers.Add(entry);
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
        trigger.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry();
        entry3.eventID = EventTriggerType.Drag;
        entry3.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
        trigger.triggers.Add(entry3);
    }

    void OnPointerDown(PointerEventData data)
    {
        //Debug.Log("PointerDown");

        player.StartAim(data.position);
    }
    

    void OnPointerUp(PointerEventData data)
    {
        //Debug.Log("PointerUp");

        player.EndAim(data.position);
    }

    void OnDrag(PointerEventData data)
    {
        //Debug.Log("isDragging");

        player.DraggingStarted();
    }
}
