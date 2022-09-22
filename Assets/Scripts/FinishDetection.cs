using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetection : MonoBehaviour
{
    [SerializeField] float delayTillRestart = 1f;
    [SerializeField] ParticleSystem particles;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            particles.Play();
            GetComponent<AudioSource>().Play();
            Invoke("RestartLevel", delayTillRestart);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
