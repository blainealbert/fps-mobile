using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform joystickBackground;
    private RectTransform joystickHandle;

    private Vector2 joystickPosition = Vector2.zero;
    public float handleRange = 1f;
    public float handleLimit = 1f;

    public Vector2 JoystickDirection { get { return joystickPosition.normalized; } }
    public float Horizontal { get { return joystickPosition.x; } }
    public float Vertical { get { return joystickPosition.y; } }

    private void Awake()
    {
        joystickBackground = GetComponent<RectTransform>();
        joystickHandle = joystickBackground.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 direction = eventData.position - (Vector2)joystickBackground.position;
        joystickPosition = (direction.magnitude > joystickBackground.sizeDelta.x / 2f) ? direction.normalized : direction / (joystickBackground.sizeDelta.x / 2f);
        joystickHandle.anchoredPosition = joystickPosition * joystickBackground.sizeDelta.x * handleRange;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickPosition = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}