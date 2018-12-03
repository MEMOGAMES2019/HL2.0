﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadRoom : MonoBehaviour
{
    public GameObject tracker;
    public string room;
    public GameObject pickup;

    public GameObject[] roomSites;

    public GameObject[] objects;
    private Dictionary<string, string> _dictionary;
    private Dictionary<string, string> _order;

    private int _corrects;
    private int _mistakes;
    private int _caught;
    private GameObject pum;

    public GameObject b;
    public GameObject partner;

    void Awake()
    {

        pum = GameObject.Find("PickUpManager");
        if (pum == null)
        {
            pum = Instantiate(pickup);
            pum.name = "PickUpManager";
        }

        if (GameObject.Find("Tracker") == null)
        {
            GameObject t = Instantiate(tracker);
            t.name = "Tracker";
            DontDestroyOnLoad(t);
        }



        if (!room.Equals("Hall"))
        {
            Button btn = GameObject.FindGameObjectWithTag("Back").GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        _dictionary = pum.GetComponent<PickUpManager>().House[room];
        _order = pum.GetComponent<PickUpManager>().OrderHouse[room];

        for (int i = 0; i < roomSites.Length; i++)
            if (!_dictionary[roomSites[i].name].Equals("."))
            {
                FoundObject(_dictionary[roomSites[i].name]).transform.position = new Vector3(roomSites[i].transform.position.x, roomSites[i].transform.position.y, -0.001F);
                if (_dictionary[roomSites[i].name].Equals(_order[roomSites[i].name]))
                {
                    Sprite s = FoundObject(_dictionary[roomSites[i].name]).GetComponent<DragDrop>().newSprite;
                    FoundObject(_dictionary[roomSites[i].name]).GetComponent<SpriteRenderer>().sprite = s;
                }
            }
    }

    void Start()
    {
        _corrects = 0;
        _mistakes = 0;
        _caught = 0;
    }



    private IEnumerator WaitAndDestroy()
    {
        Color c = b.GetComponent<Image>().color;

        c.a -= 0.1f;

        b.GetComponent<Image>().color = c;

        yield return new WaitForSeconds(3);
        Destroy(b);
    }


    GameObject FoundObject(string name)
    {
        int i = 0;

        while (i < objects.Length && !objects[i].name.Equals(name))
            i++;

        return objects[i];
    }

    void TaskOnClick()
    {
        if (room.Equals("Hallway"))
            SceneManager.LoadScene("Hall");
        else
            SceneManager.LoadScene("Hallway");

        Store();
    }

    public void Store()
    {
        print(room);
        print("   corr: " + _corrects + "   cau: " + _caught + "   mist: " + _mistakes);
        pum.GetComponent<PickUpManager>().House[room] = _dictionary;
        pum.GetComponent<PickUpManager>().TotalMistakes += _mistakes;
        pum.GetComponent<PickUpManager>().TotalCorrects += _corrects;
        pum.GetComponent<PickUpManager>().TotalCaught += _caught;

        if (_corrects < objects.Length)
            pum.GetComponent<PickUpManager>().Room = room;
    }


    public Dictionary<string, string> Dictionary
    {
        get { return _dictionary; }
        set { _dictionary = value; }
    }

    public Dictionary<string, string> Order
    {
        get { return _order; }
        set { _order = value; }
    }

    public int Corrects
    {
        get { return _corrects; }
        set { _corrects = value; }
    }

    public int Mistakes
    {
        get { return _mistakes; }
        set { _mistakes = value; }
    }

    public int Caught
    {
        get { return _caught; }
        set { _caught = value; }
    }


}
