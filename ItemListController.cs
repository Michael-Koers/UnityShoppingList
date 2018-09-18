using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListController : MonoBehaviour
{
    public static int selected;

    public List<string> items;

    public GameObject shoppingItemPrefab;
    private List<GameObject> shoppingItems = new List<GameObject>();

    void Start()
    {
        foreach (string item in items)
        {
            GameObject shoppingItem = Instantiate(shoppingItemPrefab, this.gameObject.transform);
            shoppingItem.transform.SetParent(this.gameObject.transform);
            shoppingItems.Add(shoppingItem);
            shoppingItem.GetComponentInChildren<Text>().text = item;
        }

        if (shoppingItems[0] != null)
        {
            selected = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpSelected()
    {
        Debug.Log("UP CLICKED");

        if (selected <= 0)
        {
            selected = 0;
        }
        else
        {
            selected--;
        }
    }

    public void DownSelected()
    {
        Debug.Log("DOWN CLICKED");

        if (selected >= shoppingItems.Count)
        {
            selected = shoppingItems.Count;
        }
        else
        {
            selected++;
        }
    }
}
