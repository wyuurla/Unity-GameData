using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**
 * @brief GameDataTool
 * @detail GameData를 생성하는 툴.
 * @date 2024-02-13
 * @version 1.0.0
 * @author kij
 */
public class GameDataTool : EditorWindow
{
    [MenuItem("GameTools/GameDataTool")]
    static void Init()
    {
        EditorWindow editorWindow = GetWindow(typeof(GameDataTool));
        editorWindow.Show();
    }

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(GameDataTool));
    }

    string create_script_path { get { return string.Format("{0}/Scripts/GameData/GameDatas", Application.dataPath); } }
    string m_crate_Script_name;

    void OnGUI()
    {
        if( GUILayout.Button("Open GameData", GUILayout.Width(200) ))
        {
            Application.OpenURL(Application.persistentDataPath);
        }

        GUILayout.Label("Create Scripts FilePath : " + create_script_path);
        m_crate_Script_name = EditorGUILayout.TextField("class name : ", m_crate_Script_name, GUILayout.Width(500));
        if( string.IsNullOrWhiteSpace(m_crate_Script_name) == false &&  GUILayout.Button("Create", GUILayout.Width(100)))
        {
            CreateGameDataScript(m_crate_Script_name);
        }
    }

    void CreateGameDataScript( string _className )
    {
        string _classFilePath = string.Format("{0}/{1}.cs", create_script_path, _className);
        if (System.IO.File.Exists(_classFilePath) == true)
        {
            EditorUtility.DisplayDialog("error", "File Exist", "OK");
            return;
        }    

        System.Text.StringBuilder _sb = new System.Text.StringBuilder();

        _sb.Append("[System.Serializable]");
        _sb.Append("\n");
        _sb.AppendFormat("public class {0} : GameData \n", _className);
        _sb.Append("{\n");
        _sb.AppendFormat("\tstatic {0} m_instance;", _className);
        _sb.Append("\n");
        _sb.Append("\t");
        _sb.AppendFormat("public static {0} Instance {{ get {{ if (m_instance == null) {{ m_instance = GameDataManager.Instance.GetGameData<{0}>();}} return m_instance; }} }}", _className);
        _sb.Append("\n");
        _sb.Append("\tpublic override void Init()\n");
        _sb.Append("\t{\n");
        _sb.Append("\t\tbase.Init();");
        _sb.Append("\n\t}");
        _sb.Append("\n}");

        FileUtil.Save(_classFilePath, _sb.ToString() );
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("success", "script create success", "OK");
    }
}