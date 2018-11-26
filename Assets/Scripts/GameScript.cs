using UnityEngine;

public class GameScript : MonoBehaviour {

  public int maxSize = 5;
  public GameObject spherePrefab;

  void Start () {
    GameMechanics.generateLevel (maxSize, spherePrefab);
  }

}
