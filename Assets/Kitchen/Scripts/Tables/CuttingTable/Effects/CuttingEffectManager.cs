using System.Collections.Generic;
using UnityEngine;

// Observable
public class CuttingEffectManager : MonoBehaviour
{
    [SerializeField] CuttingProgressionUIManager UIManager;
    [SerializeField] KitchenSFXManager SFXManager;

    private static CuttingEffectManager Instance; // Singleton
    private List<IEffectManager> effectManagers = new();

    private void Start()
    {
        Instance = this;

        effectManagers.Add(UIManager);
        effectManagers.Add(SFXManager);
    }

    public void UpdateEffect(float sliceCount, float maxCount)
    {
        foreach (IEffectManager effectManager in effectManagers)
        {
            effectManager.PlayEffect(sliceCount, maxCount);
        }
    }

    public static CuttingEffectManager GetInstance()
    {
        return Instance;
    }
}
