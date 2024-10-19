using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicMaster : MonoBehaviour
{

    public static CosmicMaster Instance { get; private set; }
    
    [SerializeField]
    private GameObject killEffect;
    
    public GameObject currentHumanTarget;
    
    private void Awake()
    {
        Instance = this;
    }


    public void KillHuman()
    {
        GameObject targetToKill = currentHumanTarget;
        Destroy(Instantiate(killEffect, targetToKill.transform.position + new Vector3(0, 1.9f,0), Quaternion.identity), 0.5f); 
        Destroy(targetToKill);
        currentHumanTarget = null;
    }

}
