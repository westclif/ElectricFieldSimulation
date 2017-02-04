using UnityEngine;
using System.Collections;
using UnityEditor;

public class VectorFieldGen : MonoBehaviour {

    //which means the reciprocal will be the distance
    public float resolution = 1.0f;
    // 1 / resolution will be the distance between the nodes

    public GameObject vectorPrefab;

    private Vector2 upperLeft;
    private Vector2 lowerRight;

    private int xVal;
    private int yVal;

    private float distVertical;
    private float distHorizontal;

    private Vector2 tempPos;

    public float indexNumberOffset = 1.0f;
    public float distBetweenOffset = 1.0f;

    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("VecVis");

            for (int i = 0; i < objs.Length; i++)
            {
                Destroy(objs[i]);
                objs[i] = null;
            }

            System.Array.Resize(ref objs, 0);

            upperLeft = Camera.main.ScreenToWorldPoint(new Vector2(0.0f, Camera.main.pixelHeight));
            lowerRight = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth, 0.0f));

            yVal = (int)(upperLeft.y * resolution * indexNumberOffset);
            distVertical = (1 / resolution) * distBetweenOffset;

            xVal = (int)(lowerRight.x * resolution * indexNumberOffset);
            distHorizontal = (1 / resolution) * distBetweenOffset;

            tempPos = upperLeft;

            for (int y = 0; y < yVal; y++)
            {
                for (int x = 0; x < xVal; x++)
                {
                    Instantiate(vectorPrefab, tempPos, Quaternion.identity, this.transform);
                    tempPos.x += distHorizontal;
                }
                tempPos.x = upperLeft.x;
                tempPos.y -= distVertical;

            }



        }

        

    }


}
