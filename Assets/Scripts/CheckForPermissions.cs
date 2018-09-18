using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPermissions : MonoBehaviour
{
    public GameObject m_PermissionsPanel;
    private const string RECORDAUDIO_PERMISSION = "android.permission.RECORD_AUDIO";

    // Use this for initialization
    void Start()
    {
        //m_PermissionsPanel.SetActive(!CheckPermissions());
        OnGrantButtonPress();
    }

    public void OnGrantButtonPress()
    {
        AndroidPermissionsManagerOwn.RequestPermission(new[] { RECORDAUDIO_PERMISSION }, new AndroidPermissionCallback(
            grantedPermission =>
            {
             // The permission was successfully granted, restart the change avatar routine
             //OnBrowseGalleryButtonPress();
             Debug.Log("Permission granted!");
            },
            deniedPermission =>
            {
             // The permission was denied.
             // Show in-game pop-up message stating that the user can change permissions in Android Application Settings
             // if he changes his mind (also required by Google Featuring program)
             Debug.Log("Permission denied!");

            }));
        m_PermissionsPanel.SetActive(false);
    }


    private bool CheckPermissions()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            return true;
        }

        return AndroidPermissionsManagerOwn.IsPermissionGranted(RECORDAUDIO_PERMISSION);
    }


}