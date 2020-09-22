using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    [SerializeField]
    private float ro, sc;

    public Sprite img;

    public void tapIt()
    {
        img = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("ItemHolder").GetComponent<ItemHolder>().GetItem(ro, sc, img);
        this.gameObject.SetActive(false);
    }
}
