using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderExtensionAudio : Slider
{
    private void Update()
    {
        AudioListener.volume = value / 10;
    }
}
