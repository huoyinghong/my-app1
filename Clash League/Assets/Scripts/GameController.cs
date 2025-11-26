using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public float goldAmount;
    public float remainingTime;
    public List<UnitInfo> unitInfos;

    private void Awake()
    {
        Instance = this;
        remainingTime = 180;
        unitInfos = new List<UnitInfo>()
        {
            new UnitInfo(){ ID = 1, name = "Elven Archer", cost = 3, attackRange = 4, hp = 10, damage = 2, speed = 1},
            new UnitInfo(){ ID = 2, name = "Healing Angel", cost = 4, attackRange = 3, hp = 10, damage = 1, speed = 1},
            new UnitInfo(){ ID = 3, name = "Cerberus Wolf", cost = 6, attackRange = 2, hp = 30, damage = 5, speed = 1},
            new UnitInfo(){ ID = 4, name = "Fallen Angel", cost = 6, attackRange = 2.5f, hp = 10, damage = 6, speed = 2},
            new UnitInfo(){ ID = 5, name = "Lava Behemoth", cost = 8, attackRange = 2, hp = 30, damage = 4, speed = 1},
            new UnitInfo(){ ID = 6, name = "Archer Brothers", cost = 5, attackRange = 4, hp = 10, damage = 2, speed = 1},
            new UnitInfo(){ ID = 7, name = "Armored Bear Legion", cost = 7, attackRange = 8, hp = 10, damage = 8, speed = 2},
            new UnitInfo(){ ID = 8, name = "Reaper", cost = 6, attackRange = 7, hp = 10, damage = 7, speed = 1},
            new UnitInfo(){ ID = 9, name = "Plaguebringer", cost = 4, attackRange = 1.5f, damage = 1, speed = 1, canCreateAnywhere = true},
            new UnitInfo(){ ID = 10, name = "Fireball", cost = 4, attackRange = 2f, damage = 3, speed = 18, canCreateAnywhere = true},
            new UnitInfo(){ ID = 11, name = "Shipwreck Monster", cost = 0, attackRange = 1.5f, hp = 2, damage = 1, speed = 1},
            new UnitInfo(){ ID = 12, name = "Healing Aura", cost = 0, attackRange = 2f, damage = 2, speed = 18}

        };
    }

    // Update is called once per frame
    void Update()
    {
        if (goldAmount < 10)
        {
            goldAmount += Time.deltaTime;
            UIManager.Instance.SetGoldAmount();
            UIManager.Instance.SetGoldSlider();
        }
        DecreaseTime();
    }

    public void DecreaseTime()
    {
        remainingTime -= Time.deltaTime;
        int min = (int) (remainingTime / 60);
        int sec = (int) (remainingTime % 60);
        UIManager.Instance.SetTime(min, sec);
    }

    /// <summary>
    /// Check current gold is enough to use the card
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool CanUseCard(int id)
    {
        return unitInfos[id - 1].cost <= goldAmount;
    }

}
