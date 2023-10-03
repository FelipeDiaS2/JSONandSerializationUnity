using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{

    public Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavingData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/positionXData.data");

        SaveData saveData = new SaveData();
        saveData.positionX = transform.position.x;

        bf.Serialize(fs, saveData);
        fs.Close();

        print(saveData.positionX);
    }

    public void LoadData()
    {

        if (File.Exists(Application.persistentDataPath + "/positionXData.data"))
        {

           BinaryFormatter bf = new BinaryFormatter();

           FileStream fs = File.Open(Application.persistentDataPath + "/positionXData.data", FileMode.Open);

           SaveData data = (SaveData)bf.Deserialize(fs);
            fs.Close();

            Position.x = data.positionX;
            transform.position = Position;

            print(Position);
        }

    }

    
}

[Serializable]
 class SaveData
{

    public float positionX;

}
