using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

  void Start() {
    GetComponent<Rigidbody>().velocity = transform.forward;
  }

  // Update is called once per frame
  void Update() {
    transform.Rotate(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)) * Time.deltaTime);
  }
}
