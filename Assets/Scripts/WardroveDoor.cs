using UnityEngine;

namespace Assets.Scripts
{
    class WardroveDoor : MonoBehaviour
    {
        #region Atributos

        /// <summary>
        /// Objeto que representa la puerta del armario en el estado contrario.
        /// </summary>
        public GameObject puertaOtroEstado;

        /// <summary>
        /// Indica si la puerta está activa al inicio o no
        /// </summary>
        public bool active;

        #endregion

        #region Propiedades

        #endregion

        #region Eventos

        private void Start()
        {
            gameObject.SetActive(active);
        }

        void OnMouseDown()
        {
            puertaOtroEstado.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        #endregion
    }
}
