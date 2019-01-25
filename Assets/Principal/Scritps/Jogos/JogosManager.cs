using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogosManager : MonoBehaviour {

    [System.Serializable]
    public class Botao
    {
        public string nome;
    }

    [SerializeField]
    private List<Botao> iniciante;
    [SerializeField]
    private List<Botao> intermediario;
    [SerializeField]
    private List<Botao> avancado;

    public Transform prateleira;
    public GameObject botao;

    // Use this for initialization
    void Start () {
        if (NivelManager.instance.nivel==1)
        {
            InstanciaBotao(iniciante);
        } else if (NivelManager.instance.nivel == 2)
        {
            InstanciaBotao(intermediario);
        } else if (NivelManager.instance.nivel == 3)
        {
            InstanciaBotao(avancado);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InstanciaBotao(List<Botao> lista)
    {
        foreach (Botao b in lista)
        {
            GameObject botaoObj = Instantiate(botao) as GameObject; //instancia um botao como gameobject da cena
            botaoObj.transform.SetParent(prateleira, false);
            Button botaoNovo = botaoObj.GetComponent<Button>();

            botaoNovo.image.sprite = Resources.Load<Sprite>("Jogos/" + b.nome);

        }
    }
}
