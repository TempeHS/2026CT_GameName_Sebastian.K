using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 5f;
   private float MovementX;
   private Rigidbody2D rb;
   private Vector2 moveInput;
   private bool leftPunch;
   private bool rightPunch;
   public float Health, MaxHealth;
   Animator anim;
   private float move;
   private float speed;
   private Animator WalkingAnim;
   private Animator AttackingAnim;
   private bool isWalking;
   private bool LeftPunch;
   private bool RightPunch;
   public GameObject attackPoint;
   public float radius;
   //private bool IsFacingRight = false;
   [SerializeField] public LayerMask enemies;

   [SerializeField]
    private HealthBarUI healthBar;
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      healthBar.SetMaxHealth(MaxHealth);
      anim = gameObject.GetComponent<Animator>();
   }

   // Update is called once per frame
   void Update()
   {
        move = Input.GetAxisRaw("Horizontal");
       rb.linearVelocity = moveInput * moveSpeed;
       rb.linearVelocity = new Vector2(move * speed,rb.linearVelocity.y);
       if (move > .1f || move > -.1f)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }

        if(Input.GetKeyDown("a"))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

         if(Input.GetKeyDown("d"))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

         if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        if (Input.GetKey("a"))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }
        if (Input.GetKey("d"))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }
         if (Input.GetKey("s"))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }
        if (Input.GetKey("w"))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }   
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetTrigger("Walk");
            isWalking = true;
        }

        if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("leftpunch");
                isAttacking = true;
                Pause2sec();
            }
        if (Input.GetMouseButtonDown(1))
            {
                anim.SetTrigger("rightpunch");
                isAttacking = true;
                Pause2sec();
            }


       if (Input.GetKeyDown("l"))
        {
            SetHealth(-10f);
        }

        if (Input.GetKeyDown("p"))
        {
            SetHealth(10f);
        }
   }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
        }
    }
   public void Move(InputAction.CallbackContext context)
   {
       moveInput = context.ReadValue<Vector2>();
   }

   public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }

    IEnumerator Pause2sec()
    {
        yield return new WaitForSeconds (2f);
    }
}
