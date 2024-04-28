using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
   
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPoint;


    [Header("Attack Parameters")] [SerializeField]
    private float colldierDistance;

    [SerializeField] private BoxCollider2D boxCollider;
    
    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    private float cooldownTimer = Mathf.Infinity;
    
    

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight() && cooldownTimer >= attackCooldown)
        {
            Shoot();
            cooldownTimer = 0f;
        }
    }

    /*private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            PolygonCollider2D.bounds.center + transform.right * range * transform.localScale.x * colldierDistance,
            new Vector3(PolygonCollider2D.bounds.size.x * range, PolygonCollider2D.bounds.size.y, PolygonCollider2D.bounds.size.z), 0,
            Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }*/
    public bool PlayerInSight()
    {
        // หาขนาดของ Collider ของ Enemy
        Vector3 enemyColliderSize = PolygonCollider2D.bounds.size;

        // หาตำแหน่งของศูนย์กลางของ BoxCast โดยใช้ค่าระยะและปรับขนาดตามขนาดของ Collider และขนาดของ BoxCast
        Vector2 boxCastCenter = (Vector2)PolygonCollider2D.bounds.center + (Vector2)transform.right * range * transform.localScale.x * colldierDistance;

        // สร้าง BoxCast
        RaycastHit2D hit = Physics2D.BoxCast(boxCastCenter, enemyColliderSize * range, 0, Vector2.left, 0, playerLayer);

        // ส่งคืนผลลัพธ์ว่ามีการชนกับ Player หรือไม่
        return hit.collider != null;
    }


    private void Shoot()
    {
        // Find the direction to the player
        Vector2 playerDirection = (PlayerPosition() - (Vector2)transform.position).normalized;

        // Instantiate projectile at shoot point
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        // Set projectile velocity towards the player
        projectile.GetComponent<Rigidbody2D>().velocity = playerDirection * projectile.GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    private Vector2 PlayerPosition()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, range, playerLayer);
        if (playerCollider != null)
        {
            return playerCollider.transform.position;
        }
        else
        {
            return Vector2.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colldierDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y,boxCollider.bounds.size.z));
    }
}



