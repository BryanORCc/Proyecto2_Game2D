using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class script_finalResult : MonoBehaviour
{
    public TextMeshProUGUI totalResult;
    // Start is called before the first frame update
    void Start()
    {
        float total = script_textControl.instance.nota;
        totalResult.text = "Nota final: " + total.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
