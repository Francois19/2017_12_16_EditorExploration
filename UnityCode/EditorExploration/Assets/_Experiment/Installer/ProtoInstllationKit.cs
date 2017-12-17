﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class ProtoInstllationKit : MonoBehaviour {

    public string [] _folders;
    public FileToDownload [] _webFiles;
    public void Awake()
    {
        InstallBasicStructure(this);
        Destroy(this.gameObject);
    }


    public static string[] _foldersToCreate = new string[] {
        "/_Project/",
        "/_Project/Assets",
        "/_Project/Assets/2D",
        "/_Project/Assets/3D",
        "/_Project/Assets/Sound",
        "/_Project/Assets/Music",
        "/_Project/Assets/Material",
        "/_Project/Scripts/",
        "/_Project/Scene/",
        "/_Project/Scene/Demo/",
        "/_Project/Scene/Exemple/",
        "/_Project/Prefab/",
        "/_Project/ReadMe/",
        "/_Project/ReadMe/License",
        "/_Project/ReadMe/Documentation",
        "/_Project/ReadMe/Credits"
    };
    public static FileToDownload[] _fileToDownload = new FileToDownload[] { };

    [MenuItem("Toolbox/Setup/Project")]
    public static void InstallBasicStructure ()
    {
        Debug.Log("Install start");
        CreateGitIgnoreAtProjectRoot();
        CreateFolderStructure();
        AssetDatabase.Refresh();
        Application.OpenURL("https://trello.com/");
        Application.OpenURL("https://github.com/new");
        // DownloadFile();
    }


    private void InstallBasicStructure(ProtoInstllationKit protoInstllationKit)
    {
        ProtoInstllationKit._foldersToCreate = _folders;
        ProtoInstllationKit._fileToDownload = _webFiles;
        InstallBasicStructure();

    }

    private static void CreateFolderStructure()
    {
        for (int i = 0; i < _foldersToCreate.Length; i++)
        {
            CreateFolder(_foldersToCreate[i]);
        }
    }

    private static void CreateFolder(string path, string readMe = "...")
    {
        string appDataPath = Application.dataPath;
        path = appDataPath +"/"+ path;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            
        }
        if (Directory.GetFiles(path).Length <= 0)
            File.WriteAllText(path + "/readme.txt", readMe);

    }

    private static void CreateGitIgnoreAtProjectRoot()
    {
        string _gitIgnore = "/[Ll]ibrary/\n" + "/[Tt]emp/\n" + "/[Oo]bj/\n" + "/[Bb]uild/\n" + "/[Bb]uilds/\n" + "/ Assets/AssetStoreTools*\n" + "/.vs/\n" + "ExportedObj/\n" + ".consulo/\n" + "*.csproj\n" + "*.unityproj\n" + "*.sln\n" + "*.suo\n" + "*.tmp\n" + "*.user\n" + "*.userprefs\n" + "*.pidb\n" + "*.booproj\n" + "*.svd\n" + "*.pdb\n" + "*.pidb.meta\n" + "sysinfo.txt\n" + "*.apk\n" + "*.unitypackage\n";
        string pathGitIgnore = Application.dataPath + "/../.gitignore";
        if (File.Exists(pathGitIgnore))
            File.Delete(pathGitIgnore);
        File.WriteAllText(pathGitIgnore, _gitIgnore);
    }
}

[System.Serializable]
public class FileToDownload
{
    public string _localPath ;
    public string _urlPath;
}
