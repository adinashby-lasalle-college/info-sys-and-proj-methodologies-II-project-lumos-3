using System.Collections.Generic;
using UnityEngine;

// Observable
public class CuttingEffectManager : MonoBehaviour
{
    [SerializeField] CuttingProgressionUIManager UIManager;
    // * SoundEffectManager

    private List<IEffectManager> effectManagers = new();

    private void Start()
    {
        effectManagers.Add(UIManager);
    }

    public void UpdateEffect(float sliceCount, float maxCount)
    {
        foreach (IEffectManager effectManager in effectManagers)
        {
            effectManager.PlayEffect(sliceCount, maxCount);
        }
    }
}
