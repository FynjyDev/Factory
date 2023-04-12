using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public enum ItemTypes { box, coin }
    public List<ItemData> ItemsData;

    private UIController UIController => SingletonController.singletonController.UIController;
    private SaveLoadSystem saveLoadSystem => SingletonController.singletonController.SaveLoadSystem;

    public void Start()
    {
        LoadAllData();
    }

    public void ChangeItemData(ItemTypes _itemType, int _changeValue)
    {
        ItemData _data = FindDataByType(_itemType);
        _data.itemCount += _changeValue;

        UIController.UpdateDataPanel(_itemType, _data.itemCount);
        saveLoadSystem.Save(ItemsData);
    }

    public ItemData FindDataByType(ItemTypes _itemType)
    {
        ItemData _data = new ItemData();

        for (int i = 0; i < ItemsData.Count; i++)
            if (ItemsData[i].itemType == _itemType) _data = ItemsData[i];

        return _data;
    }

    private void LoadAllData()
    {
        List<ItemData> _loadInfo = saveLoadSystem.Load();

        if (_loadInfo != null && _loadInfo.Count > 0)ItemsData = _loadInfo;
        else saveLoadSystem.Save(ItemsData);

        for (int i = 0; i < ItemsData.Count; i++)
            UIController.UpdateDataPanel(ItemsData[i].itemType, ItemsData[i].itemCount);
    }
}
[System.Serializable] public class ItemData
{
    public DataController.ItemTypes itemType;
    public int itemCount;
}
