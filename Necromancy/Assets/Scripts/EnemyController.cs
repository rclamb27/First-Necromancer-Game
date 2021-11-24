using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{


    public int maxHealth = 100;

    int currentHealth;




    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private bool moving;
    private Animator anim;
    
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
  
    private Vector3 moveDirection;
    private Vector2 lastMove;


    private float randX;
    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;
    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        /*
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            //myRigidbody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                randX = Random.Range(-1f, 1f);
                myRigidbody.velocity = new Vector2(randX * moveSpeed, myRigidbody.velocity.y);
                lastMove = new Vector2(randX, 0f);
            }
        }
      
        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        anim.SetFloat("MoveX", randX);
        anim.SetBool("moving", moving);
        anim.SetFloat("LastX", lastMove.x);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
        }
    }
        */

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        anim.SetBool("IsDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}