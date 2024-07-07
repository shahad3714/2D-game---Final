using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_sitting : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;
    public Canvas body;
    public Boolean PauseScreen = false;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause_UI()
    {


      
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        
    }
        public void PauseGame(bool status)
        {
            PauseScreen = true;
            pauseScreen.SetActive(status);

            if (status)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
    
}
