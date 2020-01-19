using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if(Data.nyawa == 1)
            {
                Data.nyawa--;
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
                Time.timeScale = 1;
            } else
            {
                Data.nyawa--;
                Data.score = 0;
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
                Time.timeScale = 1;
            }
           
        }
    }
}
