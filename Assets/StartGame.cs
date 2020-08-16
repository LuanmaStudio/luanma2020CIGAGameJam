using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        var musicOnCamera = Camera.main.GetComponent<MusicOnCamera>();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 1);
        LevelManager.Instance.StartSpawn();
        Phone.Instance.HidePhone();
    }
}
