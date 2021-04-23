using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    [SerializeField] List<Garbage> garbages;
    [SerializeField] float minDelay = 0.5f;
    [SerializeField] float maxDelay = 1.5f;
    [SerializeField] Transform garbageParent;
    [SerializeField] float spawnHeight = 10f;

    List<Transform> places;
    bool gameOver;

    private void Awake()
    {
        places = FindObjectOfType<BinManager>().binPlaces;
        StartCoroutine(SpawnGarbageAfterDelay(2f));
    }
    void SpawnRandomGarbage(Vector3 place)
    {
        Instantiate(garbages[Random.Range(0, garbages.Count)], place, Quaternion.identity, garbageParent);
    }

    IEnumerator SpawnGarbageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        var place = places[Random.Range(0, places.Count)].position;
        place = new Vector3(place.x, spawnHeight);
        SpawnRandomGarbage(place);
        if(!gameOver)
        {
            StartCoroutine(SpawnGarbageAfterDelay(Random.Range(minDelay, maxDelay)));
        }
    }
}
