using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData
{ 

    Dictionary<string, string> userData;

    public void Store(string key, string value)
    {
        if (userData.ContainsKey(key))
        {
            userData[key] = value;
        }
        else
        {
            userData.Add(key, value);
        }
    }

    public string GetData(string key)
    {
        string data;
        if (userData.ContainsKey(key))
        {
            data = userData[key];
        }
        else
        {
            data = "dataNotFound";
        }
        return data;
    }

    public Dictionary<string, string> getDataClone()
    {
        Dictionary<string, string> clonedData = new Dictionary<string, string>();

        foreach (KeyValuePair<string, string> entry in userData)
        {
            clonedData.Add(entry.Key, entry.Value);
        }

        return clonedData;
    }

    public void SetData(Dictionary<string, string> data)
    {
        userData = data;
    }
}
