using UnityEngine;
using System.Collections;

public class DestroyByRaser : MonoBehaviour {

  public GameObject explosion;

  void OnTriggerEnter(Collider other) {
    // gameObjectの名前がBoundaryだったら以降の処理をやめる
    // (枠からはみ出さないようにしている透明エリアを例外とするため。そうじゃないと実行した瞬間にOnTriggerEnterで自身が消えてしまうから)
    if (other.name == "Boundary") {
      return;
    }
    Destroy(other.gameObject);
    Destroy(gameObject);
    Instantiate(explosion, transform.position, transform.rotation);
  }
}
