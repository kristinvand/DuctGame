using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawning : MonoBehaviour
{
    public float spawnInterval = 8.0f;

    public GameObject emptyRoom;

    public List<GameObject> rooms = new List<GameObject>();

    [ReadOnly] public float timeUntilNextSpawn = 0f;
    [ReadOnly] public GameObject lastSpawnRef;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextSpawn = spawnInterval;

        Instantiate(emptyRoom, new Vector3(0, 4.5f, 0f), Quaternion.identity);
        Instantiate(emptyRoom, new Vector3(0, 4.5f, 21.5f), Quaternion.identity);
        Instantiate(emptyRoom, new Vector3(0, 4.5f, 43f), Quaternion.identity);
        Instantiate(emptyRoom, new Vector3(0, 4.5f, 64.5f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextSpawn += Time.deltaTime;

        if(timeUntilNextSpawn >= spawnInterval)
        {
            lastSpawnRef = Instantiate
            (
                rooms[Random.Range(0, rooms.Count)], 
                new Vector3(0, 4.5f, lastSpawnRef == null ? 86f : (lastSpawnRef.transform.position.z + 21.5f)), 
                Quaternion.identity
            );

            timeUntilNextSpawn = 0f;
        }
    }
}