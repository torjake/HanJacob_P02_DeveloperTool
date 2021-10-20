using UnityEngine;
using UnityEditor;

public class VoxelWindow : EditorWindow
{
    int Width = 0;
    int Length = 0;
    int Height = 0;

    GameObject spawnObject;

    Color color;


    [MenuItem("Window/VoxelBuilder")]
    public static void ShowWindow() 
    {
        GetWindow<VoxelWindow>("VoxelBuilder");
    }

    private void OnGUI()
    {

        GUILayout.Label("Set Size of Cube Spawn", EditorStyles.boldLabel);

        spawnObject = EditorGUILayout.ObjectField("Cube Prefab", spawnObject, typeof(GameObject), false) as GameObject;

        Width = EditorGUILayout.IntField("Width", Width);
        Length = EditorGUILayout.IntField("Length", Length);
        Height = EditorGUILayout.IntField("Height", Height);


        if (GUILayout.Button("Spawn Cubes")) 
        {
            CubeSpawn();
        }

        GUILayout.Label("Select A Cube And Hit Button To Delete", EditorStyles.boldLabel);
        if (GUILayout.Button("Delete Selected")) 
        {
            Delete();
        }

        GUILayout.Label("Select A Cube And A Color And Hit The Button", EditorStyles.boldLabel);
        color = EditorGUILayout.ColorField("Color", color);
        if (GUILayout.Button("Set Color"))
        {
            ColorCube();
        }
    }

    void CubeSpawn() 
    {
        for (int i = 0; i < Width; i++)
        {
            float spawnPointX = 0;
            spawnPointX = i * 1f;
            //
            for (int a = 0; a < Length; a++)
            {
                float spawnPointY = 0;
                spawnPointY = a * 1f;
                //
                for (int b = 0; b < Height; b++)
                {
                    float spawnPointZ = 0;
                    spawnPointZ = b * 1f;
                    //
                    Vector3 spawnPoint = new Vector3(0, 0, 0);
                    spawnPoint += new Vector3(spawnPointX, spawnPointZ, spawnPointY);
                    Instantiate(spawnObject, spawnPoint, Quaternion.identity);
                }
            }
        }
    }

    void Delete() 
    {
        foreach (GameObject obj in Selection.gameObjects) 
        {
            if (obj != null) 
            {
                DestroyImmediate(obj);
            }
        }
    }
    void ColorCube() 
    {
        foreach (GameObject objCol in Selection.gameObjects) 
        {
            Renderer render = objCol.GetComponent<Renderer>();

            if (render != null) 
            {
                DestroyImmediate(render.material);
                //render.material = new Material(mats);
                //render.sharedMaterial.color = color;
                //render.material.SetColor("red",Color.red);
                //render.material = mat;
                render.material.color = color;
            }
        }   
    }
}
