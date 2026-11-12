using UnityEngine;

public class DamagePractice : MonoBehaviour
{
    public int attack;
    public int defense;
    public bool isCritical;
    public bool targetIsBoss;

    [ContextMenu("데미지")]
    void Calc()
    {
        int damage = attack - defense;
        damage = Mathf.Max(damage, 1);

        if (isCritical)
        {
            damage = 2 * damage;
        }

        if (targetIsBoss)
        {
            damage = 2/damage;
        }
        
        Debug.Log(damage);

    }

}
