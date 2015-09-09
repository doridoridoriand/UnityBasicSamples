using UnityEngine;
using System.Collections;

public class DestroyByRaser : MonoBehaviour {

  public GameObject explosion;
  public GameObject playerExplosion;
  public int scoreValue;
  private RandomObstaclesGenerator randomObstaclesGenerator;

  // ゲームが実行されてからじゃないとRandomObstaclesGeneratorを参照出来ないので、Start()時にClassを参照しに行く
  void Start() {
    GameObject randomObstaclesGeneratorObject = GameObject.Find("RandomObstaclesGenerator");
    // 無事にGameObjectが入手出来た時の条件分岐
    if (randomObstaclesGeneratorObject != null) {
      randomObstaclesGenerator = randomObstaclesGeneratorObject.GetComponent<RandomObstaclesGenerator>();
    }
    // エラー処理みたいなもん(まあどうせゲームとまるんだけど)
    if (randomObstaclesGenerator == null) {
      Debug.Log("'RandomObstaclesGenerator'を発見出来ませんでした");
    }
  }

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
    randomObstaclesGenerator.AddScore(scoreValue);
    Destroy(other.gameObject);
    Destroy(gameObject);
  }
}
