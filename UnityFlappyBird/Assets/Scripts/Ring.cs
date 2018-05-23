using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ring : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.GetComponent<Bird>() != null)
        {
            AudioSource coin = GetComponent<AudioSource>();
            coin.Play();
            GameControl.instance.BirdScored();
            GameControl.instance.BirdScored();

        }

    }
}
