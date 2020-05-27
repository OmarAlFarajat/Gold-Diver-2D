using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour {
    public GameObject bubbles;
    private float spawnTime = 0f;

    [SerializeField]
    public float lifeTime = 10f;

	void Start () {
        spawnTime = Time.time; 
	}
	
	void Update () {

        if (Time.time - spawnTime > lifeTime)
        {
            Destroy(gameObject);
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Logic for gold pick up and adding the corresponding amount to player's inventory. Probably a better way to do this! 
        if (other.tag == "Player")
        {
            if(gameObject.tag == "GoldSmall")
            {
                other.attachedRigidbody.mass += 1;
                PlayerController.goldCarried += 1;
            }
            else if(gameObject.tag == "GoldMedium")
            {
                other.attachedRigidbody.mass += 2;
                PlayerController.goldCarried += 2;
            }
            else if(gameObject.tag == "GoldLarge")
            {
                other.attachedRigidbody.mass += 10;
                PlayerController.goldCarried += 10;
            }
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(gameObject);
        }

    }


}
