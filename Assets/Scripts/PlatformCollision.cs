using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] string playerTag = "PlayerObj";
    [SerializeField] Transform plateform;

     private void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.tag.Equals(playerTag))
        {
            other.gameObject.transform.parent = plateform;
        }
     }
     
     private void OnTriggerExit(Collider other)
     {
        if (other.gameObject.tag.Equals(playerTag))
        {
            other.gameObject.transform.parent = null;
        }
    }


}
