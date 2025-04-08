// Copyright (c) Facebook, Inc. and its affiliates.
// Use of the material below is subject to the terms of the MIT License
// https://github.com/oculus-samples/Unity-SharedSpaces/tree/main/Assets/SharedSpaces/LICENSE

using Unity.Netcode;
using Oculus.Platform;
using System.Collections;
using UnityEngine;

/*
#if UNITY_EDITOR
using UnityEditor;

[InitializeOnLoad]
public static class SharedSpacesTelemetry
{
    static SharedSpacesTelemetry()
    {
        Collect();
    }
    static void Collect(bool force = false)
    {
        if (SessionState.GetBool("OculusTelemetry-module_loaded-SharedSpaces", false) == false)
        {
            OVRPlugin.SetDeveloperMode(OVRPlugin.Bool.True);
            OVRPlugin.SendEvent("module_loaded", "Unity-SharedSpaces", "integration");
            SessionState.SetBool("OculusTelemetry-module_loaded-SharedSpaces", true);
        }
    }
}
#endif
*/
public class SharedSpacesApplication : MonoBehaviour
{
    public bool Synced = false;

    private void Start()
    {
        StartAsync();
    }

    private void StartAsync()
    {
        Core.AsyncInitialize().OnComplete(OnOculusPlatformInitialized);

    }
    private void OnOculusPlatformInitialized(Message<Oculus.Platform.Models.PlatformInitialize> message)
    {
        if (message.IsError)
        {
            LogError("Failed to initialize Oculus Platform SDK", message.GetError());
            return;
        }

        Synced = true;
        Debug.Log("Oculus Platform SDK initialized successfully");
    }
    private void LogError(string message, Oculus.Platform.Models.Error error)
    {
        Debug.LogError(message);
        Debug.LogError("ERROR MESSAGE:   " + error.Message);
        Debug.LogError("ERROR CODE:      " + error.Code);
        Debug.LogError("ERROR HTTP CODE: " + error.HttpCode);
    }
}
