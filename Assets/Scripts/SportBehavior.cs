using UnityEngine;

public class SportBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;

    public GameObject[] balls;
    public int ballType;


    void Start(){ 

        balls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().balls;

    } 
    void Update(){

     }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("fruit")){
            int otherType = other.gameObject.GetComponent<SportBehavior>().ballType;
            if(otherType == ballType &&  ballType < balls.Length -1){
                //Destroy both thigs and create the merged one
                if(gameObject.transform.position.x<= other.transform.position.x || 
                (gameObject.transform.position.x== other.transform.position.x && gameObject.transform.position.y>= other.transform.position.y)){
                    int choice = ballType+1;

                    



                    GameObject currentball  = Instantiate(balls[choice], Vector3.Lerp(gameObject.transform.position, other.gameObject.transform.position, 0.5f), Quaternion.identity);
                    currentball.GetComponent<Collider2D>().enabled = true;
                    currentball.GetComponent<Rigidbody2D>().gravityScale =1.0f;


                   // GetComponent<AudioSource>()


                    GameObject.FindGameObjectWithTag("Player").
                    GetComponent<PlayerBehavior>().updateScore(ballType);

                    Destroy(other.gameObject);
                    Destroy(gameObject);

                }
            }
        }
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