using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusica : MonoBehaviour {

    private Slider slider;

	// Use this for initialization
	void Start () {
        slider = gameObject.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("music_volume"))
        {
            slider.value = PlayerPrefs.GetFloat("music_volume");
        }
        
    }

    public void OnSliderChanged()
    {
        Musica.instance.OnChangeMusicVolum(slider.value);
        PlayerPrefs.SetFloat("music_volume", slider.value);
    }
}
