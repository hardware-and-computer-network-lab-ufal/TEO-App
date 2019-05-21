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

    }

    public void OnSliderChanged()
    {
        Musica.instance.OnChangeEffectVolum(slider.value);
    }

}
