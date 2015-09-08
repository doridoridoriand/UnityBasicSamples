using UnityEngine;
using System.Collections;

public class OwnShip : MonoBehaviour {

  public float speed;
  public float tilt;

  void FixedUpdate () {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
    GetComponent<Rigidbody>().velocity = movement * speed;

    GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.y, 0.0f, GetComponent<Rigidbody>().velocity.x * tilt);
  }
}
