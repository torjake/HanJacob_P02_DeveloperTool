using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DesignWindo : EditorWindow{

    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow() 
    {
        DesignWindo window = (DesignWindo)GetWindow(typeof(DesignWindo));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }
}
