using UnityEngine;
using System.Collections.Generic;

public class NetSum : MonoBehaviour {
    public float charge;

    public Vector2 netForce;

    private ChargeController[] allParentCharges;

    private const long k = 9000000000;

    // Use this for initialization

    private void Start () {
        allParentCharges = GameObject.FindObjectsOfType<ChargeController> ();

    }

    private void Update()
    {
        Addforces ();
    }

    public void Addforces() {


        netForce = Vector2.zero;

        foreach ( ChargeController transformChange in allParentCharges ) {
            if ( transformChange.transform.hasChanged ) {

                //Debug.Log ("hasChanged");
                foreach ( ChargeController item in allParentCharges ) {
                    float parentCharge = item.GetInfo ();



                    float force = ( k * ( parentCharge * this.charge ) ) / ( Mathf.Pow (Vector2.Distance (this.transform.position, item.transform.position), 2.0f) );

                    Vector2 vectorForce = item.transform.position - this.transform.position;

                    vectorForce *= force;

                    netForce += vectorForce;

                }

                RotateSelfToNet (netForce);
                //transformChange.transform.hasChanged = false;
            }

        }

        
    }

    public void RotateSelfToNet(Vector3 net)
    {
        Quaternion netRot = Quaternion.LookRotation(net, this.transform.up);
        this.transform.rotation = netRot;
    }

    //private void OnDrawGizmos () {
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine (this.transform.position, netForce);
    //}
}
