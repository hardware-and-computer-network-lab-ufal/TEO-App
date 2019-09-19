using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meia : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.name == "tenis" && gameObject.GetComponentInParent<Image>().sprite.name=="teo-meia")
        {

            VestirManager.instance.rightClothe = true;

        }
        else
        {
            VestirManager.instance.rightClothe = false;

        }
    }
}
