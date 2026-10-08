using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireCooldown = 0.2f;   // 연속 클릭 간격

    float lastFireTime = -999f;
    bool isFiring = false;
    public void OnAttack(InputValue value)
    {
        // 마우스 버튼을 누르면 true, 떼면 false가 됩니다.
        isFiring = value.isPressed;     
    }
    void Update()
    {
        // 마우스 왼쪽 버튼이 눌려있는 상태인지 매 프레임 실시간으로 체크
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            if (Time.timeScale == 0f) return;   // 게임 오버면 무시
            if (Time.time < lastFireTime + fireCooldown) return;

            lastFireTime = Time.time;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}
