using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour {

	static Musica instance;
    public AudioSource musicaFundo; 

	void Awake(){
		if (instance == null) {
			GameObject.DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}

	}

    private void Update()
    {
        if (!musicaFundo.isPlaying)
        {
            musicaFundo.Play();
        }
    }
}

