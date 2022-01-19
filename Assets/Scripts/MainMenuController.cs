using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

  // Option Menu Property
  public GameObject optionMenu;

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
    optionMenu.SetActive(true);
  }

  public void hideOptionMenu() {
    // Load Scene
    Debug.Log("Hide Option Menu");
    optionMenu.SetActive(false);
  }

  public void QuitGame() {
    Debug.Log("Quit Game");
    Application.Quit();
  }

  public void PauseGame() {
    MyGameManager.Instance.PauseGame();
  }

  public void ResumeGame() {
    MyGameManager.Instance.ResumeGame();
  }
}
