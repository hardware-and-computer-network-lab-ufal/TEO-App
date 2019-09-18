using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TEOManager : MonoBehaviour {

    public static TEOManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //if(SceneManager.GetActiveScene().buildIndex != 0)
        //{
        //    SceneManager.sceneLoaded += OnLoadScene;
        //}

        SceneManager.sceneLoaded += OnLoadScene;


    }

    private void OnLoadScene(Scene cena,LoadSceneMode modo)
    {
        print("Nova cena carregada: " + cena.name);
        MudaIdioma();
    }

    public void MudaIdioma()
    {
        if(PlayerPrefs.HasKey("novoIdioma"))
        {
            string novoIdioma = PlayerPrefs.GetString("novoIdioma");

            //Mudanca de imagens com textos
            GameObject[] objetos = GameObject.FindGameObjectsWithTag("idioma");

            foreach (GameObject g in objetos)
            {
                //print(g.name);
                string name = g.name;
                g.GetComponent<Image>().sprite = Resources.Load<Sprite>("Idiomas/" + novoIdioma + "/" + name);
            }
        }
    }
}
