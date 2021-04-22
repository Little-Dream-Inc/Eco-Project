using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public GarbageType type; //TODO make read-only
    CameraShake shaker;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failSound;
    AudioSource audioSource;
    ScoreManager scoreManager;
    LevelManager levelManager;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        shaker = FindObjectOfType<CameraShake>();
        scoreManager = FindObjectOfType<ScoreManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("triggered!!");
        if (collision.gameObject.CompareTag("Garbage"))
        {
            bool isCorrect = false;
            var garbage = collision.gameObject.GetComponent<Garbage>();
            if (garbage.type == type)
            {
                isCorrect = true;
                scoreManager.AddScore(garbage.GetScorePrice());
            }
            GarbageFeedback(isCorrect);
            Destroy(collision.gameObject, .2f);
        }
    }

    void GarbageFeedback(bool isCorrect)
    {
        if(isCorrect)
        {
            print("Great");
            successParticles.Play();
            audioSource.PlayOneShot(successSound);
        }
        else
        {
            levelManager.OnFail();

            print("Wrong!");
            audioSource.PlayOneShot(failSound);
            shaker.shakeDuration = 0.5f;
            Handheld.Vibrate();
        }
    }
}
