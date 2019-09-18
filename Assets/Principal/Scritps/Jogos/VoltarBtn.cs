using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarBtn : MonoBehaviour {

	public void Voltar()
    {
        SceneManager.LoadScene(1);
    }
}
