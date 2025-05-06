using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceManager : MonoBehaviour
{
    public SixDice sixDice;
    public TextMeshProUGUI numberText;

    
    public void WhatNum()
    {
        StartCoroutine(YouRolled());
    }

    private IEnumerator YouRolled()
    {
        numberText.text = "You rolled a " + sixDice.rollNumber.ToString();
        yield return new WaitForSeconds(3);
        numberText.text = "";
    }
}
