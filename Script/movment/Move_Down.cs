using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move_Down : Button
{
    public static bool clickDown;


     public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        clickDown = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
         base.OnPointerUp(eventData);
         clickDown = false;
    }
}

