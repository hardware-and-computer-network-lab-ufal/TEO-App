using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pe : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.name == "meia")
        {
            
            VestirManager.instance.rightClothe = true;
            
        } else
        {
            VestirManager.instance.rightClothe = false;
            
        }
    }
}
