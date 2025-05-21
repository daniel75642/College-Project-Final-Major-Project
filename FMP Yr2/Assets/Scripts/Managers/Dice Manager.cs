using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public SixDice sixDice;
    public TextMeshProUGUI numberText;
    public GameObject moveTut;
    public bool firstTurn;

    
    public void WhatNum()
    {
        StartCoroutine(YouRolled());
    }

    private IEnumerator YouRolled()
    {
        numberText.text = "You rolled a " + sixDice.rollNumber.ToString();
        yield return new WaitForSeconds(3);
        numberText.text = "";
        if(firstTurn == true)
        {
            moveTut.SetActive(true);
            firstTurn = false;
        }
    }
}
