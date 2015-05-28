using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public GameObject Test;


    // Use this for initialization
    void Start()
    {
        ItemPropertie(Test);
    }
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            JumpPower(Test.GetComponent<Item>());
        }
    }

    public void JumpPower(Item I)
    {
        Test.rigidbody.AddForce(Vector3.up * 100);
    }

    public void ItemPropertie(GameObject obj)
    {
        Item.instance.SetJump(obj);
    }
}
