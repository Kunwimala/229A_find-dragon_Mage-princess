using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // ประกาศตัวแปรเก็บ prefab ของ projectile
    public float shootForce = 10f; // ความเร็วในการยิง projectile
    public float shootingRange = 10f; // ระยะห่างสูงสุดที่จะยิง

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
}