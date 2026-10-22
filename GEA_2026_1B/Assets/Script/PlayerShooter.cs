using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireCooldown = 0.2f;   


    float lastFireTime = -999f;
    bool isFiring = false;
    public void OnAttack(InputValue value)
    {
        isFiring = value.isPressed;     
    }
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            if (Time.timeScale == 0f) return;
            if (Time.time < lastFireTime + fireCooldown) return;

            lastFireTime = Time.time;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}
