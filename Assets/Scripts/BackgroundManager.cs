using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public float speed = 0.05f;       
    public Vector2 pivot = new Vector2(-10.24f, -10.24f);

    private GameObject[] bcks = new GameObject[3];
    private Vector2 moveDirection = Vector2.one; 
    void Start()
    {
       
        for (int i = 0; i < 3; i++)
        {
            bcks[i] = Instantiate(backgroundPrefab, Vector3.zero, Quaternion.identity);
            
            float offsetX = (pivot.x / -2) * i;
            float offsetY = (pivot.y / -2) * i;
            bcks[i].transform.position = new Vector3(pivot.x + offsetX, pivot.y + offsetY, 0);
        }
    }

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            bcks[i].transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
            if (bcks[i].transform.position.x > -pivot.x || bcks[i].transform.position.y > -pivot.y)
            {
                bcks[i].transform.position = new Vector3(pivot.x, pivot.y, 0);
            }
        }
    }
}