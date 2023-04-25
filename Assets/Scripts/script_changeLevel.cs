using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script_changeLevel : MonoBehaviour
{
    public bool nextLevel;
    public int indexLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeLevel(indexLevel);
        }

        if (nextLevel)
        {
            ChangeLevel(indexLevel);
        }
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
