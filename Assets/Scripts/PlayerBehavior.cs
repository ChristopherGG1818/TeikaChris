using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerBehavior : MonoBehaviour{
    public float speed;
    public GameObject ball;
    private GameObject currentball;
    public float offY  = -0.6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if(currentball != null){
            Vector3 playerPos = transform.position;
            Vector3 ballOffset = new Vector3(0.0f, offY, 0.0f);
            ball.transform.position = playerPos + ballOffset;
        }
        else{
            currentball  = Instantiate(ball, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
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
    }
}