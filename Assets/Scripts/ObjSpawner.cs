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
    private float spawnTimerBase = 2;
    private float spawnTimerVariant;
    private float spawnTime = 0;
    [SerializeField]
    private int moveDirection = 1;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private bool canMove;

    private void Start()
    {
        canMove = true;
        spawnTimerVariant = spawnTimerBase;
        SpawnObjects();
    }
    private void Update()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= spawnTimerVariant && canMove)
        {
            SpawnObjects();
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
        clearSpawnedList();
        spawnTime = 0;
        float randomNumber = Random.Range(-1.5f, 1.5f);
        GameObject obj = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], transform.position + new Vector3(0, randomNumber, 0), Quaternion.identity);
        spawnedObjects.Add(obj);
        obj.GetComponent<HumanMovement>().movemenDirection = moveDirection;

        obj.GetComponent<HumanMovement>().sprite.sortingOrder = -Mathf.FloorToInt(obj.transform.position.y + randomNumber);

        Vector3 scale = obj.transform.localScale;
        obj.transform.localScale = new Vector3(scale.x * (-moveDirection), scale.y, scale.z);
        spawnTimerVariant = spawnTimerBase * Random.Range(0.5f, 1.5f);
        spawnTimerBase *= 0.95f;
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
            yield return new WaitForSeconds(Random.Range(spawnTimerBase * 0.5f, spawnTimerBase * 2.0f));
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