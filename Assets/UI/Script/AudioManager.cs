using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
        
        // Enable looping
        musicSource.loop = true;
        
    }
    
}
