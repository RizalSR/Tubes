﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxScript : MonoBehaviour
{
    public GameObject panggil;
    public static bool activeBox = true;
    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (activeBox.Equals(true))
        {
            if (other.transform.CompareTag("Player"))
            {
                bukapertanyaan();
            }   
        }
    }

    void bukapertanyaan()
    {
          Time.timeScale = 0;
          panggil.GetComponent<GameController>().StartRound();     
    }
}
