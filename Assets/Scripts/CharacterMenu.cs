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
            // � we went too far away
            if (currenCharacterSelection == GameManager.instance.playerSprite.Count)
                currenCharacterSelection = 0;

            OnSelectionChanged();

        }
        else
        {
            currenCharacterSelection--;
            // � we went too far away
            if (currenCharacterSelection < 0)
                currenCharacterSelection = GameManager.instance.playerSprite.Count - 1;

            OnSelectionChanged();

        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprite[currenCharacterSelection];
    }

    //weapon upgrade
    public void OnUpgradeClick()
    {
        if(GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
         
    }

    // update th character information
    public void UpdateMenu()
    {
        // weapon
        weaponSprite.sprite = GameManager.instance.weaponSprite[0];
        upgradeCostText.text = "Not Implemnented";

        //meta
        levelText.text = "Not Implemnented";
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        goldText.text = GameManager.instance.gold.ToString();

        // xp Bar
        xpText.text = "Not Implemnented";
        xpBar.localScale = new Vector3(0.5f, 0, 0);

    }
}
