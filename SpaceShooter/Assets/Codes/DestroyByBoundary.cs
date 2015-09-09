using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

  void OnTriggerExit(Collider other) {
    if (!other.gameObject == GameObject.Find("Player")) {
      Destroy(other.gameObject);
    }
  }
}
