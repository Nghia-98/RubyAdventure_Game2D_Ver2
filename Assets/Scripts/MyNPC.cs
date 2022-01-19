using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNPC : MonoBehaviour {
  public float displayTime = 5f;
  public GameObject dialogBox;
  float timerDisplay;

  void Start() {
    dialogBox.SetActive(false);
    timerDisplay = -1.0f;
  }

  // Update is called once per frame
  void Update() {
    if(timerDisplay >= 0) {
      timerDisplay -= Time.deltaTime;

      if(timerDisplay < 0) {
        dialogBox.SetActive(false);
      }
    }
  }

  public void showDialogBox() {
    timerDisplay = displayTime;
    dialogBox.SetActive(true);
  }
}
