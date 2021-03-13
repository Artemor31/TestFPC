using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;
    private InputManager _inputManager;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _inputManager = FindObjectOfType<InputManager>();
    }

    private void Start()
    {
        _audioSource.clip = _audioClip;
        _audioSource.loop = true;
    }

    private void Update()
    {
        if (_inputManager.IsMoving())
            PlayFootstepsSound();
        else
            StopFootstepsSound();
    }

    private void PlayFootstepsSound()
    {
        _audioSource.Play();
    }    
    private void StopFootstepsSound()
    {
        if (_audioSource.isPlaying)
            _audioSource.Stop();
    }
    
    
}
