using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peca : MonoBehaviour {
    private Vector3 coordPeca;
    private Vector3 offset;

    void OnMouseDown()
    {
        coordPeca = Camera.main.WorldToScreenPoint(gameObject.transform.position); //recebe a coord da imagem 

    }

    void OnMouseDrag()
    {
        Vector3 atualCoordImg = new Vector3(Input.mousePosition.x, Input.mousePosition.y, coordPeca.z); //atualiza a coord para a do mouse

        Vector3 atualPos = Camera.main.ScreenToWorldPoint(atualCoordImg);
        transform.position = atualPos; //passa a pos do mouse para a img

    }

    private void OnMouseUp()
    {
        coordPeca = Camera.main.WorldToScreenPoint(gameObject.transform.position); //recebe a coord da imagem 
    }
}
