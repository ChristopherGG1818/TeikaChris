// using UnityEngine;
// public class QueueMaker : MonoBehaviour
// {
//     public Sprite[] UISprites;        
//     public SpriteRenderer[] slots;   
//     public int[] queue = new int[4];
//     void Start()
//     {
//         for (int i = 0; i < queue.Length; i++)
//         {
//             queue[i] = Random.Range(0, UISprites.Length);
//         }
//         UpdateUI();
//     }
//     void UpdateUI()
//     {
//         for (int i = 0; i < slots.Length; i++)
//         {
//             slots[i].sprite = UISprites[queue[i]];
//         }
//     }
//     public int UpdateQueue()
//     {
//         int next = queue[0];
//         for (int i = 0; i < queue.Length - 1; i++)
//         {
//             queue[i] = queue[i + 1];
//         }
//         queue[queue.Length - 1] =
//             Random.Range(0, UISprites.Length);
//         UpdateUI();
//         return next;
//     }
// }