using UnityEngine;

public class GameScript : MonoBehaviour {

  public int maxSize;

  void Start () {
    GameMechanics.generateLevel(maxSize);
  }

}
