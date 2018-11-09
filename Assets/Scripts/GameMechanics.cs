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
    setupXYSpheres ();
  }

  private static GameObject setupSphereData (GameObject sphere, int xIndex, int yIndex) {
    sphere.transform.parent = GameState.field.transform;
    ObjectData objectData = sphere.AddComponent (typeof (ObjectData)) as ObjectData;
    objectData.xIndex = xIndex;
    objectData.yIndex = yIndex;
    return sphere;
  }

  private static void setupInitialSphere () {
    GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab);
    GameObject thisSetupSphere = setupSphereData (thisSphere, 0, 0);
    GameState.sphereGameObjects[0, 0] = thisSetupSphere;
  }

  private static void setupXAxisSpheres () {
    int y = 0;
    for (int x = 1; x < GameState.maxSize; x++) {
      GameObject lastSphere = GameState.sphereGameObjects[x - 1, y];
      Vector3 lastSpherePos = lastSphere.transform.position;
      Vector3 prefabExtents = GameState.spherePrefab.GetComponentInChildren<Renderer> ().bounds.extents;

      Vector3 nextPos = new Vector3 (
        lastSpherePos.x + prefabExtents.x * 2,
        lastSpherePos.y,
        lastSpherePos.z);

      GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab, nextPos, Quaternion.identity);
      GameObject thisSetupSphere = setupSphereData (thisSphere, x, y);
      GameState.sphereGameObjects[x, y] = thisSetupSphere;
    }
  }

  private static void setupYAxisSpheres () {
    int x = 0;
    for (int y = 1; y < GameState.maxSize; y++) {
      GameObject lastSphere = GameState.sphereGameObjects[x, y - 1];
      Vector3 lastSpherePos = lastSphere.transform.position;
      Vector3 prefabExtents = GameState.spherePrefab.GetComponentInChildren<Renderer> ().bounds.extents;

      Vector3 nextPos = new Vector3 (
        lastSpherePos.x,
        lastSpherePos.y + prefabExtents.y * 2,
        lastSpherePos.z);

      GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab, nextPos, Quaternion.identity);
      GameObject thisSetupSphere = setupSphereData (thisSphere, x, y);
      GameState.sphereGameObjects[x, y] = thisSetupSphere;
    }
  }

  private static void setupXYSpheres () {
    for (int x = 1; x < GameState.maxSize; x++) {
      for (int y = 1; y < GameState.maxSize; y++) {
        GameObject lastXSphere = GameState.sphereGameObjects[x, y - 1];
        Vector3 lastXSpherePos = lastXSphere.transform.position;
        GameObject lastYSphere = GameState.sphereGameObjects[x - 1, y];
        Vector3 lastYSpherePos = lastYSphere.transform.position;
        Vector3 prefabExtents = GameState.spherePrefab.GetComponentInChildren<Renderer> ().bounds.extents;

        Vector3 nextPos = new Vector3 (
          lastYSpherePos.x + prefabExtents.x * 2,
          lastXSpherePos.y + prefabExtents.y * 2,
          lastXSpherePos.z);

        GameObject thisSphere = GameObject.Instantiate (GameState.spherePrefab, nextPos, Quaternion.identity);
        GameObject thisSetupSphere = setupSphereData (thisSphere, x, y);
        GameState.sphereGameObjects[x, y] = thisSetupSphere;
      }
    }
  }

}
