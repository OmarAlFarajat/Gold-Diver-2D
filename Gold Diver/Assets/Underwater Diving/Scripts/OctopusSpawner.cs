using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusSpawner : MonoBehaviour
{
    // Rudementary prefab spawner. Similar to Enemy (shark), gold, and nitro. 

    public GameObject octopus;
    public GameObject bubbles; 
    public float spawnRate = 0f;
    float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        spawnRate = 20f / (PlayerController.level*0.5f);

        Vector3 newPosition = transform.position;
        float buffer = 1f;
        
        newPosition.x = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect + buffer, Camera.main.orthographicSize * Camera.main.aspect - buffer);
        newPosition.y = Random.Range(-Camera.main.orthographicSize + buffer * 0.5f, Camera.main.orthographicSize - buffer * 1.5f);
        transform.position = newPosition;

        if (Time.time > nextSpawn)
        {
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            Instantiate(octopus, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }

}
