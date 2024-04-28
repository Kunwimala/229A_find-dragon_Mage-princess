using UnityEngine;


public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // ประกาศ prefab ของ projectile
    public Transform shootPoint; // จุดที่ bullet จะถูกยิง
    public float bulletSpeed = 10f; // ความเร็วของ bullet

    private Transform player; // เก็บ reference ของ player

    private void Start()
    {
        // ค้นหา player โดยใช้ tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // ตรวจสอบว่า player มีหรือไม่
        if (player != null)
        {
            // ทำการยิง bullet โดยเรียกใช้ฟังก์ชัน ShootBullet
            ShootBullet();
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


/*{
    public GameObject projectilePrefab; // ประกาศตัวแปรเก็บ prefab ของ projectile
    public float shootForce = 10f; // ความเร็วในการยิง projectile
    public float shootingRange = 10f; // ระยะห่างสูงสุดที่จะยิง
    [SerializeField] private Transform shootPoint;

    public Transform player; // เก็บ reference ของ player

    private void Start()
    {
        // หา player โดยใช้ tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // ตรวจสอบระยะห่างระหว่าง enemy กับ player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // ถ้าระยะห่างน้อยกว่าหรือเท่ากับระยะที่กำหนดให้ยิง
        if (distanceToPlayer <= shootingRange)
        {
            // เรียกฟังก์ชันยิง projectile
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // สร้าง projectile จาก prefab ที่กำหนด
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // ทำการยิง projectile ออกไป (ตัวอย่างเพิ่มเติม: ตั้งค่าความเร็วหรือทิศทางของ projectile ตามต้องการ)
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            // ตำแหน่งของ player ในลูกศร
            Vector3 direction = (player.position - transform.position).normalized;
            projectileRb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
}*/



        