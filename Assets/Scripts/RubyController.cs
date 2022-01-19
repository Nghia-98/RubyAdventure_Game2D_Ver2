using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RubyController : MonoBehaviour {
  private Rigidbody2D rb2d;
  // Move Speed
  public float speed = 2.5f;

  float horizontal;
  float vertical;

  //Look direction Vector2
  Vector2 lookDirection = new Vector2(0, 0);

  // Animator property
  Animator animator;

  //Health
  public int maxHealth = 10;
  int currentHealth;
  public int health {
    get { return currentHealth; }
    set { currentHealth = value; }
  }

  // Timer for Damege
  float timeInvincible = 2.0f;
  bool isInvincible;
  float invincibleTimer;

  public GameObject projectilePrefab;

  AudioSource audioSource;

  public AudioClip hitSound;

  // Ruby input action property
  RubyInputAction rubyInputAction;

  Vector2 currentInput;

  void Start() {
    //Get Rigidbody2D component
    rb2d = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();

    // Setup Health
    currentHealth = maxHealth;

    // Input
    rubyInputAction = new RubyInputAction();
    rubyInputAction.Ruby.Enable();

    // Input actions
    rubyInputAction.Ruby.Launch.performed += Launch;
    rubyInputAction.Ruby.Movenment.performed += OnMovenment;
    rubyInputAction.Ruby.Movenment.canceled += OnMovenment;
    rubyInputAction.Ruby.Talk.performed += TalkingWithJambi;
  }

  // Update is called once per frame
  void Update() {

    if (isInvincible) {
      invincibleTimer -= Time.deltaTime;
      if (invincibleTimer <= 0) {
        isInvincible = false;
      }
    }

    if (Input.GetKeyDown(KeyCode.X)) {
      
    }
  }

  void FixedUpdate() {

    if (currentInput.magnitude > 0.01) {
      Vector2 position = rb2d.position;
      position = position + currentInput * speed * Time.deltaTime;

      rb2d.MovePosition(position);
    }


    Vector2 move = new Vector2(currentInput.x, currentInput.y);
    if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
      lookDirection.Set(move.x, move.y);
      lookDirection.Normalize();
    }

    animator.SetFloat("Look X", lookDirection.x);
    animator.SetFloat("Look Y", lookDirection.y);
    animator.SetFloat("Speed", move.magnitude);
  }

  public void ChangeHealth(int amount) {
    if (amount < 0) {

      animator.SetTrigger("Hit");

      if (isInvincible) {
        return;
      }
      isInvincible = true;
      invincibleTimer = timeInvincible;
    }
    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
  }

  void Launch(InputAction.CallbackContext context) {
    if (context.performed) {
      GameObject projectileObject = Instantiate(projectilePrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
      Projectile projectile = projectileObject.GetComponent<Projectile>();

      projectile.Launch(lookDirection, 300f);
      animator.SetTrigger("Launch");
    }
  }

  public void PlaySound(AudioClip clip) {
    Debug.Log("Has Eat");
    audioSource.PlayOneShot(clip);
  }

  void OnMovenment(InputAction.CallbackContext context) {
    if (context.performed) {
      currentInput = context.ReadValue<Vector2>();
    }
    if (context.canceled) {
      currentInput = Vector2.zero;
      Debug.Log("canceled " + currentInput);
    }
  }

  void TalkingWithJambi(InputAction.CallbackContext context) {
    if(context.performed) {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, 1.5f, LayerMask.GetMask("NPC"));

      if (hit.collider != null) {
        Debug.Log("Hit " + hit.collider.name);

        MyNPC character = hit.collider.GetComponent<MyNPC>();
        if (character != null) {
          character.showDialogBox();
        }
      }
    }
  }
}
