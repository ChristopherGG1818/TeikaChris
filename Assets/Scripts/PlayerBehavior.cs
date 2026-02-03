using UnityEngine;
using UnityEngine.InputSystem;

//whatever bro
//follow the way the sprites folder to make it easier 



public class PlayerBehavior : MonoBehaviour{
    public float speed;
    private GameObject currentball;
    public float offY  = -0.6f;

    public int[] numbers;

    public GameObject[] balls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        // for (int  i=0 l; i < numbers.length; if++){
        //     print(numbers[i]);
        // }
    }

    //int choice =  

    // Update is called once per frame
    void Update(){
        //int choice  = Random.Range(27, 60);
        //print (choice)


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
        if(Keyboard.current.leftArrowKey.isPressed|| Keyboard.current.aKey.isPressed){
            offset = -speed;
        }

        if(Keyboard.current.rightArrowKey.isPressed|| Keyboard.current.dKey.isPressed){
            offset = speed;
        }

        Vector3 newPos = transform.position;
        newPos.x = newPos.x + offset;
        transform.position = newPos;
    }
}