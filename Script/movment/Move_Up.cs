using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move_Up : Button
{
    public static bool clickUp;


     public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        clickUp = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
         base.OnPointerUp(eventData);
         clickUp = false;
    }
}

