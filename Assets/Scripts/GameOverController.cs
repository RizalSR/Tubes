using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Text txScore;
    Text txSelamat;
    int score;
    int total;
    // Start is called before the first frame update
    void Start()
    {
        score = Data.score;
        total = score;
        txScore.text = total.ToString();
    }

    public void Menu(){
        SceneManager.LoadScene("Menu");
    }

    public void Exit(){
        Application.Quit();
    }
}
