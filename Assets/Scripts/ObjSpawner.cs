using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawnObjects = new List<GameObject>();

    [SerializeField]
    private int spawnAmount;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float spawnTimer = 2;
    private float spawnTime = 0;
    [SerializeField]
    private int moveDirection = 1;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private bool canMove;

    private void Start()
    {
        canMove = true;
    }
    private void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= spawnTimer && canMove)
        {
            clearSpawnedList();
            spawnTime = 0;
            GameObject obj = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], transform.position + new Vector3(0, Random.Range(-1.5f, 1.5f), 0), Quaternion.identity);
            spawnedObjects.Add(obj);
            obj.GetComponent<HumanMovement>().movemenDirection = moveDirection;

            Vector3 scale = obj.transform.localScale;
            obj.transform.localScale = new Vector3(scale.x * (-moveDirection), scale.y, scale.z);
        }
    }
    private void clearSpawnedList()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] != null)
            {
                spawnedObjects.RemoveAt(i);
            }
        }
    }
    private void SpawnObjects()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject obj = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], transform.position, Quaternion.identity);
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
            GameObject obj = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], transform.position + new Vector3(0, Random.Range(-1.5f, 1.5f), 0), Quaternion.identity);
            spawnedObjects.Add(obj);
            obj.GetComponent<HumanMovement>().movemenDirection = moveDirection;
            yield return new WaitForSeconds(Random.Range(spawnTimer * 0.5f, spawnTimer * 2.0f));
        }
    }

    public void StopAllMovement()
    {
        clearSpawnedList();
        canMove = false;
        foreach (GameObject obj in spawnedObjects)
        {
            obj.GetComponent<HumanMovement>().canMove = false;
        }
    }
    public void StartAllMovement()
    {
        clearSpawnedList();
        canMove = true;
        foreach (GameObject obj in spawnedObjects)
        {
            obj.GetComponent<HumanMovement>().canMove = true;
        }
    }
}