using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class HoverEffect : MonoBehaviour
{
    #region Atributos

    public Texture2D cursorTexture;

    #endregion

    #region Propiedades

    private Color HoverColor { get { return Color.cyan; } }

    private SpriteRenderer Render { get; set; }

    private CursorMode CursorModo { get { return CursorMode.Auto; } }

    private Vector2 HotSpot { get { return Vector2.zero; } }

    #endregion

    #region Eventos

    /// <summary>
    /// Inicializa el componente.
    /// </summary>
    private void Start()
    {
        Render = gameObject.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Cuando el ratón pasa por encima del objeto.
    /// </summary>
    private void OnMouseEnter()
    {
        SetColor(HoverColor);
        Cursor.SetCursor(cursorTexture, HotSpot, CursorModo);
    }

    /// <summary>
    /// Cuando el ratón sale del objeto.
    /// </summary>
    private void OnMouseExit()
    {
        SetColor(Color.white);
        Cursor.SetCursor(null, Vector2.zero, CursorModo);
    }

    #endregion

    #region Métodos Privados

    private void SetColor(Color c)
    {
        Render.color = c;
    }

    #endregion
}
