using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour
{
    #region Atributos
    
    /// <summary>
    /// Lista de la ropa y/o complementos que el jugador tiene que meter en la maleta.
    /// </summary>
    public List<string> Ropa;

    #endregion

    #region Propiedades

    /// <summary>
    /// Comprueba si el objeto seleccionado es correcto o no.
    /// </summary>
    private bool Correct { get; set; } = false;

    #endregion

    #region Eventos

    /// <summary>
    /// Cuando un objeto empiezan a superposicionarse.
    /// </summary>
    /// <param name="collision">Objeto superposicionado.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Correct = Ropa.Contains(collision.gameObject.name);
    }

    /// <summary>
    /// Cuando un objeto deja de superposicionarse.
    /// </summary>
    /// <param name="collision">Objeto superposicionado.</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        Correct = false;
    }

    #endregion

    #region Métodos públicos

    /// <summary>
    /// Determina si el objeto es correcto o no.
    /// </summary>
    /// <returns>Objeto correcto.</returns>
    public bool IsCorrect()
    {
        if (Correct)
        {
            Correct = false;
            return true;
        }
        return false;
    }

    #endregion

}