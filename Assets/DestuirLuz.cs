using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestuirLuz : MonoBehaviour {

    private bool JaBranco = false;

    public void setarBrancoTrue() {
        JaBranco = true;
    }

    public void setarBrancoFalse() {
        JaBranco = false;
    }

    public bool getJaBranco() {
        return JaBranco;
    }


}
