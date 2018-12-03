using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DropLuggage : MonoBehaviour
{

    private ClothesController dropController;

    private void Start()
    {
        this.dropController = FindObjectOfType<ClothesController>();
    }

    public void ItemWasDropped(GameObject go)
    {
        if (this.dropController.TargetWasDropped(go))
        {
            Destroy(go);
        }
        else
        {
            go.GetComponent<DragObject>().ReturnToStartPoint();
        }
    }
}
