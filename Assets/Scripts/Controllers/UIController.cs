using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Joystick characterJoystick;
    public List<DataPanel> dataPanels;

    public void UpdateDataPanel(DataController.ItemTypes _itemType, float _count)
    {
        for (int i = 0; i < dataPanels.Count; i++)
            if (dataPanels[i].itemType == _itemType)
                dataPanels[i].itemCountText.text = _count.ToString();
    }
}

