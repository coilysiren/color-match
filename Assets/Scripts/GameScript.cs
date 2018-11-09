using UnityEngine;

public class GameScript : MonoBehaviour {

  public int maxSize = 5;

  void Start () {
    GameMechanics.generateLevel (maxSize);
  }

}
