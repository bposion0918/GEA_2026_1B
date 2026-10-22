using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("체력 정보 리스트")]
    [Tooltip("최대 체력")]
    public int maxHp = 3;
    [Tooltip("오브젝트의 현재 체력")]
    public int currentHp;
    [Header("플레이어만 연결")]
    [Tooltip("적 오브젝트에는 붙이지 않아도 된다")]
    public Slider hpSlider; 
    public static int killCount;
    public float invincibleTime = 0f; 
    float lastHitTime = -999f;
    public GameObject dropPrefab;
    public float dropChance = 0.3f;
    public GameObject hitEffect;

    void Start()
    {
        currentHp = maxHp;
        UpdateBar();
    }
    public void TakeDamage(int damage)
    {
        if (currentHp <= 0) return;
        if (Time.time < lastHitTime + invincibleTime) return;
        lastHitTime = Time.time;

        currentHp -= damage;
        Debug.Log(name + " HP: " + currentHp);
        UpdateBar();
        Vector3 hitPos = transform.position + Vector3.up;
        if (hitEffect != null)
            Instantiate(hitEffect, hitPos, Quaternion.identity);


        if (currentHp <= 0) Die();
        else Blink();
    }
    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, maxHp);
        UpdateBar();
    }

    void UpdateBar()
    {
        if (hpSlider != null)
            hpSlider.value = (float)currentHp / maxHp;
    }

    void Die()
    {
             if (CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }

        else
        {
            if (dropPrefab != null && Random.value < dropChance)
            {
                Vector3 pos = transform.position + Vector3.up * 0.5f;
                Instantiate(dropPrefab, pos, Quaternion.identity);
            }

            killCount++;

            Destroy(gameObject);
        }
    }
    void Blink()
    {
        SetVisible(false);
        Invoke(nameof(ShowAgain), 0.1f);
    }

    void ShowAgain()
    {
        SetVisible(true);
    }

    void SetVisible(bool on)
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = on;
    }

}
