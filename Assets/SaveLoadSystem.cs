using Newtonsoft.Json;
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
        File.WriteAllText(Application.persistentDataPath + "/Data.json", json);
    }

    public List<ItemData> Load()
    {
        if (!Exist()) return null;

        string json = File.ReadAllText(Application.persistentDataPath + "/Data.json");

        SaveData data = JsonUtility.FromJson<SaveData>(json);
        List<ItemData> _loadInfo = new List<ItemData>();

        for (int i = 0; i < data.type.Count; i++)
        {
            _loadInfo.Add(new ItemData()
            {
                itemCount = data.count[i],
                itemType = (DataController.ItemTypes)data.type[i]
            });
        }

        return _loadInfo;
    }

    private bool Exist()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data.json") ||
            File.ReadAllText(Application.persistentDataPath + "/Data.json").Length <= 0)
        {
            FileStream fileStream = File.Create(Application.persistentDataPath + "/Data.json");
            fileStream.Close();
            return false;
        }

        return true;
    }
}

public class SaveData
{
    public List<int> type = new List<int>();
    public List<int> count = new List<int>();
}