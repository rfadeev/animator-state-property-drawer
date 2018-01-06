﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
using UnityEngine;

namespace UnityForge
{
    public class ScenePathExample02 : MonoBehaviour
    {
        [SerializeField, ScenePath(sceneManagerPathType: false, fromBuildSettings: false)]
        private string exampleScenePath;

#if UNITY_EDITOR
        [ContextMenu("Open Scene At Path")]
        private void OpenExampleScene()
        {
            // Executing this method in Unity 2017.1.1f1 results in console message
            // "Assertion failed: Assertion failed on expression: 'm_InstanceID != InstanceID_None'"
            EditorSceneManager.OpenScene(exampleScenePath, OpenSceneMode.Single);
        }

        [ContextMenu("Open Scene At Path Additive")]
        private void OpenExampleSceneAdditive()
        {
            EditorSceneManager.OpenScene(exampleScenePath, OpenSceneMode.Additive);
        }

        [ContextMenu("Ping Scene At Path")]
        private void PingExampleScene()
        {
            var exampleSceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(exampleScenePath);
            EditorGUIUtility.PingObject(exampleSceneAsset);
        }
#endif
    }
}