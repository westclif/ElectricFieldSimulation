using UnityEngine;
using System.Collections;

public class VectorVisualizer : MonoBehaviour {

    public float vectorLength = 0.4f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 endPos = this.transform.position + ( this.transform.forward * vectorLength );
        Gizmos.DrawWireSphere (endPos, 0.05f);

        Gizmos.DrawLine(this.transform.position, endPos);
    }

}
