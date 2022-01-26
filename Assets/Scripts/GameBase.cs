using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

#if(UNITY_EDITOR)
public class GameBase : EditorWindow
{
    private void OnGUI()
    {
        #region Style
        GUIStyle simpleText = new GUIStyle();
        simpleText.normal.textColor = Color.yellow;
        simpleText.fontStyle = FontStyle.Bold;

        GUIStyle title = new GUIStyle();
        title.normal.textColor = Color.white;
        title.fontStyle = FontStyle.Bold;
        title.fontSize = 17;

        EditorStyles.miniButton.normal.textColor = Color.green;


        #endregion

        GUILayout.Space(15);

        GUILayout.Label("Game Base", title);

        GUILayout.Space(10);

        GUILayout.Label(" Level Manager'ý kullanmak için levellarýnýzý birer\n'Boþ GameObject'e yerleþtirin ve sahnede aktifliklerini\nkapatýn. Daha sonra " +
            "Level Manager içindeki gereken yerlere\nlevellarýnýzý sürükleyin.\n" +
            "Oyun çalýþýyorken , 'Sonraki levela geç' butonunu kullanarak\nbir sonraki levela geçebilir , ayný þekilde\n alttaki numaralara týklayarak seçtiðiniz\n" +
            "levela gidebilirsiniz ", simpleText);

        GUILayout.Space(15);

        GUILayout.Label(" Game Manager içerisinde üç adet\n buton barýndýrýyor 'win'\n'fail' ve 'restart' " +
        "yazýlý butonlara oyun çalýþýrken\ntýkladýðýnýzda istediðiniz anda.\n" +
         "Oyunu fail edebilir , kazandýrabilir ve \noyunu yeniden baþlatabilirsiniz ", simpleText);

        GUILayout.Space(15);

        GUILayout.Label("Aþaðýdaki butona týklayarak levellar için \ngerekli boþ objelerinizi oluþturabilirsiniz" , simpleText);

        GUILayout.Space(10);

        if(GUILayout.Button("Generate Levels")) 
        {
            GameObject level1 = new GameObject();
            level1.name = "LEVEL1";

            GameObject level2 = new GameObject();
            level2.name = "LEVEL2";

            GameObject level3 = new GameObject();
            level3.name = "LEVEL3";

            GameObject level4 = new GameObject();
            level4.name = "LEVEL4";

            GameObject level5 = new GameObject();
            level5.name = "LEVEL5";
        }

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Play" , EditorStyles.miniButton))
        {
            EditorApplication.isPlaying = true;
        }

        if (GUILayout.Button("Pause/Unpause", EditorStyles.miniButton))
        {
            if (EditorApplication.isPaused == true)
            {
                EditorApplication.isPaused = false; 
            }

            else 
            {
                EditorApplication.isPaused = true;
            }
        }

        if (GUILayout.Button("Stop", EditorStyles.miniButton))
        {
            EditorApplication.isPlaying = false;
        }
        GUILayout.EndHorizontal();


    }

    [MenuItem("Window/Game Base")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<GameBase>("Game Base").minSize = new Vector2(500,500);
        EditorWindow.GetWindow<GameBase>("Game Base").maxSize = new Vector2(500,500);
        EditorWindow.GetWindow<GameBase>("Game Base");
    }
}
#endif