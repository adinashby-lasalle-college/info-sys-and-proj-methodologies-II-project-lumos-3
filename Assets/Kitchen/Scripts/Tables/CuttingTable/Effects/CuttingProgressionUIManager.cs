using UnityEngine;
using UnityEngine.UI;

// Observer (=> CuttingEffectManager)
public class CuttingProgressionUIManager : MonoBehaviour, IEffectManager
{
    [SerializeField] Image bar;

    public void PlayCuttingEffect(float sliceCount, float maxCount)
    {
        bar.fillAmount = sliceCount / maxCount;
    }
}
