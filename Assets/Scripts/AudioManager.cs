using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting Sfx")]
    [SerializeField] AudioClip shootSfx;
    [SerializeField] [Range(0f, 1f)] float shootSfxVolume;
    [Header("Damage Sfx")]
    [SerializeField] AudioClip damageSfx;
    [SerializeField] [Range(0f, 1f)] float damageSfxVolume;

    void Awake()
    {
        ManageSingleton();
    }
    public void ShootSfx()
    {
        if(shootSfx != null)
        {
            AudioSource.PlayClipAtPoint(shootSfx, Camera.main.transform.position, shootSfxVolume);
        }
    }

    public void DamageSfx()
    {
        if(damageSfx != null)
        {
            AudioSource.PlayClipAtPoint(damageSfx, Camera.main.transform.position, damageSfxVolume);
        }
    }

    void ManageSingleton()
    {
        int instanceCount = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;
        if(instanceCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
