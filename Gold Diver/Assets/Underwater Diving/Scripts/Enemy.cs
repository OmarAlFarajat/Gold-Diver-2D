using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private PlayerController thePlayer;
    public GameObject bubbles;

    private float speed = 0.0f;

	private Rigidbody2D myRigidbody;

    // ***
    private Renderer[] renderers;
    private bool isWrappingX = false;

    // 
    private float spawnTime = 0;
    private float despawnTime = 0; 


    // Use this for initialization
    void Start () {
        renderers = GetComponentsInChildren<Renderer>();
        thePlayer = FindObjectOfType<PlayerController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        isWrappingX = false;
        spawnTime = Time.time;
        despawnTime = Random.Range(8,12);
        speed = Random.Range(0.25f, 0.5f) * PlayerController.level * 0.075f;
	}

	// Update is called once per frame
	void FixedUpdate (){
        ScreenWrap();
        myRigidbody.velocity = new Vector3 (myRigidbody.transform.localScale.x * speed, myRigidbody.velocity.y, 0f);
        // Destroy after fixed amount of time. 
        if (Time.time - spawnTime > despawnTime)
        {
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    // Screen wrap logic, should have maybe just made a separate script for this. It's duplicated in PlayerController. 
    void ScreenWrap()
    {
        bool isVisible = CheckRenderers();

        if (isVisible)
        {
            isWrappingX = false;
            return;
        }

        Vector3 newPosition = transform.position;
        if (newPosition.x > Camera.main.orthographicSize * Camera.main.aspect || newPosition.x < -Camera.main.orthographicSize * Camera.main.aspect)
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }
        transform.position = newPosition;

    }

    bool CheckRenderers()
    {
        foreach (Renderer renderer in renderers)
            if (renderer.isVisible)
                return true;
        return false;
    }
}
