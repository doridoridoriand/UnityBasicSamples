using UnityEngine;
using System.Collections;

public class DestroyByRaser : MonoBehaviour {

  public GameObject explosion;
  public GameObject playerExplosion;

  void OnTriggerEnter(Collider other) {
    // gameObjectの名前がBoundaryだったら以降の処理をやめる
    // (枠からはみ出さないようにしている透明エリアを例外とするため。そうじゃないと実行した瞬間にOnTriggerEnterで自身が消えてしまうから)
    if (other.name == "Boundary") {
      return;
    }
    Instantiate(explosion, transform.position, transform.rotation);
    if (other.name == "Player") {
      Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
    }
    Destroy(other.gameObject);
    Destroy(gameObject);
  }
}
