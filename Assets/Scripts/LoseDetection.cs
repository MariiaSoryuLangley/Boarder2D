using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseDetection : MonoBehaviour
{
    [SerializeField] float delayTillRestart = 1f;
    [SerializeField] ParticleSystem particles;
    [SerializeField] AudioClip deathSFX;
    bool alreadyLost = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !alreadyLost)
        {
            alreadyLost = true;
            FindObjectOfType<PlayerController>().DisableControlls();
            particles.Play();
            GetComponent<AudioSource>().PlayOneShot(deathSFX);
            Invoke("RestartLevel", delayTillRestart);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
