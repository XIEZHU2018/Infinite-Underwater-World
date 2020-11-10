using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//大环境中静态物体的批量生成
public class ScrTreePoolCreate : MonoBehaviour
{
    static int treeAmount = 600;
    public GameObject[] treePrefabs;
    static GameObject[] trees;

    void Start()
    {
        trees = new GameObject[treeAmount];
        int currentTreePrefab = 0;

        for (int i = 0; i < treeAmount; i++) {
            trees[i] = (GameObject) Instantiate(treePrefabs[currentTreePrefab], Vector3.zero, Quaternion.identity);
            trees[i].transform.SetParent(this.transform);
            trees[i].SetActive(false);


            currentTreePrefab++;
            if (currentTreePrefab >= treePrefabs.Length) {
                currentTreePrefab = 0;
            }
        }
    }

    static public GameObject getTree() {

        for (int i = 0; i < treeAmount; i++) {
            if (!trees[i].activeSelf) {
                return trees[i];
            }
        }
        return null;
    }
}
