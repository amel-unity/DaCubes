﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public TextMeshProUGUI Score;
    public int ScoreValue;

    void Start()
    {
        Instance = this;
    }

    public void IncrementScore(int value)
    {
        ScoreValue += value;
    }
    public void SetScoreUIValue()
    {
        Score.text = ScoreValue.ToString();
    }
    public int GetScoreValue()
    {
        SetScoreUIValue();
        return ScoreValue;
    }

}
