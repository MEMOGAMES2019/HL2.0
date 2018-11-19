using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonColor : MonoBehaviour
{
    private readonly CursorMode cursorMode = CursorMode.Auto;

    public void Reset()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
