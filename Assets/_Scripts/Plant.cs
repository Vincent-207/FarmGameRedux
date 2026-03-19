using TMPro;
using UnityEngine;

public class Plant : MonoBehaviour
{
    PlantType plantType;
    [SerializeField]
    int growthStage, maxGrowthStage;
    [SerializeField]
    TMP_Text debugText;
    void Start()
    {
        Clock.instance.tickEvent.AddListener(Tick);
        debugText.text = growthStage.ToString();
    }

    
    public void Tick()
    {
        IncrementStage();
    }

    void IncrementStage()
    {
        growthStage++;
        if(growthStage > maxGrowthStage) growthStage = maxGrowthStage;
        debugText.text = growthStage.ToString();
    }
}
