using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_controlAudio : MonoBehaviour
{
    public Slider sliderMusicBackground;
    private AudioSource musicBackground;

    // Start is called before the first frame update
    void Start()
    {
        musicBackground = GameObject.FindGameObjectWithTag("audioManager").gameObject.GetComponent<AudioSource>();
        Debug.Log(musicBackground.volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMusicVolumeUpdate()
    {
        musicBackground.volume = sliderMusicBackground.value;
    }
}
