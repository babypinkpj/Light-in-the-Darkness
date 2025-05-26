using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
private int coinCount;
    public TMPro.TMP_Text coinText;
    public AudioClip coinSound;
    private AudioSource audioSource;

    public void IncreaseCoin(int amount)
    {
        coinCount += amount;
        coinText.text = coinCount.ToString();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            //AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            audioSource.PlayOneShot(coinSound);
            coinCount++;
            coinText.text = coinCount.ToString();
            Destroy(other.gameObject);
        }
    }
}
