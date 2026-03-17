// using UnityEngine;
// using UnityEngine.InputSystem;
// using TMPro;

// //whatever bro
// //follow the way the sprites folder to make it easier 

// public class PlayerBehavior : MonoBehaviour{
//     public float speed;
//     private GameObject currentball;
//     public float offY  = -0.6f;
//     public float min; 
//     public float max;
//     public int move;

//     public int[] points;
//     public int total;
//     public TMP_Text textField;


//     public GameObject[] balls;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start(){

//         move =0; // 0 means you can move both ways
//         total =0;
//     } 

//     void Update(){

//         if(currentball != null){
//             Vector3 playerPos = transform.position;
//             Vector3 ballOffset = new Vector3(0.0f, offY, 0.0f);
//             currentball.transform.position = playerPos + ballOffset;
//         }
//         else{
//             int choice = GameObject.FindGameObjectWithTag("Queue").GetComponent<PlayerBehavior>().balls;
//             //int choice = Random.Range(0, balls.Length);
//             currentball  = Instantiate(balls[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
//         }

//         if(Keyboard.current.spaceKey.wasPressedThisFrame){
//             Rigidbody2D body = currentball.GetComponent<Rigidbody2D>();
//             body.gravityScale= 1.0f;

//             Collider2D collider  = currentball.GetComponent<Collider2D>();
//             collider.enabled = true;

//             currentball = null;
//         }

//         //keyboard movement of player
//         float offset = 0.0f;
//         bool left = (Keyboard.current.leftArrowKey.isPressed|| Keyboard.current.aKey.isPressed) && move != 1;
//         if(left == true){
//             offset = -speed;
//         }

//         if(Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.dKey.isPressed){
//             offset = speed;
//         }

//         Vector3 newPos = transform.position;
//         newPos.x = newPos.x + offset;
        
//         //float startTime = 0.0f;
//         if(transform.position.x > max){
//             //startTime  = Time.time;
//             newPos.x = max;
//         }
//         transform.position = newPos;


//         if(transform.position.x < min){
//             newPos.x = min;
//         }
//         transform.position = newPos;


//     }
//     private void OnCollisionEnter2D(Collision2D other){
//     print("you touched " + other.gameObject.name);
//     if (other.gameObject.CompareTag("LB")){
//             move = 1; // cannot move left
//         }
//     }

//     private void OnCollisionStay2D(Collision2D other){
//     print("you are touching " + other.gameObject.name);
//     }


//     private void OnCollisionExit2D(Collision2D other) {
//     print("you stopped " + other.gameObject.name);
//     if (other.gameObject.CompareTag("LB")){
//         move = 0; // can move left again
//         }
//     }
//     public void updateScore(int index){
//         total = total + points [index];
//         textField.SetText("Score: "+ total);
//     }

// }


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
        // keep ball attached
        if (currentball != null)
        {
            Vector3 offset = new Vector3(0f, offY, 0f);
            currentball.transform.position =
                transform.position + offset;
        }
        else
        {
            int choice = Random.Range(0, balls.Length);
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