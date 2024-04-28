using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // ประกาศ prefab ของ projectile
    public Transform shootPoint; // จุดที่ bullet จะถูกยิง
    public float bulletSpeed = 10f; // ความเร็วของ bullet
    public float delayBetweenShots = 1f; // ระยะเวลาระหว่างการยิง
    public float bulletLifetime = 3f; // ระยะเวลาของชีวิตของ bullet

    private Transform player; // เก็บ reference ของ player

    private void Start()
    {
        // ค้นหา player โดยใช้ tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        // เริ่มเรียกใช้งานฟังก์ชัน ShootBullet โดยตรงหลังจากเริ่มเกม
        InvokeRepeating("ShootBullet", 0f, delayBetweenShots);
    }

    private void Update()
    {
        // ตรวจสอบว่า player มีหรือไม่
        if (player != null)
        {
            // ไม่ต้องทำอะไรใน Update ตอนนี้ เนื่องจากการยิงถูกเรียกใช้โดยใช้ InvokeRepeating แล้ว
        }
    }

    void ShootBullet()
    {
        // หาทิศทางไปยัง player
        Vector2 direction = (player.position - shootPoint.position).normalized;

        // คำนวณความเร็วของ bullet โดยใช้ CalculateprojectileVelocity
        Vector2 velocity = CalculateProjectileVelocity(shootPoint.position, player.position, 1f);

        // สร้าง projectile จาก prefab และเคลื่อนที่ตามทิศทางที่คำนวณได้
        GameObject bullet = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = velocity * bulletSpeed;
        
        // ลบ bullet หลังจากผ่านไปเวลา bulletLifetime
        Destroy(bullet, bulletLifetime);
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float t)
    {
        // คำนวณความเร็วตามแนวแกน X และ Y โดยใช้สมการการเคลื่อนที่แบบ projectile motion
        Vector2 distance = target - origin;
        float velocityX = distance.x / t;
        float velocityY = (distance.y / t) + (0.5f * Mathf.Abs(Physics2D.gravity.y) * t);

        return new Vector2(velocityX, velocityY);
    }
}
