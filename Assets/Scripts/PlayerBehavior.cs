using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    private GameObject currentball;

    public float offY = -0.6f;
    public float min;
    public float max;

    public int move;

    public int[] points;
    public int total;
    public TMP_Text textField;

    public GameObject[] balls;

    void Start()
    {
        move = 0;
        total = 0;
    }

    void Update()
    {
        if (currentball != null)
        {
            Vector3 offset = new Vector3(0f, offY, 0f);
            currentball.transform.position =
                transform.position + offset;
        }
        
        else
        {
            QueueManager queue =
            GameObject.FindGameObjectWithTag("Queue")
            .GetComponent<QueueManager>();
            int choice = queue.UpdateQueue();
            
            currentball = Instantiate(
            balls[choice],
            transform.position,
            Quaternion.identity);
        }

        // drop ball
        if (currentball != null &&
            Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Rigidbody2D body =
                currentball.GetComponent<Rigidbody2D>();
            body.gravityScale = 1f;

            Collider2D col =
                currentball.GetComponent<Collider2D>();
            col.enabled = true;

            currentball = null;
        }

        // movement
        float offsetX = 0f;

        bool left =
            (Keyboard.current.leftArrowKey.isPressed ||
             Keyboard.current.aKey.isPressed) && move != 1;

        if (left) offsetX = -speed;

        if (Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.dKey.isPressed)
            offsetX = speed;

        Vector3 newPos = transform.position;
        newPos.x += offsetX;
        newPos.x = Mathf.Clamp(newPos.x, min, max);

        transform.position = newPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LB"))
            move = 1;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LB"))
            move = 0;
    }

    public void updateScore(int index)
    {
        total += points[index];
        textField.SetText("Score: " + total);
    }
}