using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Peito : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.name == "camisa" && gameObject.GetComponentInParent<Image>().sprite.name == "teo-short")
        {

            VestirManager.instance.rightClothe = true;

        }
        else
        {
            VestirManager.instance.rightClothe = false;

        }
    }
}
