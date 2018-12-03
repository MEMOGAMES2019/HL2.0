using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Door : MonoBehaviour
{
    public string scene;

    private GameObject room;
    private GameObject pickUp;

    void Start()
    {
        room = GameObject.Find("PickUp");
        pickUp = GameObject.Find("PickUpManager");
    }

    void OnMouseDown()
    {
        pickUp.GetComponent<PickUpManager>().TotalDoorsOpened++;
        room.GetComponent<LoadRoom>().Store();
        SceneManager.LoadScene(scene);
        if (scene.Equals("Kitchen"))
        {
            pickUp.GetComponent<PickUpManager>().Data();
        }
    }

}
