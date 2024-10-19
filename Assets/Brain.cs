using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField]
    private GameObject brainPoints;

    [SerializeField]
    private int spawnAmount;

    private List<GameObject> currentBrainActivity = new List<GameObject>();

    private void Start()
    {
        SpawnBrainPoint();
    }
    private void Update()
    {
        UpdateBrain();
    }
    private void SpawnBrainPoint()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Debug.Log("Spawn");
            GameObject newBrainPoint = Instantiate(brainPoints, transform.position + (Vector3)Random.insideUnitCircle * 3, Quaternion.identity);
            currentBrainActivity.Add(newBrainPoint);
        }
    }

    public void UpdateBrain()
    {
        for (int i = 0; i < currentBrainActivity.Count; ++i)
        {
            if (currentBrainActivity[i] == null)
            {
                currentBrainActivity.RemoveAt(i);
            }
        }
        if(currentBrainActivity.Count <= 0)
        {
            BrainOver();
        }
    }
    public void BrainOver()
    {
        Debug.Log("brain over");
    }
}