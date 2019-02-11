using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapisJogo : MonoBehaviour {

    private Vector3 coordLapis;
    private Vector3 offset;




    void OnMouseDown()
    {
        coordLapis = Camera.main.WorldToScreenPoint(gameObject.transform.position); //recebe a coord da imagem 

    }

    void OnMouseDrag()
    {
        Vector3 atualCoordImg = new Vector3(Input.mousePosition.x, Input.mousePosition.y, coordLapis.z); //atualiza a coord para a do mouse

        Vector3 atualPos = Camera.main.ScreenToWorldPoint(atualCoordImg);
        transform.position = atualPos; //passa a pos do mouse para a img

    }

    private void OnMouseUp()
    {
        coordLapis = Camera.main.WorldToScreenPoint(gameObject.transform.position); //recebe a coord da imagem 
    }

}
