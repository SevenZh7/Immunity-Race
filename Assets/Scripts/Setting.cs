using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public void SettingButton()
    {
        SceneManagerManager.Instance.SetPreviousSceneIndex();
        SceneManager.LoadScene("Settings");
    }
}
