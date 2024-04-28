using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BE : MonoBehaviour
{
    public Transform target; // ตัวแปรเก็บ GameObject ของ Player
    public GameObject bulletPrefab; // โปรเจคของกระสุน

    public float shootRange = 10f; // ระยะที่ Enemy สามารถยิงได้
    public float shootForce = 10f; // กำลังของกระสุน

    // Start is called before the first frame update
    void Start()
    {
        // สร้าง gameobject ของ Player โดยใช้ tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // ตรวจสอบว่า Player อยู่ในระยะยิงหรือไม่
        if (Vector3.Distance(transform.position, target.position) <= shootRange)
        {
            Shoot(); // เรียกใช้ฟังก์ชันยิงกระสุน
        }
    }

    // ฟังก์ชันสำหรับยิงกระสุน
    void Shoot()
    {
        // สร้าง gameobject กระสุนจาก prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        
        // คำนวณทิศทางของกระสุน
        Vector3 shootDirection = (target.position - transform.position).normalized;
        
        // ใส่ความเร็วให้กับกระสุน
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * shootForce;
    }
}