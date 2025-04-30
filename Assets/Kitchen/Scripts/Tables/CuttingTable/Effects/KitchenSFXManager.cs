using UnityEngine;

// Observer (=> CuttingEffectManager)
public class KitchenSFXManager : MonoBehaviour, IEffectManager
{
    public static KitchenSFXManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource bgmAudioSource;

    private AudioSource fireAudioSource;

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
        GameManager.Instance.OnGameOver += TurnOffBgm;
        GameManager.Instance.OnGameOver += PlayGameOverSound;
    }

    private void OnDisable()
    {
        MoneyManager.Instance.OnMoneyModified -= PlayMoneySound;
        GameManager.Instance.OnGameOver -= TurnOffBgm;
        GameManager.Instance.OnGameOver -= PlayGameOverSound;
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
        fireAudioSource = Instantiate(audioSource, this.transform);
        fireAudioSource.PlayOneShot(FindClip("FireLoop"));
    }

    public void StopFireSound()
    {
        fireAudioSource.Stop();
        Destroy(fireAudioSource.gameObject);
    }

    public void PlayPuttingSound()
    {
        PlaySFX(FindClip("Put"));
    }

    public void PlayPickingUpSound()
    {
        PlaySFX(FindClip("PickUp"));
    }

    public void PlayGameOverSound()
    {
        PlaySFX(FindClip("GameOver"));
    }

    public void PlayDayEndSound()
    {
        PlaySFX(FindClip("DayEnd"));
    }

    public void PlayBellSound()
    {
        PlaySFX(FindClip("Bell"));
    }

    public void PlayThrowSound()
    {
        PlaySFX(FindClip("Throw"));
    }

    public void TurnOffBgm()
    {
        bgmAudioSource.Stop();
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
