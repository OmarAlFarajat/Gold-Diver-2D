using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroSpawner : MonoBehaviour
{
    // Very similar to the other spawners

    public GameObject nitro;
    [SerializeField]
    public float spawnRate = 25f;

    float nextSpawn = 0f;

    void Update()
    {
        Vector3 newPosition = transform.position;
        float buffer = 1f;
        newPosition.x = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect + buffer, Camera.main.orthographicSize * Camera.main.aspect - buffer);
        newPosition.y = Random.Range(-Camera.main.orthographicSize + buffer, Camera.main.orthographicSize - buffer * 3);
        transform.position = newPosition;

        if (Time.time > nextSpawn)
        {
            Instantiate(nitro, transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }
}
