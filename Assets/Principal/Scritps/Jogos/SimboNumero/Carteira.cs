using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carteira : MonoBehaviour {
    

    private void OnCollisionEnter2D(Collision2D outro) //o objeto (no unity) tem um rigidybody do tipo kinematico pq nao sofre os efeitos mas eh reconhecido
    {
        if (outro.gameObject.CompareTag("lapis"))
        {
            SimboNumero.instance.SalvaPontos(1);
        }
        else if (outro.gameObject.CompareTag("lapis5"))
        {
            SimboNumero.instance.SalvaPontos(5);
        }
        else if (outro.gameObject.CompareTag("lapis10"))
        {
            SimboNumero.instance.SalvaPontos(10);
        }
    }

    private void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("lapis"))
        {
            SimboNumero.instance.TiraPontos(1);
        }
        else if (outro.gameObject.CompareTag("lapis5"))
        {
            SimboNumero.instance.TiraPontos(5);
        }
        else if (outro.gameObject.CompareTag("lapis10"))
        {
            SimboNumero.instance.TiraPontos(10);
        }
    }

}
