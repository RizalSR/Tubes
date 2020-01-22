using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowNyawa : MonoBehaviour
{
    void FixedUpdate()
    {
        GetComponent<Text>().text = Data.nyawa.ToString();
        if(Data.nyawa == 0){
            SceneManager.LoadScene("GameOver");
            Data.nyawa = 5;
        }
    }
}
