using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour {
  // Singleton
  private static MyGameManager _instance;

  public static MyGameManager Instance {
    get {
      if (_instance == null) {
        _instance = new MyGameManager();
      }
      return _instance;
    }
  }

  // Pause Game
  public void PauseGame() {
    Time.timeScale = 0f;
  }

  // Resume Game
  public void ResumeGame() {
    Time.timeScale = 1f;
  }
}
