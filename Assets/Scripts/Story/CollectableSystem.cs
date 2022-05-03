using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSystem : MonoBehaviour
{
    public List<GameObject> collectables;

    void Start()
    {
        collectables = new List<GameObject>();
    }

    // Update is called once per frame

    private void AssignCollectableValues() {
        foreach (GameObject collectable in collectables) {
            collectable.GetComponent<Collectable>().value = 1;
        }
        // pick one collectable at random and give it the correct answer
    }

    private void GetRealAnswer() {
        
    }

    private void GenerateFakeAnswers() {

    }
}
