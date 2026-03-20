
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField]
    PlantType plantType;
    [SerializeField]
    int growthStage, maxGrowthStage;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Sprite[] growthSprites;
    // Diseases
    [SerializeField] Disease disease = Disease.None;
    [SerializeField] SpriteRenderer DiseaseOverlay;
    [SerializeField] Sprite[] DiseaseSprites;
    
    [SerializeField] float DiseaseChance = 0.3f;
    bool isWet = false;
    public Disease GetDisease()
    {
        return disease;
    }
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Clock.instance.tickEvent.AddListener(Tick);
        spriteRenderer.sprite = growthSprites[growthStage];
    }

    void OnDestroy()
    {
        Clock.instance.tickEvent.RemoveListener(Tick);
        
    }
    public bool isHarvestable()
    {
        return growthStage == maxGrowthStage;
    }
    
    public void Tick()
    {
        if(disease != Disease.None)
        {
            Die();
            return;       
        }

        HandleDiseaseGeneration();
        IncrementStage();
    }

    void HandleDiseaseGeneration()
    {
        float chance = Random.Range(0f, 1f);
        bool spawnDisease = DiseaseChance > chance;
        if(spawnDisease) 
        {
            disease = (Disease) Random.Range(1, System.Enum.GetValues(typeof(Disease)).Length);
            DiseaseOverlay.sprite = DiseaseSprites[(int) disease];
        }
    }

    void Cure()
    {
        disease = Disease.None;
        DiseaseOverlay.sprite = null;
    }

    public void Cure(Disease cureType)
    {
        if(disease == cureType)
        {
            Cure();
        }
    }

    void IncrementStage()
    {
        growthStage++;
        if(growthStage > maxGrowthStage) growthStage = maxGrowthStage;
        spriteRenderer.sprite = growthSprites[growthStage];
    }

    void Die()
    {
        
        Destroy(gameObject);
    }

    public PlantType GetPlantType()
    {
        return plantType;
    }
}

public enum Disease
{
    None,
    PowderyMildew,
    Aphid
}
