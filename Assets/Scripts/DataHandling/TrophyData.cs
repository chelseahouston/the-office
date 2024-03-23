using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json; 
using UnityEngine;

public class TrophyData : MonoBehaviour

{
    public GameObject T1, T2, T3, T4, T5, T6, T7, T8, T9;
    public List<GameObject> trophyGameObjects = new List<GameObject>();
    public Dictionary<string, GameObject> Trophies = new Dictionary<string, GameObject>();
    public List<string> WonTrophies = new List<string>();
    private const string TrophyKey = "Trophies"; // for saving trophy data
    private static TrophyData instance;

    private void Awake()
    {
        // check if instance already exists
        if (instance == null)
        {
            // if not, make this the instance
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        }

    // Start is called before the first frame update
    void Start()
    {
        ResetTrophies();

        // test

        WinTrophy("Trophy01");
        WinTrophy("Trophy02");
        WinTrophy("Trophy03");
        WinTrophy("Trophy04");
        WinTrophy("Trophy05");
        WinTrophy("Trophy06");
        WinTrophy("Trophy07");
        WinTrophy("Trophy08");
        WinTrophy("Trophy09");

        LoadTrophies();
    }

    public void ResetTrophies()
    {
        SetTrophyDictionary();
        WonTrophies.Clear();
        trophyGameObjects.AddRange(new List<GameObject> { T1, T2, T3, T4, T5, T6, T7, T8, T9 });
        foreach (GameObject t in trophyGameObjects)
        {
            t.SetActive(false);
        }
        SaveTrophies(); // save the reset trophies

    }


    public void SetTrophyDictionary()
    {
        Trophies.Clear();
        Trophies.Add("Trophy01", T1);
        Trophies.Add("Trophy02", T2);
        Trophies.Add("Trophy03", T3);
        Trophies.Add("Trophy04", T4);
        Trophies.Add("Trophy05", T5);
        Trophies.Add("Trophy06", T6);
        Trophies.Add("Trophy07", T7);
        Trophies.Add("Trophy08", T8);
        Trophies.Add("Trophy09", T9);
    }

    public void AddTrophyToWonTrophies(string trophy)
    {
        WonTrophies.Add(trophy);
        SaveTrophies();
    }

    // save the user trophies as string
    public void SaveTrophies()
    {
        string serializedDeck = SerializeTrophies(WonTrophies);
        PlayerPrefs.SetString(TrophyKey, serializedDeck);
    }

    // retrieve user deck
    public void LoadTrophies()
    {
        string savedTrophies = PlayerPrefs.GetString(TrophyKey);

        // if there's a saved list of won trophies
        if (!string.IsNullOrEmpty(savedTrophies))
        {
            WonTrophies = DeserializeTrophies(savedTrophies);
        }
        else //if not, make a new one and save it (for first gameplay)
        {
            ResetTrophies(); // reset the won trophies to none
            
        }

        // for each trophy won set it's game object to true
        foreach (string trophy in WonTrophies)
        {
            if (Trophies.ContainsKey(trophy)) {
                GameObject t = Trophies[trophy];
                t.SetActive(true);
            }
        }
    }

    // JSON used to save the trophies
    private string SerializeTrophies(List<string> trophiesToSerialize)
    {
        string serializedTrophies = JsonConvert.SerializeObject(trophiesToSerialize, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        return serializedTrophies;
    }

    // for trophy retrieval
    private List<string> DeserializeTrophies(string serializedTrophies)
    {
        List<string> trophiesToDeserialize = JsonConvert.DeserializeObject<List<string>>(serializedTrophies);
        return trophiesToDeserialize;
    }

    // retrieve trophies by name string
    public virtual GameObject GetTrophyByName(string trophyName)
    {
        GameObject trophyObject;
        if (Trophies.TryGetValue(trophyName, out trophyObject))
        {
            return trophyObject;
        }
        return null;
    }

    private void OnApplicationQuit()
    {
        SaveTrophies();
    }

    public void WinTrophy(string trophy)
    {
        AddTrophyToWonTrophies(trophy);
    }
}
