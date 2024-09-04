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
        PlayerPrefs.DeleteAll();
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    // ressources
    public List<Sprite> playerSprite;
    public List<Sprite> weaponSprite;
    public List<int> weaponPrice;
    public List<int> xpTable;

    // References
    public Player player;
    public weapon weapon;
    public FloatingTextManager floatingTextManager;

    // logic 
    public int gold;
    public int exp;
    //Floating text
    public void ShowText(string msg, int fonsize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fonsize, color, position, motion, duration);
    }


    // upgrade weapon
    public bool TryUpgradeWeapon()
    {
        // is the weapon max level? 
        if (weaponPrice.Count <= weapon.weaponLevel)
            return false;
        if (gold >= weaponPrice[weapon.weaponLevel])
        {
            gold -= weaponPrice[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
    }



    // experience system
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;
        while (exp >= add)
        {
            add += xpTable[r];
            r++;
            if (r == xpTable.Count)
                return r;
        }
        return r;
    }
    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;
    }
    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        exp += xp;
        if (currLevel < GetCurrentLevel())
            OnLevelUp();
    }
    public void OnLevelUp()
    {
        player.OnLevelUp();
    }
    // save state
    /*
    int preferdSkin
    int gold
    int exp
    int weapon level
    */
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += gold.ToString() + "|";
        s += exp.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        string[] data = PlayerPrefs.GetString("SaveState").Split("|");
        // change player skin
        gold = int.Parse(data[1]);
        //experience
        exp = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
            player.SetLevel(GetCurrentLevel());
        // change weapon level
        weapon.SetWeaponLevel(int.Parse(data[3]));

        player.transform.position=GameObject.Find("SpawnPoint").transform.position;
    }



}
