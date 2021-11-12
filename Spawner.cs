using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//resource https://www.youtube.com/watch?v=1h2yStilBWU
//https://noobtuts.com/unity/2d-tetris-game/
public class Spawner : MonoBehaviour
{
    public GameObject egg;
    public GameObject wallLeft;
    public GameObject wallRight;

    public float spawnTime =0;
    public float _spawnDelay =5;

    void Start()
    {
        InvokeRepeating("SpawnNext", spawnTime, _spawnDelay);
    }

    void SpawnNext()
    {
        //initialize random
        float randomX = Random.Range(wallLeft.transform.position.x, wallRight.transform.position.x);
        Vector3 pos = new Vector2(randomX, transform.position.y);
        Instantiate(egg, pos, Quaternion.identity);
    }

}


