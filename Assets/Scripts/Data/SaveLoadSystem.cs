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
            _data.Type.Add((int)_itemData[i].itemType);
            _data.Count.Add(_itemData[i].itemCount);
        }

        string _json = JsonUtility.ToJson(_data, false);
        File.WriteAllText(Application.persistentDataPath + "/Data.json", _json);
    }

    public List<ItemData> Load()
    {
        if (!Exist()) return null;

        string _json = File.ReadAllText(Application.persistentDataPath + "/Data.json");

        SaveData _data = JsonUtility.FromJson<SaveData>(_json);
        List<ItemData> _loadInfo = new List<ItemData>();

        for (int i = 0; i < _data.Type.Count; i++)
        {
            _loadInfo.Add(new ItemData()
            {
                itemCount = _data.Count[i],
                itemType = (DataController.ItemTypes)_data.Type[i]
            });
        }

        return _loadInfo;
    }

    private bool Exist()
    {
        if (!File.Exists(Application.persistentDataPath + "/Data.json") ||
            File.ReadAllText(Application.persistentDataPath + "/Data.json").Length <= 0)
        {
            FileStream _fs = File.Create(Application.persistentDataPath + "/Data.json");
            _fs.Close();
            return false;
        }

        return true;
    }
}

public class SaveData
{
    public List<int> Type = new List<int>();
    public List<int> Count = new List<int>();
}