using Unity.Collections;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public struct UnitInfo
{
    public int ID;
    public string name;
    public int cost;
    public int hp;
    public float attackRange;
    public float speed;
    public float damage;
    public bool canCreateAnywhere;
}
