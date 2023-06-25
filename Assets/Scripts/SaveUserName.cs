using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.SceneManagement;

public class SaveUserName : MonoBehaviour
{
    public TMP_InputField inputName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameInit()
    {
        string name = TransformCapitalize(inputName.text);
        PlayerPrefs.SetString("Name", name);

        SceneManager.LoadScene(3);
    }

    string TransformCapitalize(string text)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(text.ToLower());
    }
}
