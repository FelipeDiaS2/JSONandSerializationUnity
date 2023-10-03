using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSave : MonoBehaviour
{

    public string dataPath;

    public Info data;

    // Start is called before the first frame update
    void Start()
    {
        data = new Info();

        //data.name = "Felipe";

        //data.age = 19;

        dataPath = Path.Combine(Application.dataPath,"data.json");

        //Save();

        Load();

        print("Name: " + data.name + "," + " " + "Age: " + data.age);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Save()
    {
        string jsonS = JsonUtility.ToJson(data);
        
        File.WriteAllText(dataPath, jsonS);
    }

    void Load()
    {
        string jsonS = File.ReadAllText(dataPath);

        JsonUtility.FromJsonOverwrite(jsonS, data);
    }

}

public class Info 
{
    public string name;

    public int age;


}

