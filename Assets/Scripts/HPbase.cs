using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPbase : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    [SerializeField] private float baseHP = 1200f;
    void Start()
    {
        Base.GetHit += HPreduce;
        textField.text = "Base HP : " + baseHP;
    }

    private void HPreduce()
    {
        baseHP -= 50f;
        textField.text = "Base HP : " + baseHP;
        if (baseHP < 0)
        {
            textField.text = "GAME OVER";
        }
    }
    void Update()
    {
        
    }
}
