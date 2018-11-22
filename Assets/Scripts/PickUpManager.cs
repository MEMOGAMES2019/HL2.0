using RAGE.Analytics;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    private Dictionary<string, Dictionary<string, string>> _orderHouse;
    private Dictionary<string, Dictionary<string, string>> _house;

    private int _totalMistakes;
    private int _totalCorrects;
    private int _totalCaught;
    private int _totalDoorsOpened;
    private int _totalObjects;
    private int _feedBack;
    private float _time;
    private string _room;

    void Awake()
    {
        //print(Application.persistentDataPath);
        DontDestroyOnLoad(transform.gameObject);
        InitObjects();
        OrderObjects();
    }

    void Start()
    {

        _totalMistakes = 0;
        _totalCorrects = 0;
        _totalCaught = 0;
        _totalDoorsOpened = 0;
        _feedBack = 0;
        _room = ".";

        Tracker.T.setVar("TotalObjects", TotalObjects);

        Tracker.T.Completable.Initialized("house");
    }

    private void FixedUpdate()
    {
        _time += Time.deltaTime;
    }

    public void InitObjects()
    {
        _totalObjects = 0;

        _house = new Dictionary<string, Dictionary<string, string>>();

        Dictionary<string, string> hall = new Dictionary<string, string>
        {
            { "Mesa", "Abrigo" },
            { "Suelo1", "Sombrero" },
            { "Suelo2", "." },
            { "Perchero", "." }
        }; //hall
        _house.Add("Hall", hall);
        _totalObjects += 2;

        Dictionary<string, string> hallway = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Suelo3", "." },
            { "Mesa", "." }
        }; //hall
        _house.Add("Hallway", hallway);
        _totalObjects += 0;

        Dictionary<string, string> main = new Dictionary<string, string>
        {
            { "Suelo1", "Almohada" },
            { "Suelo2", "." },
            { "Suelo3", "." },
            { "Cama", "." },
            { "Armario", "." },
            { "Mesilla", "." }
        }; //main bedroom
        _house.Add("Main_bedroom", main);
        _totalObjects += 1;

        Dictionary<string, string> second = new Dictionary<string, string>
        {
            { "Suelo1", "Osito" },
            { "Suelo2", "Boli" },
            { "Suelo3", "Papeles" },
            { "Cama", "." },
            { "Mesa1", "." },
            { "Mesa2", "." }
        }; //second bedroom
        _house.Add("Second_bedroom", second);
        _totalObjects += 3;

        Dictionary<string, string> living = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "Tablet" },
            { "Sofa1", "Mando" },
            { "Sofa2", "." },
            { "Mesa1a", "." },
            { "Mesa1b", "." },
            { "Mesa2", "Libro" },
            { "Estanteria", "." }
        }; //livingroom
        _house.Add("Livingroom", living);
        _totalObjects += 3;

        Dictionary<string, string> bath = new Dictionary<string, string>
        {
            { "Suelo1", "Albornoz" },
            { "Suelo2", "Champu" },
            { "Suelo3", "Toalla" },
            //bath.Add ("Lavabo", "Toalla");
            { "Colgador", "." },
            { "Toallero", "." },
            { "Estante", "." },
            { "Ducha", "." }
        }; //bathroom
        _house.Add("Bathroom", bath);
        _totalObjects += 3;
    }
    public void OrderObjects()
    {
        _orderHouse = new Dictionary<string, Dictionary<string, string>>();

        Dictionary<string, string> hall = new Dictionary<string, string>
        {
            { "Mesa", "Sombrero" },
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Perchero", "Abrigo" }
        }; //hall
        _orderHouse.Add("Hall", hall);

        Dictionary<string, string> hallway = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Suelo3", "." },
            { "Mesa", "." }
        }; //hall
        _orderHouse.Add("Hallway", hallway);

        Dictionary<string, string> main = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Suelo3", "." },
            { "Cama", "Almohada" },
            { "Armario", "." },
            { "Mesilla", "." }
        }; //main bedroom
        _orderHouse.Add("Main_bedroom", main);

        Dictionary<string, string> second = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Suelo3", "." },
            { "Cama", "Osito" },
            { "Mesa1", "Papeles" },
            { "Mesa2", "Boli" }
        }; //second bedroom
        _orderHouse.Add("Second_bedroom", second);

        Dictionary<string, string> living = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Sofa1", "." },
            { "Sofa2", "." },
            { "Mesa1a", "Tablet" },
            { "Mesa1b", "." },
            { "Mesa2", "Mando" },
            { "Estanteria", "Libro" }
        }; //livingroom
        _orderHouse.Add("Livingroom", living);

        Dictionary<string, string> bath = new Dictionary<string, string>
        {
            { "Suelo1", "." },
            { "Suelo2", "." },
            { "Suelo3", "." },
            //bath.Add ("Lavabo", ".");
            { "Colgador", "Albornoz" },
            { "Toallero", "Toalla" },
            { "Estante", "." },
            { "Ducha", "Champu" }
        }; //bathroom
        _orderHouse.Add("Bathroom", bath);
    }

    public bool Data()
    {
        print("Corrects: " + _totalCorrects);
        print("Caught: " + _totalCaught);
        print("Mistakes: " + _totalMistakes);
        print("Objects: " + _totalObjects);
        print("Doors: " + _totalDoorsOpened);
        print("Time: " + _time);
        print("FeedBack: " + _feedBack);

        Tracker.T.setVar("FeedBack", _feedBack);
        Tracker.T.setVar("Time", _time);
        Tracker.T.setVar("Corrects", _totalCorrects);
        Tracker.T.setVar("Mistakes", _totalMistakes);
        Tracker.T.setVar("Doors", _totalDoorsOpened);
        Tracker.T.Completable.Completed("house", CompletableTracker.Completable.Level, (_totalCorrects == _totalObjects), _totalCorrects);

        return (_totalCorrects == _totalObjects);
    }


    public Dictionary<string, Dictionary<string, string>> OrderHouse
    {
        get { return _orderHouse; }
        set { _orderHouse = value; }
    }

    public Dictionary<string, Dictionary<string, string>> House
    {
        get { return _house; }
        set { _house = value; }
    }

    public int TotalCorrects
    {
        get { return _totalCorrects; }
        set { _totalCorrects = value; }
    }

    public int TotalCaught
    {
        get { return _totalCaught; }
        set { _totalCaught = value; }
    }

    public int TotalMistakes
    {
        get { return _totalMistakes; }
        set { _totalMistakes = value; }
    }

    public int TotalDoorsOpened
    {
        get { return _totalDoorsOpened; }
        set { _totalDoorsOpened = value; }
    }

    public int TotalObjects
    {
        get { return _totalObjects; }
        set { _totalObjects = value; }
    }

    public int FeedBack
    {
        get { return _feedBack; }
        set { _feedBack = value; }
    }

    public string Room
    {
        get { return _room; }
        set { _room = value; }
    }
}
