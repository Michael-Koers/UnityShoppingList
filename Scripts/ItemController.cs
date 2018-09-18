using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    public bool done = false;
    private string itemName;


    public void SetItemName(string name)
    {
        itemName = name;
        UpdateText(itemName);
    }

    public void SwitchStatus()
    {
        done = !done;

        if (done)
        {
            UpdateText(StrikeThrough(itemName));
        }
        else
        {
            UpdateText(itemName);
        }
    }

    void UpdateText(string text)
    {
        GetComponentInChildren<Text>().text = text;
    }

    private string StrikeThrough(string s)
    {
        string strikethrough = "";
        foreach (char c in s)
        {
            strikethrough = strikethrough + c + '\u0336';
        }
        return strikethrough;
    }

}
