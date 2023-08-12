using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private AudioSource _collectionSoundEffect;

    private int _coin = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            _collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            _coin++;
            _coinsText.text = "Coins: " + _coin.ToString();

        }
    }
}
