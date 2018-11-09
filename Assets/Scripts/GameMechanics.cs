using UnityEngine;

public class GameMechanics {

  public static void generateLevel (int maxSize) {
    GameState.maxSize = maxSize;
    GameState.colorIndex = new int[maxSize, maxSize];
    GameState.colorGameObject = new GameObject[maxSize, maxSize];

    for (int x = 0; x < maxSize; x++) {
      for (int y = 0; y < maxSize; y++) {
        GameObject thisGameObject = new GameObject ("Point");
        ObjectData thisObjectData = thisGameObject.AddComponent (typeof (ObjectData)) as ObjectData;
        thisObjectData.xIndex = x;
        thisObjectData.yIndex = y;
        GameState.colorGameObject[x, y] = thisGameObject;
      }
    }

  }

}
