using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReplaceName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetTextReplaced();
    }

    // Update is called once per frame
    void Update()
    {
        GetTextReplaced();
    }

    void GetTextReplaced()
    {
        string name = PlayerPrefs.GetString("Name");
        GameObject textObject = GameObject.FindWithTag("ReplaceName");
        TextMeshProUGUI textComponent = textObject.GetComponent<TextMeshProUGUI>();
        string textReplaced = textComponent.text.Replace("\"nombre\"", name.Split(' ')[0]);

        textComponent.text = textReplaced;
    }
}
