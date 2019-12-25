using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;
using Debug = UnityEngine.Debug;

public class ReferenceInfo
{

}

public class TestEditor
{
    public enum FindType
    {
        Prefab,
    }

    [MenuItem("Assets/查找在Prefab中的引用", priority =101)]
    public static void FindReferencePrefab()
    {
        FindReference(FindType.Prefab);
    }

    public static void FindReference(FindType findType)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        string[] guids = Selection.assetGUIDs;
        List<string> pathList = new List<string>();

        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);

            if (path.IndexOf(".") == -1) //文件夹
            {
                string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                for (int j = 0; j < files.Length; j++)
                {
                    string file = files[j];
                    if (file.IndexOf(".meta") > 0)
                    {
                        continue;
                    }
                    else
                    {
                        pathList.Add(file);
                    }
                }
            }
            else //文件
            {
                pathList.Add(path);
            }
        }

        for (int i = 0; i < pathList.Count; i++)
        {
            Debug.Log(pathList[i]);
        }

        if (findType == FindType.Prefab)
        {
            string[] ids = AssetDatabase.FindAssets("t:Prefab", new string[] { "Assets" });
            string[] paths = new string[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(ids[i]);
                EditorUtility.DisplayProgressBar("Hold On", path, (float)i / ids.Length);
                string[] depends = AssetDatabase.GetDependencies(path);
                for (int j = 0; j < depends.Length; j++)
                {
                    for (int k = 0; k < pathList.Count; k++)
                    {

                    }
                }
            }
        }
    }
}
