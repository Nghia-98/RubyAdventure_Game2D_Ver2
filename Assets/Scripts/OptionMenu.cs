using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour {
  public AudioMixer audioMixer;

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  // Change volume
  public void ChangeVolume(float value) {
    audioMixer.SetFloat("volume", value);
  }
}
