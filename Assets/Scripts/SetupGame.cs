using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupGame : MonoBehaviour {

    public InputField scoreLimitInput;

    private int scoreLimit;

    public void StartupGame()
    {
        //This tries to parse 'scoreLimitInput.text' to an int, if it succeeds, the value is put to 'scoreLimit'
        Int32.TryParse(scoreLimitInput.text, out scoreLimit);
        if (scoreLimit <= 0)
        {
            Debug.Log("Invalid input!");
        }
        else
        {
            Debug.Log("Input Accepted");
            PlayerPrefs.SetInt("Score Limit", scoreLimit);
            Application.LoadLevel("Game");
        }
    }
}
