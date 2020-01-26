using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void Pengaturan()
    {
        SceneManager.LoadScene("Setings");
    }

    public void Keluar()
    {
        Application.Quit();
        Debug.Log("Keluar");
    }

    public void NextStory1()
    {
        SceneManager.LoadScene("Story2");
    }

    public void NextStory2()
    {
        SceneManager.LoadScene("Story3");
    }

    public void Mainkan()
    {
        SceneManager.LoadScene("Level1");
    }
}
