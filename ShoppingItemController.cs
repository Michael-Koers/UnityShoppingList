using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingItemController : MonoBehaviour
{

    [HideInInspector] public static int selected;
    public GameObject selectedPrefab;
    public GameObject shoppingItemPrefab;
    private List<GameObject> shoppingItems = new List<GameObject>();
    public List<string> items;

    // Use this for initialization
    void Start()
    {
        foreach (string item in items)
        {
            GameObject shoppingItem = Instantiate(shoppingItemPrefab, gameObject.transform);
            shoppingItem.transform.SetParent(gameObject.transform);
            shoppingItem.GetComponent<Text>().text = item;
            shoppingItems.Add(shoppingItem);
        }

        if (shoppingItems[0] != null)
        {
            selected = 0;
            GameObject selector = Instantiate(selectedPrefab, shoppingItems[selected].transform);
            selector.transform.SetParent(shoppingItems[selected].transform);

        }
    }

    public void UpSelected()
    {
        Debug.Log("Upped Selection");
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
        Debug.Log("Downed Selection");

        if (selected >= items.Count)
        {
            selected = items.Count;
        }
        else
        {
            selected++;
        }
    }
}
