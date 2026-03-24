using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bckPrefab;
    public float speed;
    public float scale;
    private GameObject[] bcks;
    public float pivotPoint;

    void Start()
    {
        bckPrefab.transform.localScale = new Vector3(scale, scale, scale);
        pivotPoint = -0.32f * 16 * scale;

        bcks = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint / 2 * i);
            float yPos = pivotPoint - (pivotPoint / 2 * i);
            Vector3 pos = new Vector3(xPos, yPos, 5.0f);
            bcks[i] = Instantiate(bckPrefab, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            float xPos = bcks[i].transform.position.x + speed;
            float yPos = bcks[i].transform.position.y + speed;
            Vector3 newPos = new Vector3(xPos, yPos, 5.0f);
            bcks[i].transform.position = newPos;

            if (xPos > -pivotPoint / 2)
            {
                Vector3 pivot = new Vector3(pivotPoint, pivotPoint, 0.0f);
                bcks[i].transform.position = pivot;
            }
        }
    }
}