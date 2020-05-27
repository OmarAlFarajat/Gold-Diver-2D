using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    // 

    public GameObject bubbles;
    private float spawnTime = 0f;

    [SerializeField]
    public float lifeTime = 8f;

    void Start()
    {
        spawnTime = Time.time;
    }

    // Destroy after fixed amount of time if player doesn't pick it up
    void Update()
    {
        if (Time.time - spawnTime > lifeTime)
        {
            Destroy(gameObject);
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Destroy when player picks it up and add to their inventory
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            PlayerController.nitro += 1;
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }
}
