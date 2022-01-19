using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
  private void OnTriggerStay2D(Collider2D orther) {
    RubyController rubyController = orther.GetComponent<RubyController>();

    if (rubyController != null) {
      rubyController.ChangeHealth(-1);
      Debug.Log("DamageZone: Ruby heal " + rubyController.health);
    }
  }
}
