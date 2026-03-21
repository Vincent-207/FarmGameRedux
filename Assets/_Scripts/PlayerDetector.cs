using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    public UnityEvent PlayerEnter, PlayerExit;
    bool IsPlayerClose;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            PlayerEnter.Invoke();
            IsPlayerClose = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            PlayerExit.Invoke();
            IsPlayerClose = false;
        }
    }

    public bool GetIsPlayerClose()
    {
        return IsPlayerClose;
    }
}
