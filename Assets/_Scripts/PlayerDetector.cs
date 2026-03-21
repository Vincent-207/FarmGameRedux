using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public UnityEvent PlayerEnter, PlayerExit;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            PlayerEnter.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            PlayerExit.Invoke();
        }
    }
}
