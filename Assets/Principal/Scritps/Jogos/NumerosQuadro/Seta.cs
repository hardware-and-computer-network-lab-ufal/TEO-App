using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seta : MonoBehaviour {

    private float tempo = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tempo -= Time.deltaTime;
        print(tempo);

        if (tempo <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
