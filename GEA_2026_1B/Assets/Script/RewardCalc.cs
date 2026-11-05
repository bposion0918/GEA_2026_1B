using UnityEngine;

public class RewardCalc : MonoBehaviour
{
    public int playSeconds = 3725;
    public int gold = 1234;
    public int members = 4;
    public int kills = 7;
    public int expPerKill = 35;
    public int totalDamage = 250;
    public int hits = 20;
    public float expRate = 1.5f;

    [ContextMenu("정산")]
    void timeReward()
    {
        int hour = playSeconds / 3600;
        int minite = (playSeconds - 3600 ) / 60;
        int seconds = (playSeconds - 3600) % 60;
        Debug.Log(hour + "시간" + minite + "분" + seconds + "초");

        int people = gold / 4;
        int bonus = gold % 4;
        Debug.Log("1인당" + people + "G"+","+ "보너스" + bonus + "G");

        int Exp = expPerKill * kills;
        int ExpRate = (int)(Exp * expRate);
        Debug.Log("경험치" + ExpRate +" (기본" + Exp + ")");

        int nextExp = 100-(ExpRate % 100);
        Debug.Log("다음 레벨까지" + nextExp);

        double result = (double)totalDamage / hits;
        Debug.Log("평균 데미지 " + result);
    }
}

