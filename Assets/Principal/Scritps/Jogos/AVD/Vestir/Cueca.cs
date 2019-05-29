using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cueca : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.name == "short" && gameObject.GetComponentInParent<Image>().sprite.name == "teo-tenis")
        {

            VestirManager.instance.rightClothe = true;

        }
        else
        {
            VestirManager.instance.rightClothe = false;

        }
    }
}
