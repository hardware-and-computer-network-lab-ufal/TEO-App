using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEfeitos : MonoBehaviour {

    private Slider slider;

    // Use this for initialization
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("effect_volume"))
        {
            slider.value = PlayerPrefs.GetFloat("effect_volume");
        }
    }

    public void OnSliderChanged()
    {
        Musica.instance.OnChangeEffectVolum(slider.value);
        PlayerPrefs.SetFloat("effect_volume", slider.value);
    }

}
