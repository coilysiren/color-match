using UnityEngine;

public class GameMechanics {

  public static void generateLevel (int maxSize) {
    GameState.maxSize = maxSize;
    GameState.colorIndex = new int[maxSize, maxSize];
    GameState.colorGameObject = new GameObject[maxSize, maxSize];
    GameObject field = new GameObject ("Field");

    for (int x = 0; x < maxSize; x++) {
      for (int y = 0; y < maxSize; y++) {
        GameObject thisGameObject = new GameObject ("Point");
        thisGameObject.transform.parent = field.transform;
        ObjectData thisObjectData = thisGameObject.AddComponent (typeof (ObjectData)) as ObjectData;
        thisObjectData.xIndex = x;
        thisObjectData.yIndex = y;
        GameState.colorGameObject[x, y] = thisGameObject;
      }
    }

  }

}
