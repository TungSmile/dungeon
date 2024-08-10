using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded+=LoadState;
        DontDestroyOnLoad(gameObject);
    }
    // ressources
    public List<Sprite> playerSprite;
    public List<Sprite> weaponSprite;
    public List<int> weaponPrice;
    public List<int> xpTable;

    // References
    public player player;


    // logic 
    public int gold;
    public int exp;

// save state
    public void SaveState()
    {

    }
    public void LoadState(Scene s,LoadSceneMode mode)
    {

    }

}
