using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnCamera : MonoBehaviour
{
    [FMODUnity.EventRef] public string MusicEvent;

    public FMOD.Studio.EventInstance MusicInstance;
    
    // Start is called before the first frame update
    private void Awake()
    {
        MusicInstance = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        MusicInstance.start();

    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        MusicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        MusicInstance.release();
    }
}
