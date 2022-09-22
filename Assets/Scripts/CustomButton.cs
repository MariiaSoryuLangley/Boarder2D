using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    bool isDown = false;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log("Down");
        isDown = true;
        //show text
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("Up");
        isDown = false;
        //hide text
    }

    public bool IfButtonIsDown()
    {
        return isDown;
    }
}
