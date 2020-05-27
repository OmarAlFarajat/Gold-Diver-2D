using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

	private Rigidbody2D myRigidBody;
	private Animator myAnim;

    // Used for wrapping
    private Renderer[] renderers;
    public Text GoldCarried, GoldCollected, OxygenTanks, Lives, Level, Nitro;

    public GameObject bubbles;
    public GameObject death;
    public GameObject nitroExplosion;

    private bool moving = false;
    private bool nitroMode = false;
    private bool isWrappingX = false;

    public static int nitro = 0;
    public static int level = 1;
    public static int goldCarried = 0;
    public static int goldCollected = 0;

    [SerializeField]
    private float speedMod = 0;

    [SerializeField]
    private float moveSpeed = 2;

    [SerializeField]
    private int oxygenTanks = 3;

    [SerializeField]
    private int lives = 2;
  
    [SerializeField]
    private float nitroTime = 5;

    [SerializeField]
    private float thrust = 10f;

    [SerializeField]
    private float moveDelay = 0.5f;

    [SerializeField]
    private float timeInterval = 15;

    private float nitroStart = 0;
    private float startTime = 0;

    void Start (){
        startTime = Time.time; 
		myRigidBody = GetComponent<Rigidbody2D> ();	
		myAnim = GetComponent<Animator> ();
        renderers = GetComponentsInChildren<Renderer>();
        oxygenTanks = 3;
        lives = 2;
        level = 1;
        nitro = 0;
        startTime = Time.time;
        nitroStart = 0;
        goldCarried = 0;
        goldCollected = 0;
    }
	
	void FixedUpdate (){

        ScreenWrap();
        resetMoveTimer();
		controllerManager ();
		myAnim.SetFloat ("Speed", Mathf.Abs(myRigidBody.velocity.x));
        GoldCarried.text = goldCarried.ToString();
        GoldCollected.text = goldCollected.ToString();
        Level.text = level.ToString();
        Lives.text = lives.ToString();
        OxygenTanks.text = oxygenTanks.ToString();
       
        if(Nitro != null)
        Nitro.text = nitro.ToString();

        // Increases the difficulty level every 15 seconds. The level number itself is used directly in calculations that affect enemy spawn and movement rates. 
        if (startTime > 0 && Time.time - startTime > timeInterval)
        {
            startTime = Time.time; 
            level++;
        }
    }

    void controllerManager (){
        // Regular movement
        if (!nitroMode)
        {
            if (Input.GetAxisRaw("Horizontal") > 0f && !moving)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                myRigidBody.AddForce(Vector2.right * thrust * 0.5f, ForceMode2D.Impulse);
                moving = true;
                Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f && !moving)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                myRigidBody.AddForce(Vector2.left * thrust * 0.5f, ForceMode2D.Impulse);
                moving = true;
                Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (Input.GetAxisRaw("Vertical") > 0f && !moving)
            {
                myRigidBody.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
                moving = true;
                Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (Input.GetAxis("Vertical") < 0f && !moving)
            {
                myRigidBody.AddForce(Vector2.down * thrust, ForceMode2D.Impulse);
                moving = true;
                Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            }else if (Input.GetKeyDown("space"))
            {
                // Initiates nitro mode with animation for visual queue. 
                if (nitro > 0 && nitroMode == false)
                {
                    Instantiate(nitroExplosion, gameObject.transform.position, gameObject.transform.rotation);
                    nitro--;
                    nitroStart = Time.time; 
                    nitroMode = true;
                }
            }
        }
        // Nitro movement
        else
        {
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                movePlayer();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                movePlayer();
            }
            else if (Input.GetAxisRaw("Vertical") > 0f)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, moveSpeed, 0f);
            }
            else if (Input.GetAxis("Vertical") < 0f)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, -moveSpeed, 0f);
            }
        }
        // Exit out of nitro mode with visual queue
        if(nitroMode == true && Time.time - nitroStart > nitroTime) {
            Instantiate(nitroExplosion, gameObject.transform.position, gameObject.transform.rotation);
            nitroMode = false;
        }

    }

    // Helper to controllerManager()
    void movePlayer(){
		if (transform.localScale.x == 1) {
			myRigidBody.velocity = new Vector3 (moveSpeed + speedMod, myRigidBody.velocity.y, 0f);	
		} else {
		myRigidBody.velocity = new Vector3 (- (moveSpeed + speedMod), myRigidBody.velocity.y, 0f);
		}	
	}

    // Helper a small delay to movement
	void resetMoveTimer(){
		if (moveDelay <= 0) {
			moveDelay = 1f;
			moving = false;
			speedMod = 0;
		} else if(moving) {
			moveDelay -= Time.deltaTime;
		}	
	}

    // Overburdened function. 
    public void hurt()
    {
        oxygenTanks--;
        gameObject.GetComponent<Animator>().Play("PlayerHurt");
        OxygenTanks.text = oxygenTanks.ToString();

        // Players loses their last oxygen tank. Do they have an extra life? 
        if (oxygenTanks == 0)
        {
            // Ultimate death
            if (lives == 0) {
                Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
            // Another chance...
            else
            {
                lives--;
                oxygenTanks = 3;
                nitroMode = false; 
                myRigidBody.mass -= goldCarried;
                goldCarried = 0;
                Instantiate(death, gameObject.transform.position, gameObject.transform.rotation);
                transform.position = new Vector2(0.0f, 2.125f);
                Instantiate(nitroExplosion, gameObject.transform.position, gameObject.transform.rotation);
            }
        }

            

    }

    // Screen wrap logic, adapted from https://www.youtube.com/watch?v=3uI8qXDCmzU
    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            return; 
        }

        Vector3 newPosition = transform.position;
        // Similar use of camera properties to get bounds of the window
        if (newPosition.x > Camera.main.orthographicSize * Camera.main.aspect || newPosition.x < -Camera.main.orthographicSize * Camera.main.aspect)
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }
        transform.position = newPosition; 

    }

    // Helper function to screen wrap
    bool CheckRenderers()
    {
        foreach(Renderer renderer in renderers)
            if (renderer.isVisible)
                return true; 
        return false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Exchange of gold from player to submarine, including mass. 
        if (other.tag == "Submarine")
        {
            goldCollected += goldCarried;
            myRigidBody.mass -= goldCarried;
            goldCarried = 0;
        }
    }
}
