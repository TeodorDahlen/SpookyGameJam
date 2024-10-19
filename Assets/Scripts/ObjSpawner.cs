using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private int spawnAmount;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float spawnTimer = 2;

    private List<GameObject> spawnedObjects = new List<GameObject>();


    private void Start()
    {
        StartCoroutine(SpawnOverSeconds());
    }
    private void Update()
    {

    }

    private void SpawnObjects()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject obj = Instantiate(spawnObject, transform.position, Quaternion.identity);
            spawnedObjects.Add(obj);
        }
    }

    private void MoveObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            obj.transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        }
    }

    private IEnumerator SpawnOverSeconds()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject obj = Instantiate(spawnObject, transform.position + new Vector3(0, Random.Range(-1.5f, 1.5f), 0), Quaternion.identity);
            spawnedObjects.Add(obj);
            yield return new WaitForSeconds(Random.Range(spawnTimer * 0.5f, spawnTimer * 2.0f));
        }
    }
}