using System.Collections.Generic;
using UnityEngine;

// Observable
public class CuttingEffectManager : MonoBehaviour
{
    [SerializeField] CuttingProgressionUIManager UIManager;
    [SerializeField] KitchenSFXManager SFXManager;

    private List<IEffectManager> effectManagers = new();

    private void Start()
    {
        effectManagers.Add(UIManager);
        effectManagers.Add(SFXManager);
    }

    public void UpdateEffect(float sliceCount, float maxCount)
    {
        foreach (IEffectManager effectManager in effectManagers)
        {
            effectManager.PlayCuttingEffect(sliceCount, maxCount);
        }
    }
}
