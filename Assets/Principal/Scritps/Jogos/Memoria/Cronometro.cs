using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

    float tempo = 10.0f;
    private Text numero;

	// Use this for initialization
	void Start () {
        numero = gameObject.GetComponentInChildren<Image>().GetComponentInChildren<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
        } else
        {
            tempo = 0;
        }

        numero.text = tempo.ToString("0");
        gameObject.GetComponent<Image>().fillAmount = (float)tempo / 10;

        if (tempo == 0)
        {
            Destroy(gameObject);
        }
	}
}
