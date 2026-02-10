using UnityEngine;

public class SportBehavior : MonoBehaviour
{
    public float timeout = 3f;
    private float timeStart;


    void Start(){ 

    } 
    void Update(){

     }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Top")){
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.CompareTag("Top")){
            float timeThusfar = Time.time - timeStart;
            if (timeThusfar > timeout){
                print("game over dude");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.CompareTag("Top")){
            timeStart = 0f;
        }
    }
}