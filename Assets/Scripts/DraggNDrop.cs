using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DraggNDrop : MonoBehaviour
{
    #region Constantes

    private readonly float OFFSET_Z = 10.0f;

    #endregion

    #region Atributos

    public Luggage Maleta;

    #endregion

    #region Propiedades

    /// <summary>
    /// Punto donde comienza el objeto.
    /// </summary>
    private Vector3 StartPoint { get; set; }

    /// <summary>
    /// Compensa la vista para la posición Z.
    /// </summary>
    private Vector3 Offset { get; set; }

    #endregion

    #region Eventos

    /// <summary>
    /// Evento cuando se clicka el objeto.
    /// </summary>
    private void OnMouseDown()
    {
        StartPoint = transform.position;
        Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, OFFSET_Z));
    }

    /// <summary>
    /// Evento cuando se mantiene pulsado el objeto.
    /// </summary>
    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, OFFSET_Z);
        transform.position = Camera.main.ScreenToWorldPoint(newPosition) + Offset;
    }

    /// <summary>
    /// Evento cuando se deja de clickar el objeto.
    /// </summary>
    private void OnMouseUp()
    {
        if (!Maleta.IsCorrect())
            transform.position = StartPoint;
        else Destroy(gameObject);
    }

    #endregion

}