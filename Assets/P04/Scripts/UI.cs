using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public UnityEvent OnXRPointerEnter, OnXRPointerExit;
    private Camera xRCamera;
    // Start is called before the first frame update
    void Start()
    {
        xRCamera = CPM.Instance.gameObject.GetComponent<Camera>();
    }
    public void OnPointerClickXR()
    {
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);
    }
    public void OnPointerEnterXR()
    {
        GazeManager.Instance.SetUpGaze(1.5f);
        OnXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);

    }
    public void OnPointerExitXR()
    {
        GazeManager.Instance.SetUpGaze(2.5f);
        OnXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerExitHandler);

    }
    private PointerEventData PlacePointer()
    {
        Vector3 screenPointer = xRCamera.WorldToScreenPoint(CPM.Instance.hp);
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = new Vector2(screenPointer.x, screenPointer.y);
        return pointer;
    }
}
