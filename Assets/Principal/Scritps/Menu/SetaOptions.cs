using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetaOptions : MonoBehaviour {

 //   public List<GameObject> opcoes = new List<GameObject>();
 //   private Button setaAvancar,setaVoltar;
 //   [SerializeField]private int indice=1; //o elemento zero eh o pai

	//// Use this for initialization
	//void Start () {
 //       setaAvancar = GameObject.Find("Avancar").GetComponent<Button>();
 //       setaVoltar = GameObject.Find("Voltar").GetComponent<Button>();

 //       setaAvancar.onClick.AddListener(() => SetaAvancar());

 //       setaVoltar.onClick.AddListener(()=>SetaVoltar());

 //       for(int i = 0; i < opcoes.Count; i++)
 //       {
 //           print(opcoes[i].gameObject.name);
 //       }
    
	//}

 //   void SetaAvancar()
 //   {
 //       print(opcoes.Count);
 //       opcoes[1].gameObject.SetActive(false);

 //       ++indice;

 //       if (indice > opcoes.Count)
 //       {
 //           indice = 1;
 //       }
        
 //       opcoes[indice].SetActive(true);
 //   }

 //   void SetaVoltar()
 //   {
 //       opcoes[indice].SetActive(false); //setando o atual para falso

 //       --indice;

 //       if (indice < 1)
 //       {
 //           indice = opcoes.Count; //pegando o tam da lista pra ir pro ultimo item 
 //       }

 //       opcoes[indice].SetActive(true); //setando o novo para verdadeiro
 //   }

}
