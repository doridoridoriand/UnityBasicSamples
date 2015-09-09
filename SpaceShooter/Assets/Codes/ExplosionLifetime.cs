using UnityEngine;
using System.Collections;

public class ExplosionLifetime : MonoBehaviour {

  public int effectLifetime;

  void Start () {
    Destroy(gameObject, effectLifetime);
  }
}
