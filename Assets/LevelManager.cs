using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public int currentLevle;
    public float[] EnermySpawnRate;
    public float[] LongRangeEnermyRate;
    public static LevelManager Instance { get; set; }

    private int[] timePos = new[] {117215, 206513};
    
    [SerializeField]public List<ItemData> buyList;
    private int currentTime;
    private MusicOnCamera musicOnCamera;
    public bool spawnEnermy = true;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        musicOnCamera = Camera.main.GetComponent<MusicOnCamera>();
        musicOnCamera.MusicInstance.setParameterByName("game_state", 0);

    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnEnermy());
    }
    

    // Update is called once per frame
    void Update()
    {
        musicOnCamera.MusicInstance.getTimelinePosition(out currentTime);

        if (currentTime > 45000)
        {
            currentLevle = 1;
            SwitchLevel();
        }
        
        if (currentTime > timePos[0] && currentTime < timePos[1])
        {
            currentLevle = 2;
            SwitchLevel();
        }

        if (currentTime > timePos[1])
        {
            currentLevle = 3;
            SwitchLevel();
        }
    }

    void SwitchLevel()
    {
        if (Phone.Instance.showStage<currentLevle)
        {
            spawnEnermy = false;
            Phone.Instance.DisplayPhone(buyList[currentLevle-1].list);
            switch (currentLevle)
            {
                case 1:
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 2);

                    break;
                case 2:
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 4);

                    break;
                case 3:
                    FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 6);

                    break;
            }
            Phone.Instance.onSelect.AddListener(()=>
            {
                spawnEnermy = true;
                switch (currentLevle)
                {
                    case 1:
                        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 3);
                        break;
                    case 2:
                        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 5);
                        break;
                    case 3:
                        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("game_state", 7);
                        break;
                }
            });
        }
    }

    IEnumerator SpawnEnermy()
    {
        while (true)
        {
            if (!spawnEnermy)
            {
                yield return new WaitForSeconds(0.1744186f*2);
                continue;
            }
            else
            {
                if (Random.Range(0, 10) <=EnermySpawnRate[currentLevle])
                {
                    Side side;
                    if (Random.Range(0, 10) >= 5)
                    {
                        side = Side.Left;
                    }
                    else
                    {
                        side = Side.Right;
                    }

                    EnemyType type;
                    if (Random.Range(0, 10) <= LongRangeEnermyRate[currentLevle])
                    {
                        type = EnemyType.Remote;
                    }
                    else
                    {
                        type = EnemyType.Melee;
                    }

                    EnemyManager.Instance.SpawnEnermy(new EnemyData(type,side,1));
                
                }
                yield return new WaitForSeconds(0.1744186f*2);
            }

        }
    }

    [Serializable]
    public struct ItemData
    {
        public List<GameObject> list;
    }
    
}
