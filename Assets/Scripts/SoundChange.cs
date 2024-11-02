using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundChange : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderVal)
    {
        if (sliderVal == 0f) mixer.SetFloat("SFXvol",-80f);
        mixer.SetFloat("SFXvol", Mathf.Log10(sliderVal) * 20);
    }
}
