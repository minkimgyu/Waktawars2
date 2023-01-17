using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public NumberData numberData;
    public BoolData boolData;
}

[System.Serializable]
public class NumberData : SerializableDictionary<string, float> { };

[System.Serializable]
public class BoolData : SerializableDictionary<string, bool> { };

public class Database : MonoBehaviour
{
    public static Database instance;

    public Data data;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void AddData(string key, object value)
    {
        //if(data.ContainsKey(key) == true) // �ش� �����͸� ������ �ִ� ���
        //{

        //}
        //else // ���� ���
        //{
        //   // data.Add(key, value);
        //}
    }

    public void DeleteData()
    {

    }

    public void ResetData()
    {

    }
}
