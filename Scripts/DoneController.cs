using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneController : MonoBehaviour
{

    private Text text;
    private bool done;
    private GameObject selectedItem;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    public void SetItem(GameObject item)
    {
        selectedItem = item;
        UpdateButton();
    }

    public void SwitchStatus()
    {
        selectedItem.GetComponent<ItemController>().SwitchStatus();
        UpdateButton();
    }

    private void UpdateButton()
    {
        if (selectedItem.GetComponent<ItemController>().done)
        {
            text.text = "Undo";
        }
        else
        {
            text.text = "Done";
        }
    }

}
