using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour {
    #region Enemy
    public GameObject Hero;
    public GameObject perfab;
    List<GameObject> enemy = new List<GameObject>();
    int Max_Amount = 10;

    void setEnemy()
    {
        for (int i = 0; i < Max_Amount; i++)
        {
            if (!enemy[i].GetComponent<Enemy>().GetUsed())
            {
                enemy[i].GetComponent<Enemy>().init(true, 2f,2f, enemy[i].transform.localScale, enemy[i].transform.localPosition, Quaternion.identity, 100);
                return;
            }
        }
        print("enmey all busy!create new!");
       
    }
    void addEnemy()
    {
        enemy.Add(Instantiate(perfab, Vector3.left * 2 * 2, Quaternion.identity) as GameObject);
        ++Max_Amount
            ;
    }

    #endregion

    #region Pool
    //实例化自己
    public static GameObjectPool instance;
    //创建一个字典dic 键为子弹或敌人种类 值为数组 存放多个同样的子弹或敌人
    public static Dictionary<string, ArrayList> dic = new Dictionary<string, ArrayList>();

    //调用方法返回一个属于需要的种类的敌人
    //key是敌人预设体名字，预设体放在resources中
    //参数为（obj名字，激活位置，激活角度）
    public static GameObject Get(string key,Vector3 position,Quaternion rotataion)
    {
        GameObject go;
        string GameobjectName = key + "Clone";
        //如果字典中有gameobjectname这个key并且kye对应的数组不为空（有该种类敌人，且该种类敌人已经创建过）
        if (dic.ContainsKey(GameobjectName)&&dic[GameobjectName].Count>0)
        {
            //get array from  the key name of "gameobjectname"  
            ArrayList list = dic[GameobjectName];
            //get enemy
            go = (GameObject)list[0];
            //remove the enemy
            dic[GameobjectName].RemoveAt(0);

            go.SetActive(true);
            go.transform.position = position;
            //...
        }
        else
        {
            go = Instantiate(Resources.Load(key), position, rotataion) as GameObject;
        }
        return go;
    }

    //方法return 参数是需要取消激活的对象g
    //将需要取消激活的对象取消
    public static GameObject Return(GameObject g)
    {
        string key = g.name;
        if (dic.ContainsKey(key))
        {
            dic[key].Add(g);
        }
        else
        {
            dic[key] = new ArrayList() { g };
        }
        g.SetActive(false);
        return g;
    }

    #endregion

    #region Mono
    // Use this for initialization
    void Start () {
        InvokeRepeating("setEnemy", 1, 10);
        for (int i = 0; i < Max_Amount; i++)
        {
            enemy.Add(Instantiate(perfab, Vector3.left * i * 2, Quaternion.identity) as GameObject);
        }

        //自身被调用
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion
}
