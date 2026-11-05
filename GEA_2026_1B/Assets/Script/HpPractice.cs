using UnityEngine;

public class HpPractice : MonoBehaviour
{
    public int currentHp;
    public int maxHp;
    [ContextMenu("체력")]
  void PrintHp()
  {
        int X = currentHp * 100 / maxHp;
        Debug.Log("Hp"+ X + "%");
  }
}
