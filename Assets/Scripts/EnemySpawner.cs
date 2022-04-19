using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnTimer = 0;
    public float SpawnRate = 5.0f;
    public Transform EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnTimer <= 0)
        {
            Instantiate(
                EnemyPrefab,
                new Vector3(
                    Camera.main.orthographicSize * Camera.main.aspect,
                    Random.Range(
                        -Camera.main.orthographicSize,
                        Camera.main.orthographicSize
                    ),
                    0
                ),
                Quaternion.Euler(0, 0, 0)
            );
            SpawnTimer = SpawnRate;
        } else {
            SpawnTimer -= Time.deltaTime;
        }
    }
}
