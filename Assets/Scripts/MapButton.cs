using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapthenWeapon : MonoBehaviour
{
    public void MapThenWeaponButton()
    {
        SceneManagerManager.Instance.SetPreviousSceneIndex();
        SceneManager.LoadScene("MapTesting");
    }
}
