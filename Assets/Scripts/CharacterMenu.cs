using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields 
    public Text levelText, hitpointText, goldText, upgradeCostText, xpText;
    //logic
    private int currenCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;
    //Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currenCharacterSelection++;
            // If we went too far away
            if (currenCharacterSelection == GameManager.instance.playerSprite.Count)
                currenCharacterSelection = 0;

            OnSelectionChanged();

        }
        else
        {
            currenCharacterSelection--;
            // If we went too far away
            if (currenCharacterSelection < 0)
                currenCharacterSelection = GameManager.instance.playerSprite.Count - 1;

            OnSelectionChanged();

        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprite[currenCharacterSelection];
        GameManager.instance.player.SwapSprite(currenCharacterSelection);
    }

    //weapon upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();

    }

    // update th character information
    public void UpdateMenu()
    {
        // weapon
        weaponSprite.sprite = GameManager.instance.weaponSprite[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrice.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrice[GameManager.instance.weapon.weaponLevel].ToString();

        //meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        goldText.text = GameManager.instance.gold.ToString();

        // xp Bar
        int currenLevel = GameManager.instance.GetCurrentLevel();
        if (GameManager.instance.GetCurrentLevel() == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.exp.ToString() + "total experience points"; // display total xp
        }
        else
        {
            int preLevelXp = GameManager.instance.GetXpToLevel(currenLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currenLevel);

            int diff = currLevelXp - preLevelXp;
            int currXpIntoLevel = GameManager.instance.exp - preLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + "/" + diff;
        }
      

    }
}
