using System.Runtime.InteropServices;
using UnityEngine;

public class Lesson09 : MonoBehaviour
{
    public string itemName = "포션";
    public int price = 30;
    public float discount = 0.5f;
    public bool isSoldOut = false;

    [ContextMenu("가격")]
    void ShowPrice()
    {
        float finalPrice = price * discount;
        Debug.Log(itemName + " " + finalPrice);
    }

    [ContextMenu("오버플로")]
    void Overflow()
    {
        int gold = int.MaxValue;
        Debug.Log(gold);
        gold = gold + 1;
        Debug.Log(gold);
        byte red = 255;
        red++;
        Debug.Log(red);
    }


}
