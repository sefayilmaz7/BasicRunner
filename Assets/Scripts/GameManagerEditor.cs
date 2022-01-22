using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

#if(UNITY_EDITOR)

[CustomEditor(typeof(GameManagerScript))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI() 
    {
        #region Color Styles

        //renk tanýmlamalarý
        GUIStyle green = new GUIStyle();
        green.normal.textColor = Color.green;
        

        GUIStyle red = new GUIStyle();
        red.normal.textColor = Color.red;
        

        GUIStyle blue = new GUIStyle();
        blue.normal.textColor = Color.blue;


        GUIStyle yellow = new GUIStyle();
        yellow.normal.textColor = Color.yellow;
        yellow.fontStyle = FontStyle.Bold;

        EditorStyles.miniButton.fontStyle = FontStyle.Bold;
        EditorStyles.miniButton.fixedWidth = 100;
        EditorStyles.miniButton.fixedHeight = 30;
        EditorStyles.miniButton.fontSize = 15;
        EditorStyles.miniButton.normal.textColor = new Color32(160,182,248,255);

        #endregion


        base.OnInspectorGUI();
        GUILayout.Space(10);
        GUILayout.Label("Win Fail Restart durumlarýný buradan yönetebilirsiniz" ,yellow);
        GUILayout.Space(20);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Win" , EditorStyles.miniButton)) 
        {
            LevelManager.levelIndex++;
            UIManager.instance.complete.SetActive(true);
        }

        if (GUILayout.Button("Fail" , EditorStyles.miniButton))
        {
            UIManager.instance.fail.SetActive(true);
        }

        if (GUILayout.Button("Restart" , EditorStyles.miniButton))
        {
            GameManagerScript.instance.Reload();
        }

        GUILayout.EndHorizontal();
    }
}
#endif