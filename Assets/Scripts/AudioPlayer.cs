using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Hitting")]
    [SerializeField] AudioClip hittingClip;
    [SerializeField] [Range(0f, 1f)] float hittingVolume = 1f;

    static AudioPlayer instance;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayHittingClip()
    {
        PlayClip(hittingClip, hittingVolume);
    }

    void PlayClip(AudioClip audioClip, float volume)
    {
        if (audioClip != null)
        {
            Vector3 transform = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(audioClip, transform, volume);
        }
    }
}
