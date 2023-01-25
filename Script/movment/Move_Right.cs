using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move_Right : Button
{
    public static bool clickRight;


     public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        clickRight = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
         base.OnPointerUp(eventData);
         clickRight = false;
    }
}
