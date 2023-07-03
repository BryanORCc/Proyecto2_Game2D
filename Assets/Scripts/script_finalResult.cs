using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class script_finalResult : MonoBehaviour
{
    public TextMeshProUGUI totalResult;
    // Start is called before the first frame update
    void Start()
    {
        float total = script_textControl.instance.nota;
        double percentage = Math.Round((total * 100) / 20, 2);
        totalResult.text = "Puntuación obtenida: " + percentage.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
