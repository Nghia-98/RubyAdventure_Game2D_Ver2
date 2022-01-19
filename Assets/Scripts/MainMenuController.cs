using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void PlayGame() {
    // Load Scene
    SceneManager.LoadScene("MainScene");
  }

  public void ShowOptionMenu() {
    // Load Scene
    Debug.Log("Show Option Menu");
  }

  public void QuitGame() {
    Application.Quit();
  }
}