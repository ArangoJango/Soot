using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Selection_Script : MonoBehaviour
{
    public GameObject ItemLInfo, ItemRInfo, ItemLFreischalten, ItemRFreischalten, ItemRbutton;

    public void ItemLInfoUp()
    {
        ItemLInfo.SetActive(true);
        ItemRbutton.SetActive(false);
    }

    public void ItemLInfoClose()
    {
        ItemLInfo.SetActive(false);
        ItemRbutton.SetActive(true);
    }
    public void ItemLFreischaltenn()
    {
        ItemLFreischalten.SetActive(true);
    }
    public void ItemLFreischaltennein()
    {
        ItemLFreischalten.SetActive(false);
    }
    public void ItemRInfoUp()
    {
        ItemRInfo.SetActive(true);
    }
    public void ItemRInfoClose()
    {
        ItemRInfo.SetActive(false);
    }
    public void ItemRFreischaltenn()
    {
        ItemRFreischalten.SetActive(true);
    }
    public void ItemRFreischaltennein()
    {
        ItemRFreischalten.SetActive(false);
    }
}
