using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelCompleted = false;
    private AudioSource _finishSound;
   
    private void Start()
    {
        _finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            _finishSound.Play();
            levelCompleted=true;
            Invoke("CompleteLevel", 1f);
           
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(1);
    }
}
