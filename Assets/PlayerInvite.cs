// Copyright (c) Facebook, Inc. and its affiliates.
// Use of the material below is subject to the terms of the MIT License
// https://github.com/oculus-samples/Unity-SharedSpaces/tree/main/Assets/SharedSpaces/LICENSE

using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using Oculus.Platform;

public class SharedSpacesInvitePanel : MonoBehaviour
{
    public bool isOwner = true;

    public void ButtonPressed()
    {
        if (isOwner) return;

#if !UNITY_EDITOR || !UNITY_STANDALONE_WIN
        Debug.Log("Invited Player!");
#else
        GroupPresence.LaunchInvitePanel(new InviteOptions());
#endif
    }
}
