using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public List<GameObject> Items;

    [SerializeField]
    private float itemWidth, padding;

    [SerializeField]
    private GameObject itemPrefab;

    void Start()
    {
        Items.Clear();
    }

    public void GetItem(float rot, float sca, Sprite img)
    {
        GameObject newItem = Instantiate(itemPrefab, this.gameObject.transform);
        newItem.GetComponent<Item>().set(Items.Count, rot, sca, img);
        Items.Add(newItem);
        for(int i = 0; i < Items.Count; i++)
        {
            float xpos = -((itemWidth * Items.Count + padding * (Items.Count - 1)) / 2) + (itemWidth / 2) + (itemWidth + padding) * i;
            Items[i].transform.localPosition = new Vector3(xpos, 0.0f, 0.0f);
        }
    }

    public void selectItem(int id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (i != id) { Items[i].GetComponent<Item>().disSelect(); }
        }
    }
}
