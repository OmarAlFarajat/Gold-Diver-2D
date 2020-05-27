using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    // Spawner logic adapted from https://www.youtube.com/watch?v=ao_BZMORqQw


    public GameObject goldSmall, goldMedium, goldLarge;

    [SerializeField]
    public float spawnRate = 5f;

    float nextSpawn = 0f;

    int spawnSelect; 

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        float buffer = 1f; 
        // Spawn somewhere random within the viewable window (with some buffers so that it doesn't spawn too high up)
        newPosition.x = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect + buffer, Camera.main.orthographicSize * Camera.main.aspect - buffer);
        newPosition.y = Random.Range(-Camera.main.orthographicSize + buffer, Camera.main.orthographicSize - buffer*3);
        transform.position = newPosition; 

        if (Time.time > nextSpawn)
        {
            spawnSelect = Random.Range(0, 3);

            // Spawn either 1, 2, or 10 gold at random. 
            switch (spawnSelect)
            {
                case 0:
                    Instantiate(goldSmall, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(goldMedium, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(goldLarge, transform.position, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;
        }




    }
}
