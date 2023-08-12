using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [SerializeField] private AudioSource deathSoundEffect;
    private Rigidbody2D _rigitbody2D;
    private Animator _animator;


    private void Start()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();

        }
    }


    private void Die()
    {
        deathSoundEffect.Play();
       // _rigitbody2D.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger("death");

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
