using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move_Left : Button
{
    public static bool clickLeft;


     public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        clickLeft = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
         base.OnPointerUp(eventData);
         clickLeft = false;
    }
}
