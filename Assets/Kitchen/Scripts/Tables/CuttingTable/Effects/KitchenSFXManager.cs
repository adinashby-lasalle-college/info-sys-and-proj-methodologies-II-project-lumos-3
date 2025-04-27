using UnityEngine;

// Observer (=> CuttingEffectManager)
public class KitchenSFXManager : MonoBehaviour, IEffectManager
{
    public static KitchenSFXManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource fireAudioSource; // only for fire sfx (to play/stop easily)
    [SerializeField] private AudioClip[] audioClips;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        MoneyManager.Instance.OnMoneyModified += PlayMoneySound;
    }

    private void OnDisable()
    {
        MoneyManager.Instance.OnMoneyModified -= PlayMoneySound;
    }

    public void PlayCuttingEffect(float sliceCount, float maxCount)
    {
        if (sliceCount <= maxCount && sliceCount != 0)
        {
            PlaySFX(FindClip("CuttingSound"));
        }  
    }

    private void PlayMoneySound(int price)
    {
        PlaySFX(FindClip("CashRegister"));
    }

    public void PlayButtonClickSound()
    {
        PlaySFX(FindClip("Button"));
    }

    public void PlayFireSound()
    {
        fireAudioSource.Play();
    }

    public void StopFireSound()
    {
        fireAudioSource.Stop();
    }

    public void PlayPuttingSound()
    {
        PlaySFX(FindClip("Put"));
    }

    public void PlayPickingUpSound()
    {
        PlaySFX(FindClip("PickUp"));
    }

    private AudioClip FindClip(string name)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == name)
            {
                return clip;
            }
        }

        return null;
    }

    public void PlaySFX(AudioClip clip)
    {
        AudioSource tempAS = Instantiate(audioSource, this.transform);
        tempAS.PlayOneShot(clip);

        Destroy(tempAS.gameObject, clip.length);
    }
}
