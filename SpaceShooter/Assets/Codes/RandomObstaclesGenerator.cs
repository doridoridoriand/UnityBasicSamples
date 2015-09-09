using UnityEngine;
using System.Collections;

public class RandomObstaclesGenerator : MonoBehaviour {

  public GameObject targetGameObject;
  public float minRange, maxRange;
  public int numberOfObstacles;
  public float startObstacle;
  public float intarvalOfGenerateObstacle;

  void Start() {
    StartCoroutine (GenerateObstacles());
  }

  IEnumerator GenerateObstacles() {
    yield return new WaitForSeconds(startObstacle);
    while (true)
    {
      for (int counter = 0; counter < numberOfObstacles; counter++) {
        Instantiate(targetGameObject,
            new Vector3(Random.Range(minRange, maxRange),
              0.0f,
              20.0f),
            Quaternion.Euler(0.0f, 0.0f, 0.0f)
            // 初期の運動に回転を入れると、2次元ゲームなのにもかかわらず奥行きが出て悲惨なことになったのでとりあえず無し
            //Quaternion.Euler(Random.Range(0, 180),
            //                 Random.Range(0, 180),
            //                 Random.Range(0, 180))
            );
        yield return new WaitForSeconds(intarvalOfGenerateObstacle);
      }
    }
  }
}
