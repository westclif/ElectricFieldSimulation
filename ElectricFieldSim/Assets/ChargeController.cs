using UnityEngine;
using System.Collections;

public class ChargeController : MonoBehaviour {

    public float chargeValue;

    private bool moveWithMouse;

    public float GetInfo()
    {
        return chargeValue;
    }

    private void Update () {
        if ( moveWithMouse == true ) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            mousePos.z = 0.0f;
            this.transform.position = mousePos; 
        }
    }

    private void OnMouseDown () {
        moveWithMouse = true;
    }
    private void OnMouseUp () {
        moveWithMouse = false;
    }

}
