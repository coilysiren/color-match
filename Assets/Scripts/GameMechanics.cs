using UnityEngine;

public class GameMechanics {

  public static void generateLevel (int maxSize, GameObject spherePrefab) {
    GameState.maxSize = maxSize;
    GameState.field = new GameObject ("Field");
    GameState.spherePrefab = spherePrefab;
    GameState.sphereGameObjects = new GameObject[maxSize, maxSize];

    setupInitialSphere ();
    setupXAxisSpheres ();
    setupYAxisSpheres ();
  }

  private static GameObject setupSphere (GameObject sphere, int xIndex, int yIndex) {
    sphere.transform.parent = GameState.field.transform;
    ObjectData objectData = sphere.AddComponent (typeof (ObjectData)) as ObjectData;
    objectData.xIndex = xIndex;
    objectData.yIndex = yIndex;
    return sphere;
  }

  private static void setupInitialSphere () {
    GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab);
    GameObject thisSetupSphere = setupSphere (thisSphere, 0, 0);
    GameState.sphereGameObjects[0, 0] = thisSetupSphere;
  }

  private static void setupXAxisSpheres () {
    for (int x = 1; x < GameState.maxSize; x++) {
      GameObject lastXSphere = GameState.sphereGameObjects[x - 1, 0];
      float nextXPos = lastXSphere.transform.position.x +
        GameState.spherePrefab.GetComponentInChildren<Renderer> ().bounds.extents.x * 2;
      Vector3 nextPos = new Vector3 (
        nextXPos,
        lastXSphere.transform.position.y,
        lastXSphere.transform.position.z);

      GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab, nextPos, Quaternion.identity);
      GameObject thisSetupSphere = setupSphere (thisSphere, x, 0);
      GameState.sphereGameObjects[x, 0] = thisSetupSphere;
    }
  }

  private static void setupYAxisSpheres () {
    for (int y = 1; y < GameState.maxSize; y++) {
      GameObject lastYSphere = GameState.sphereGameObjects[0, y - 1];
      float nextYPos = lastYSphere.transform.position.y +
        GameState.spherePrefab.GetComponentInChildren<Renderer> ().bounds.extents.y * 2;
      Vector3 nextPos = new Vector3 (
        lastYSphere.transform.position.x,
        nextYPos,
        lastYSphere.transform.position.z);

      GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab, nextPos, Quaternion.identity);
      GameObject thisSetupSphere = setupSphere (thisSphere, y, 0);
      GameState.sphereGameObjects[y, 0] = thisSetupSphere;
    }

  }

}
