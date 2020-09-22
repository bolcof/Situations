using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int id;

    public GameObject content;
    private bool isSelected = false;

    [SerializeField]
    private Sprite normalFrame, selectedFrame;

    public void set(int i, float rot, float sca, Sprite img)
    {
        id = i;
        content.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, rot);
        content.transform.localScale = Vector3.one * sca;
        content.GetComponent<SpriteRenderer>().sprite = img;
    }

    public void select()
    {
        if (!isSelected)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = selectedFrame;
            isSelected = true;
            GameObject.Find("ItemHolder").GetComponent<ItemHolder>().selectItem(id);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = normalFrame;
            isSelected = false;
        }
    }

    public void disSelect()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalFrame;
        isSelected = false;
    }
}
