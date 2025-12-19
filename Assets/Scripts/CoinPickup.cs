using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int coinValue = 100;
    [SerializeField] AudioClip coinPickupSFX;

    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !wasCollected)
        {
            wasCollected = true;
            FindFirstObjectByType<GameSession>().AddToScore(coinValue);
            AudioSource.PlayClipAtPoint(coinPickupSFX, transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
