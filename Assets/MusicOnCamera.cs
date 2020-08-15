using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOnCamera : MonoBehaviour
{
    [FMODUnity.EventRef] public string MusicEvent;

    public FMOD.Studio.EventInstance MusicInstance;
    
    // Start is called before the first frame update
    void Start()
    {
        MusicInstance = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);
        MusicInstance.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
