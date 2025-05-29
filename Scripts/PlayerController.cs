using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 3f;
    public float jumpForce = 5f;
    public LayerMask enemyLayer;
    Animator animator;
    public float attackDuration = 1f;
    Rigidbody2D rb2d;
    private bool canMove = true;
    AudioSource audioSource;
    bool jump = false;
    bool gameStarted = false;
    bool grounded = false;
    public Light2D playerLight;
    public float attackRange = 0.5f;
    //public int attackDamage = 5;
    public Transform attackPoint;       // จุดโจมตีหน้าผู้เล่น
    private bool attacking = false;
    private bool isJumping = false;
    private SpriteRenderer spriteRenderer;
      public LayerMask groundLayer;
    public Transform groundCheck;
     public float groundCheckRadius = 0.2f;



    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
           spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        grounded = true;
        // attackArea = transform.GetChild(0).gameObject;
        Transform attackTransform = transform.Find("AttackArea");

        if (playerLight == null)
        {
            playerLight = GetComponentInChildren<Light2D>(); // หา Light 2D อัตโนมัติ
        }

        if (playerLight == null)
        {
            Debug.LogError("playerLight ไม่ถูกกำหนด!"); // แจ้งเตือนถ้าไม่มี
        }

    }
void Update()
{
    float moveInput = Input.GetAxisRaw("Horizontal");

    // Flip ตัวผู้เล่นซ้ายขวา
    if (spriteRenderer != null)
    {
        spriteRenderer.flipX = moveInput < 0;
    }
    grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
animator.SetBool("Grounded", grounded); // ส่งค่ากลับไป Animator ด้วยถ้ามีใช้


    // ขยับตัวถ้าอนุญาตให้ขยับ
        if (canMove)
        {
            transform.position += new Vector3(moveInput, 0, 0) * speed * Time.deltaTime;
            animator.SetBool("Walk", moveInput != 0);
        }

    // เริ่มเกมตอนกด Fire1
    if (Input.GetButtonDown("Fire1"))
    {
        if (!gameStarted)
        {
            gameStarted = true;
            animator.SetTrigger("Start");
        }
        animator.SetBool("Grounded", grounded);
    }
    if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumping = true;
            animator.SetTrigger("Jump");
        }

    // โจมตี
        if (Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, enemyLayer);
            if (enemy != null)
            {
                animator.SetTrigger("Attack");
                audioSource.Play();
                Attack(enemy.gameObject);
            }

            rb2d.velocity = Vector2.zero;
            animator.SetBool("Walk", false);
        }

    // เปิดไฟหากดับ
    if (playerLight != null && !playerLight.enabled)
    {
        playerLight.enabled = true;
    }
}

    void FixedUpdate()
    {

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce); // รีเซ็ตความเร็วแกน Y แล้วกระโดด
            jump = false;
            grounded = false;
        }
    }

    public void StopMovement()
    {
        canMove = false;
    }


    public void ResumeMovement()
    {
        canMove = true;
    }



    void Attack(GameObject enemy)
    {
         EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        attacking = true;
       

        // ทำดาเมจใส่ศัตรูทันที
       
        if (enemyHealth != null)
        {
             enemyHealth.TakeDamage(PlayerStats.attackDamage);
        }

        //cooldown ง่ายๆ ให้โจมตีได้อีกครั้งหลัง 0.5 วิ
        Invoke(nameof(ResetAttack), 0.5f);
    }

    void ResetAttack()
    {
        attacking = false;
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
}


  
}
