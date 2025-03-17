using UnityEngine;

// Observer (=> CuttingEffectManager)
public class KitchenSFXManager : MonoBehaviour, IEffectManager
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    public void PlayEffect(float sliceCount, float maxCount)
    {
        if (sliceCount <= maxCount && sliceCount != 0)
        {
            foreach (AudioClip clip in audioClips)
            {
                if (clip.name == "SFX_Cutting")
                {
                    audioSource.clip = clip;
                    audioSource.Play();
                }
            }
        }  
    }
}
