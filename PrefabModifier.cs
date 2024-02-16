using UnityEngine;
using UnityEditor;
using System.IO;

public class PrefabModifier : MonoBehaviour
{
    public GameObject prefabToModify;

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 200, 50));
        if (GUILayout.Button("Save Prefab"))
        {
            SavePrefab();
        }
        GUILayout.EndArea();
    }
    GameObject instantiatedPrefab;
    string prefabPath;
    void Start() 
    {
        GameObject originalPrefab = Resources.Load<GameObject>("Prefab Name");
        prefabPath = AssetDatabase.GetAssetPath(originalPrefab);
        instantiatedPrefab = Instantiate(originalPrefab);
    }
    void SavePrefab()
    {
        GameObject newPrefab = PrefabUtility.CreatePrefab(prefabPath, instantiatedPrefab);
        Destroy(instantiatedPrefab);
        AssetDatabase.Refresh();
        Debug.Log("Prefab has been saved permanently.");
    }
}
