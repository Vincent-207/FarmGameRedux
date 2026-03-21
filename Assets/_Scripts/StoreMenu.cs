using Unity.VisualScripting;
using UnityEngine;

public class StoreMenu : MonoBehaviour
{
    public CanvasGroup storeMenu;
    [SerializeField] PlayerDetector playerDetector;
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
    }

    void HideStoreMenu()
    {
        storeMenu.alpha = 0f;
        storeMenu.interactable = false;
        storeMenu.blocksRaycasts = true;

    }
    
}
