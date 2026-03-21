using Unity.VisualScripting;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    public CanvasGroup storeMenu;
    [SerializeField] PlayerDetector playerDetector;
    [SerializeField]
    AudioClip computerOnSound, computerOffSound;
    void OnEnable()
    {
        playerDetector.PlayerEnter.AddListener(OnPlayerEnter);
        playerDetector.PlayerExit.AddListener(OnPlayerExit);

    }

    void OnDisable()
    {
        playerDetector.PlayerEnter.RemoveListener(OnPlayerEnter);
        playerDetector.PlayerExit.RemoveListener(OnPlayerExit);
    }

    void OnPlayerEnter()
    {
        ShowStoreMenu();    
        
    }
    void OnPlayerExit()
    {
        HideStoreMenu();
        
    }
    void ShowStoreMenu()
    {
        storeMenu.alpha = 1f;
        storeMenu.interactable = true;
        storeMenu.blocksRaycasts = true;
        AudioOneShotManager.PlayOneShot(computerOnSound);
    }

    public void HideStoreMenu()
    {
        storeMenu.alpha = 0f;
        storeMenu.interactable = false;
        storeMenu.blocksRaycasts = true;
        if(!isMenuClosed()) AudioOneShotManager.PlayOneShot(computerOffSound);

    }

    bool isMenuClosed()
    {
        if(storeMenu.alpha != 0f) return false;
        if(storeMenu.interactable != false) return false;
        if(storeMenu.blocksRaycasts != false) return false;
        return true;
    }
    
}
