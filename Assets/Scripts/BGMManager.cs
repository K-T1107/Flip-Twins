using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }

    private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    // ë¶éûBGMêÿÇËë÷Ç¶
    public void PlayBGM(AudioClip clip)
    {
        if (clip == null) return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    // âπó í≤êÆ
    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }
}