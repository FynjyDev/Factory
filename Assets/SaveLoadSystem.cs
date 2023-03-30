using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public void Save(List<ItemData> _itemData)
    {
        SaveData _data = new SaveData();

        for (int i = 0; i < _itemData.Count; i++)
        {
            _data.type.Add((int)_itemData[i].itemType);
            _data.count.Add(_itemData[i].itemCount);
        }

        string json = JsonUtility.ToJson(_data, false);

        if (!File.Exists(Application.persistentDataPath + "/Data.json")) File.Create(Application.persistentDataPath + "/Data.json");

        File.WriteAllText(Application.persistentDataPath + "/Data.json", json);
    }

    public SaveData Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data.json"))
        {
            File.Create(Application.persistentDataPath + "/Data.json");
            return null;
        }

        string json = File.ReadAllText(Application.persistentDataPath + "/Data.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        return data;
    }
}

public class SaveData
{
    public List<int> type = new List<int>();
    public List<int> count = new List<int>();
}