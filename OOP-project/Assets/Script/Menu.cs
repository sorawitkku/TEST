using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //Text field
    public Text levelText, hitpointText, pesosText, upgradecostText, xpText;

    //logic field
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    //Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;
            if (currentCharacterSelection == GameManager.instance.playerSprite.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprite.Count - 1;

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprite[currentCharacterSelection];
    }

    //Weapon Upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();

    }

    //Update Character Information
    public void UpdateMenu()
    {
        //weapon
        weaponSprite.sprite = GameManager.instance.weaponSprite[GameManager.instance.weapon.weaponLevel];
        if(weaponSprite.sprite == GameManager.instance.weaponSprite[GameManager.instance.weaponPrices.Count ])
        {
            upgradecostText.text = "MAX";
        }
        else 
        { 
            upgradecostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString(); 
        }
        

        //meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();

        //xpbar
        int currLevel = GameManager.instance.GetCurrentLevel();

        if (currLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + " Total exp points";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXP = GameManager.instance.GetXptoLevel(currLevel -1 );
            int currLevelXP = GameManager.instance.GetXptoLevel(currLevel);

            int diff = currLevelXP - prevLevelXP;
            int currXpintoLevel = GameManager.instance.experience - prevLevelXP;

            float completionRatio = (float)currXpintoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 0, 0);
            xpText.text = currXpintoLevel + "/" + diff;

        }

    }
}