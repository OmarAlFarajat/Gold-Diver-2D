using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject shark;
    public float spawnRate = 0f;
    float nextSpawn = 0f;
    public GameObject bubbles;

    void Update()
    {
        spawnRate = 5f / (PlayerController.level*0.5f);
        Vector3 newPosition = transform.position;
        float buffer = 1f;
        newPosition.x = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect + buffer, Camera.main.orthographicSize * Camera.main.aspect - buffer);
        newPosition.y = Random.Range(-Camera.main.orthographicSize + buffer*0.5f, Camera.main.orthographicSize - buffer*1.5f);
        transform.position = newPosition;

        if (Time.time > nextSpawn)
        {
            Instantiate(bubbles, gameObject.transform.position, gameObject.transform.rotation);
            // This will vary the size of the sharks upon instantiation.
            float scale = Random.Range(1.0f, 3.0f);
            (Instantiate(shark, transform.position, Quaternion.identity)).transform.localScale = new Vector3(scale,scale,scale);
            nextSpawn = Time.time + spawnRate;
        }
    }
}
