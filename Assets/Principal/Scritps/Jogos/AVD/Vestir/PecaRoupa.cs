using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PecaRoupa : MonoBehaviour {

    private Vector3 coordPeca;
    private Vector3 defaultPosition;

    void OnMouseDown()
    {
        coordPeca = Camera.main.WorldToScreenPoint(gameObject.transform.position); //recebe a coord da imagem 
        defaultPosition = gameObject.transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 atualCoordImg = new Vector3(Input.mousePosition.x, Input.mousePosition.y, coordPeca.z); //atualiza a coord para a do mouse

        Vector3 atualPos = Camera.main.ScreenToWorldPoint(atualCoordImg);
        transform.position = atualPos; //passa a pos do mouse para a img

    }

    private void OnMouseUp()
    {
        if (!VestirManager.instance.rightClothe)
        {
            transform.position = defaultPosition;
            Musica.instance.OnFail();
            VestirManager.instance.usuario.quantidadeErros++;
        }
        else
        {
            GameObject.Find("teo").GetComponent<Image>().sprite = Resources.Load<Sprite>("Jogos/vestir/teo-"+gameObject.name);
            Musica.instance.OnRight();
            VestirManager.instance.clothesLentgh++;
            VestirManager.instance.VerifyClothes();
            Destroy(gameObject);
        }
        
    }
}
