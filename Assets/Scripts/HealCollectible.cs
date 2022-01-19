using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCollectible : MonoBehaviour {
  public int giveHeal = 1;
  public AudioClip collectSound;

  // Detect collision trigger
  private void OnTriggerEnter2D(Collider2D collision) {
    Debug.Log("Collision " + collision.gameObject.name);
    RubyController rubyController = collision.GetComponent<RubyController>();
    if (rubyController != null) {
      if (rubyController.health < rubyController.maxHealth) {
        rubyController.ChangeHealth(giveHeal);
        Debug.Log("Ruby Heal:  " + rubyController.health);
        Destroy(gameObject);

        rubyController.PlaySound(collectSound);
      }
    }
  }
}
