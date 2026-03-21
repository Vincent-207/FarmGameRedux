using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CraftingStation : MonoBehaviour
{
    [SerializeField] Disease cureType;
    [SerializeField] InputActionReference craftingInput;
    [SerializeField] float craftingDuration;
    [SerializeField] AmountBar amountBar;
    [SerializeField] PlayerDetector playerDetector;
    [SerializeField]
    AudioClip craftingSound;

    void OnEnable()
    {
        craftingInput.action.started += Craft;
    }
    void OnDisable()
    {
        
        craftingInput.action.started -= Craft;
    }

    void Craft(InputAction.CallbackContext context)
    {
        if(playerDetector.GetIsPlayerClose())
        {
            StartCoroutine(Craft(craftingDuration));
            
        }
    }

    IEnumerator Craft(float duration)
    {
        float elapsedTime = 0f;
        amountBar.gameObject.SetActive(true);
        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            amountBar.SetProportion(elapsedTime / duration);

            if(!craftingInput.action.IsPressed() || !playerDetector.GetIsPlayerClose())
            {
                // Cancel crafting
                amountBar.gameObject.SetActive(false);
                yield break;
            }

            yield return null;
        }

        // Craft and add
        Inventory.instance.AddCure(cureType);
        amountBar.gameObject.SetActive(false);
        AudioOneShotManager.PlayOneShot(craftingSound);

    }
}
