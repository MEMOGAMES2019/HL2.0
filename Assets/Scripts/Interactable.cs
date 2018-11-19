using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{

    public GameObject panel;
    private LuggageManager gameManager;

    private void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<LuggageManager>();
        this.panel.SetActive(false);
    }

    private void OnMouseOver()
    {
        if (this.gameManager.IsInteractable && Input.GetMouseButtonDown(0))
            this.gameManager.ClickOnDrawer(this.panel);
    }
}
