using UnityEngine;

public class StatPractice : MonoBehaviour
{

    public string playwrName;
    public int level;
    public float attack;
    public bool isBoss;

    [ContextMenu("스탯")]
    void ShowStat()
    {
        Debug.Log(playwrName);

        Debug.Log(level);

        Debug.Log(attack);

        Debug.Log(isBoss);

    }

}
