using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI loseText;
    public TextMeshProUGUI scoreText;

    [HideInInspector] public int score;
    public bool gameIsActive = true;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Lose()
    {
        loseText.gameObject.SetActive(true);
    }
}
