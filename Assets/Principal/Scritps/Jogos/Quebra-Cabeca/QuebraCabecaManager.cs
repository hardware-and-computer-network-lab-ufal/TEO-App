﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuebraCabecaManager : MonoBehaviour {

    public static QuebraCabecaManager instance;
    public GameObject panelParabens;
    public GameObject panelEstatisticas;
    private int contador_pecas; //Vai contar quantas pecas ja foram colocadas no lugar
    private Animator parabensAnim;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        StartCoroutine(DesligaPanel());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DesligaPanel()
    {
        yield return new WaitForSeconds(0.001f);
        parabensAnim = panelParabens.GetComponent<Animator>();
        panelParabens.SetActive(false);
        panelEstatisticas.SetActive(false);
    }

    IEnumerator VoltaPanelParabens()
    {
        yield return new WaitForSeconds(5);
        parabensAnim.Play("panel_parabens_reverse");
        yield return new WaitForSeconds(1);
        panelEstatisticas.SetActive(true);
        panelParabens.SetActive(false);
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContaPecas()
    {
        contador_pecas++;

        if (contador_pecas == 4)
        {
            panelParabens.SetActive(true);
            parabensAnim.Play("panel_parabens");
            StartCoroutine(VoltaPanelParabens());
        }
    }
}
