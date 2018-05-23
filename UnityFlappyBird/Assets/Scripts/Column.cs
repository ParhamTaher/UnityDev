using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Column : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.GetComponent<Bird> () != null) {

            AudioSource coin = GetComponent<AudioSource>();
            coin.Play();
            GameControl.instance.BirdScored();

        }

    }

}
