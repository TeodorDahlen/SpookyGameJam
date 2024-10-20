using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public static Brain Instance { get; private set; }

    [SerializeField]
    private GameObject brainPoints;

    [SerializeField]
    private int spawnAmount;

    private List<GameObject> currentBrainActivity = new List<GameObject>();

    [SerializeField]
    private ObjSpawner spawner;

    [SerializeField]
    private GameObject Arm;

    private void Awake()
    {
        Instance = this;
    }
    public void StartBrain()
    {
        foreach (GameObject brainPoint in currentBrainActivity)
        {
            Destroy(brainPoint);
        }
        currentBrainActivity.Clear();
        StartCoroutine(RandomBrainSpasmTimeDiff());
        spawner.StopAllMovement();
        Debug.Log("play again");
        Arm.SetActive(false);
    }

    private void SpawnBrainPoint()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Debug.Log("Spawn");
            GameObject newBrainPoint = Instantiate(brainPoints, transform.position + (Vector3)Random.insideUnitCircle * 2, Quaternion.identity);
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
        CosmicMaster.Instance.KillHuman();
        spawner.StartAllMovement();
        Arm.SetActive(true);
        gameObject.SetActive(false);
        CosmicMaster.Instance.UpdateScore(1);
    }
    
    private IEnumerator RandomBrainSpasmTimeDiff()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Debug.Log("Spawn");
            GameObject newBrainPoint = Instantiate(brainPoints, transform.position + (Vector3)Random.insideUnitCircle * 2, Quaternion.identity);
            currentBrainActivity.Add(newBrainPoint);
            yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));
        }
        
    }
}