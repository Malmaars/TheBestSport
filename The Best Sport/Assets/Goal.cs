using UnityEngine;

public class Goal : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            //score
        }
    }
}
