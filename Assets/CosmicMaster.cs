using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CosmicMaster : MonoBehaviour
{

    public static CosmicMaster Instance { get; private set; }
    
    [SerializeField]
    private GameObject killEffect;
    
    public GameObject currentHumanTarget;

    [SerializeField]
    public int score;

    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    private void Awake()
    {
        Instance = this;
    }
    public void KillHuman()
    {
        GameObject targetToKill = currentHumanTarget;
        
        targetToKill.GetComponent<HumanMovement>().GoToSleep();
        targetToKill.GetComponent<HumanMovement>().enabled = false;
        targetToKill.GetComponent<Animator>().SetTrigger("Death");

        //Destroy(targetToKill);
        Destroy(Instantiate(killEffect, targetToKill.transform.position + new Vector3(0, 1.9f,0), Quaternion.identity), 0.5f);
        currentHumanTarget = null;
    }

    
    public void GameOver()
    {
        //Debug.Log("Game over");
        SceneManager.LoadScene(2);
    }

    public void UpdateScore(int aNumber)
    {
        score += aNumber;
        scoreText.SetText(score.ToString());
    }
}