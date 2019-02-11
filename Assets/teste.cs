using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour {

    public float posX;
    private float posY;
    private float posZ;

    public Transform objt;

    // Use this for initialization
    void Start () {

        posX = objt.transform.position.x;
        posY = objt.transform.position.y;
        posZ = objt.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        print("entrou");
        posX = objt.transform.position.x;
        posY = objt.transform.position.y;
        posZ = objt.transform.position.z;
    }

    private void OnMouseDrag()
    {
        posX += Input.mousePosition.x * Time.deltaTime;
        posY += Input.mousePosition.y * Time.deltaTime;
        posZ += Input.mousePosition.z * Time.deltaTime;


        objt.transform.Translate(new Vector3(posX, posY, posZ));
    }
}
