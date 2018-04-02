using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Factory
{
    #region Product
    public interface IPhone
    {
        void Version();
    }
    #endregion

    //苹果手机
    public class ProductApple:IPhone
    {
        public virtual void Version()
        {
            Debug.Log("苹果手机");
        }
    }
    //三星手机
    public class ProductSamsung : IPhone
    {
        public void Version()
        {
            //throw new System.NotImplementedException();
            Debug.Log("三星手机");
        }
    }

    #region Factory
    public  interface IFactory
    {
        IPhone Create();
    }

    public class AppleFactory : IFactory
    {
        public virtual IPhone Create()
        {
            //throw new System.NotImplementedException();
            return new ProductApple();
        }
    }

    public class SumsungFactory:IFactory
    {
        public virtual IPhone Create()
        {
            return new ProductSamsung();
        }
    }
    #endregion
}

public class GameObjectFactory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
