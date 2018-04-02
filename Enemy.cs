using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    bool isUsed = false;

    public bool GetUsed()
    {
        return false;
    }

    public void init(bool _isUsed,float _moveSpeed,float _act,Vector3 _scale,Vector3 _pos , Quaternion _qua,int Max_hp)
    {

    }

    void Die()
    {
        isUsed = false;
        this.transform.gameObject.SetActive(false);
        //添加死亡事件
    }
	// Use this for initialization
	void Start () {
        GameObject go = GameObjectPool.Get("", Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
