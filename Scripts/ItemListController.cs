using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListController : MonoBehaviour
{
    public static int selected;

    public List<string> items;

    public GameObject shoppingItemPrefab;
    public GameObject selectedPrefab;
    private GameObject selectedObject;
    public GameObject DoUndoButton;

    public GameObject scrollView;

    private List<GameObject> shoppingItems = new List<GameObject>();

    void Start()
    {
        foreach (string item in items)
        {
            GameObject shoppingItem = Instantiate(shoppingItemPrefab, this.gameObject.transform);
            shoppingItem.transform.SetParent(this.gameObject.transform);
            shoppingItems.Add(shoppingItem);
            shoppingItem.GetComponent<ItemController>().SetItemName(item);
        }

        if (shoppingItems != null && shoppingItems[0] != null)
        {
            selected = 0;
            selectedObject = Instantiate(selectedPrefab, shoppingItems[0].gameObject.transform);
        }
        else
        {
            Debug.Log("FATAL -- No shoppinglist found");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        UpdateSelected();
    }

    void UpdateSelected()
    {
        Destroy(selectedObject);
        selectedObject = Instantiate(selectedPrefab, shoppingItems[selected].gameObject.transform);
        DoUndoButton.GetComponent<DoneController>().SetItem(shoppingItems[selected]);


        //If the y position of the selected item is higher than the scrollviews y pos (thus out of screen on top)
        //OR
        //If the y pos of the selected item is lower than the scrollviews y pos (thus out of screen at bottom)
        //Snap to the newly selected item
        //if (shoppingItems[selected].transform.position.y > scrollView.transform.position.y ||
        //    shoppingItems[selected].transform.position.y < scrollView.transform.position.y - 800)//scrollView.transform.lossyScale.y)
        //{
        //    SnapToItem(shoppingItems[selected]);
        //}
    }

    public void UpSelected()
    {
        Debug.Log("UP CLICKED");

        selected--;

        if (selected <= 0)
        {
            selected = 0;
        }

        UpdateSelected();
    }

    public void DownSelected()
    {
        Debug.Log("DOWN CLICKED");

        selected++;

        if (selected >= shoppingItems.Count - 1)
        {
            selected = shoppingItems.Count - 1;
        }

        UpdateSelected();
    }

    //Can't get it to work :/

    //Idea: When selecting out of scroll view, snap the list to the currently selected item.
    private void SnapToItem(GameObject item)
    {
        Debug.Log("snap triggered");

        float scrollSize = 1f / this.gameObject.transform.childCount;

        Debug.Log("scrollsize = " + scrollSize);

        //Smaller -> lower becuase negative y-axis
        if (shoppingItems[selected].transform.position.y > scrollView.transform.position.y)
        {
            Debug.Log("snap downwards");
            //0f is at the bottom
            scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = (scrollSize * selected);
        }
        else
        {
            Debug.Log("snap upwards");

            //1f is at the top
            scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = Mathf.Lerp(scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition, 100, 100 * scrollView.GetComponent<ScrollRect>().elasticity * Time.deltaTime);
            //scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f - (scrollSize * selected);
        }
    }
}
