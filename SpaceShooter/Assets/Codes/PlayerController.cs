using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
  // set params
  public float xMin, xMax;
  public float zMin, zMax;
}

public class PlayerController : MonoBehaviour {

  // set params
  public float speed;
  public float tilt;
  public float fireRate;
  public Boundary boundary;

  public GameObject shot;
  public Transform shotSpawn; // もしGameobject型でやりたい場合、positionとrotationの値を取り出しをshotSpawn.transform.positionなどとやる必要がある

  private float nextFire;

  void Update() {
    if (Input.GetButton("Fire1") && Time.time > nextFire) {
      Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
      nextFire = Time.time + fireRate;
      GetComponent<AudioSource>().Play();
    }
  }

  void FixedUpdate() {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    // 基本的な機体の操作
    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
    GetComponent<Rigidbody>().velocity = movement * speed;

    // 機体が画面の外に出ないように行動できる領域を制限する
    GetComponent<Rigidbody>().position = new Vector3(
        Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
        0.0f,
        Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

    // 左右に関する操作に関して、機体を傾ける挙動を追加
    GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * tilt);
  }
}
