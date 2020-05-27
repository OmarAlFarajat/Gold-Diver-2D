using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{

    private GameObject Player;
    public GameObject bubbles;

    public float speed = 0f;

    // 
    private float spawnTime = 0;
    private float despawnTime = 0;

    void Start()
    {
        Player = GameObject.Find("Player");

        spawnTime = Time.time;
        despawnTime = Random.Range(8, 12);
        speed = Random.Range(0.5f, 1.0f) * PlayerController.level * 0.075f;
    }

    void Update()
    {
        // As long as player exists (not dead), then follow. 
        if (Player != null)
        {
            // This will determine what direction the octopus will face when chasing the player
            if (Player.transform.position.x < transform.position.x)
                transform.localScale = new Vector3(-1f, 1f, 1f);
            else
                transform.localScale = new Vector3(1f, 1f, 1f);

            // Move towards player
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }

        // Octopus disappears after a fixed amount of time. 
        if (Time.time - spawnTime > despawnTime)
        {
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
