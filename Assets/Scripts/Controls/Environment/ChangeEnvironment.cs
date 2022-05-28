using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeEnvironment : MonoBehaviour
{
    public static GameObject navMeshObject;

    const string NAVMESH = "NavMeshAreas";
    private static List<Transform> children;

    void Start() {
        navMeshObject = GameObject.Find(NAVMESH);
        Debug.Log(navMeshObject);
        children = new List<Transform>(navMeshObject.transform.GetComponentsInChildren<Transform>());
    }

    public static void DisableMovement() {
        foreach (Transform child in children) {
            child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }   
    }

    public static void EnableMovement() {
        foreach (Transform child in children) {
            child.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
