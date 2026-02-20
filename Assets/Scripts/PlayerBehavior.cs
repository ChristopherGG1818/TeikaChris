using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//whatever bro
//follow the way the sprites folder to make it easier 

public class PlayerBehavior : MonoBehaviour{
    public float speed;
    private GameObject currentball;
    public float offY  = -0.6f;
    public float min; 
    public float max;
    public int move;

    public int[] points;
    public int total;
    public TMP_Text textField;


    public GameObject[] balls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        move =0; // 0 means you can move both ways
        total =0;
    } 

    void Update(){

        if(currentball != null){
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f, offY, 0.0f);
            currentball.transform.position = playerPos + ballOffset;
        }
        else{
            int choice = Random.Range(0, balls.Length);
            currentball  = Instantiate(balls[choice], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame){
            Rigidbody2D body = currentball.GetComponent<Rigidbody2D>();
            body.gravityScale= 1.0f;

            Collider2D collider  = currentball.GetComponent<Collider2D>();
            collider.enabled = true;

            currentball = null;
        }

        //keyboard movement of player
        float offset = 0.0f;
        bool left = (Keyboard.current.leftArrowKey.isPressed|| Keyboard.current.aKey.isPressed) && move != 1;
        if(left == true){
            offset = -speed;
        }

        if(Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.dKey.isPressed){
            offset = speed;
        }

        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset;
        
        //float startTime = 0.0f;
        if(transform.position.x > max){
            //startTime  = Time.time;
            newPos.x = max;
        }
        transform.position = newPos;


        if(transform.position.x < min){
            newPos.x = min;
        }
        transform.position = newPos;


    }
    private void OnCollisionEnter2D(Collision2D other){
    print("you touched " + other.gameObject.name);
    if (other.gameObject.CompareTag("LB")){
            move = 1; // cannot move left
        }
    }

    private void OnCollisionStay2D(Collision2D other){
    print("you are touching " + other.gameObject.name);
    }


    private void OnCollisionExit2D(Collision2D other) {
    print("you stopped " + other.gameObject.name);
    if (other.gameObject.CompareTag("LB")){
        move = 0; // can move left again
        }
    }
    public void updateScore(int index){
        total = total + points [index];
        textField.setText("Score: "+ total);
    }

}