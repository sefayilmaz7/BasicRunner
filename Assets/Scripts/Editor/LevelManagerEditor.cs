using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if(UNITY_EDITOR)

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{


    public override void OnInspectorGUI()
    {
        #region Color Styles

        //renk tanýmlamalarý
        GUIStyle green = new GUIStyle();
        green.normal.textColor = Color.green;
        green.fontStyle = FontStyle.Bold;

        GUIStyle red = new GUIStyle();
        red.normal.textColor = Color.red;

        GUIStyle blue = new GUIStyle();
        blue.normal.textColor = Color.blue;


        EditorStyles.miniButton.fontStyle = FontStyle.Bold;
        EditorStyles.miniButton.fixedWidth = 50;
        EditorStyles.miniButton.normal.textColor = Color.green;

        #endregion


        base.OnInspectorGUI();
        GUILayout.Space(10);
        GUILayout.Label(text: "LEVELLARINIZI BURAYA SÜRÜKLEYÝNÝZ" , green );

        GUILayout.Space(20);

        if (GUILayout.Button("Sonraki Level'a Geç")) 
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            GameManagerScript.instance.Reload();
        }

        // Týklanýnca seçilen level'a gitmek için kullanýlan butonlar
        #region Level Butonlarý
        GUILayout.BeginHorizontal();

        GUILayout.Space(35);

        if (GUILayout.Button("1", EditorStyles.miniButton))
        {
            PlayerPrefs.SetInt("level", 0);
            GameManagerScript.instance.Reload();
        }
        else if (GUILayout.Button("2", EditorStyles.miniButton))
        {
            PlayerPrefs.SetInt("level", 1);
            GameManagerScript.instance.Reload();
        }
        else if (GUILayout.Button("3", EditorStyles.miniButton))
        {
            PlayerPrefs.SetInt("level", 2);
            GameManagerScript.instance.Reload();
        }
        else if (GUILayout.Button("4", EditorStyles.miniButton))
        {
            PlayerPrefs.SetInt("level", 3);
            GameManagerScript.instance.Reload();
        }
        else if (GUILayout.Button("5", EditorStyles.miniButton))
        {
            PlayerPrefs.SetInt("level", 4);
            GameManagerScript.instance.Reload();
        }



        GUILayout.EndHorizontal();

        #endregion
    }

}
#endif