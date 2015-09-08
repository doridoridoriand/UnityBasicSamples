using UnityEngine;
using System.Collections;

public class RandomObjectGenerator : MonoBehaviour {

  public GameObject targetGameObject;
  public float MinRange, MaxRange;

  // Use this for initialization
  void Start () {
    for (int i = 0; i <= 500; i++) {
      Instantiate(targetGameObject, new Vector3(Random.Range(MinRange, MaxRange),
            Random.Range(MinRange, MaxRange),
            Random.Range(MinRange, MaxRange)),
            Quaternion.Euler(Random.Range(0, 180),
                             Random.Range(0, 180),
                             Random.Range(0, 180)));
    }
  }
}
