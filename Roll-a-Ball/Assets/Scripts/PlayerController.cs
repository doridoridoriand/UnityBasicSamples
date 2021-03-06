﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

  public float speed;
  public Text countText;
  private Rigidbody  rbody;
  private int count;

  // Start is  called  at initiarize
  void Start () {
    rbody = GetComponent<Rigidbody> ();
    count = 0;
    SetCountText();
  }

  void FixedUpdate() {
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 
    rbody.AddForce (movement * speed); 
  }

  void OnTriggerEnter(Collider other) {
    if (other. gameObject.CompareTag ("Cubes")) {
      other.gameObject.SetActive (false);
      count = count + 1;
      SetCountText();
      return;
    }
  }

  void SetCountText() { 
    countText.text = "count: " + count.ToString();
  }
}
