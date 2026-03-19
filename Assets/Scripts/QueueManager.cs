// using UnityEngine;

// public class QueueManager : MonoBehaviour
// {
//     public Sprite[] UISprites;
//     public int[] queue; 
//     private SpriteRenderer[] childrenderers;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         queue = new int[4];
//         for(int i =0; i< 4; i++){
//             queue[i] = Random.Range(0,4);
//         }

//         childrenderers = new SpriteRenderer[4];
//         for(int i =0; i< transform.childCount; i++){
//             queue[i] = Random.Range(0,4);
//             childrenderers[i] =  transform.GetChild(i).GetComponent<SpriteRenderer>();
//         }
        
//     }

//     // Update is called once per frame
//     void Update()
//     {

//         for(int i =0; i< transform.childCount; i++){
//             childrenderers[i].sprite = UISprites[queue[i]];
//         }
        
//     }
//     public int updatequeue(){
//         int currentType = queue[0];


//         for(int i =1; i< 4; i++){
//             queue[i-1]= queue[i];
//         }
//         queue[3]= Random.Range(0,4);

//         return currentType;
//     }
// }


using UnityEngine;
public class QueueManager : MonoBehaviour
{
    public Sprite[] UISprites;        
    public SpriteRenderer[] slots;   
    public int[] queue = new int[4];
    void Start()
    {
        for (int i = 0; i < queue.Length; i++)
        {
            queue[i] = Random.Range(0, UISprites.Length);
        }
        UpdateUI();
    }
    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].sprite = UISprites[queue[i]];
        }
    }
    public int UpdateQueue()
    {
        int next = queue[0];
        for (int i = 0; i < queue.Length - 1; i++)
        {
            queue[i] = queue[i + 1];
        }
        queue[queue.Length - 1] =
            Random.Range(0, UISprites.Length);
        UpdateUI();
        return next;
    }
}