using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//T is a variable 
//T is used to code generically
//you don't need to know what T is
//IT can be narrowed down using where T: "Something"
//In this case, T is the whatever class you pass through it

public class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T>
{
    //local variable instance (referencing itself)
    private static T _instance;

    public static T Instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    string typeName = typeof(T).ToString();
                    GameObject go = new GameObject("[Singleton] " + typeName + " Manager");
                    _instance = go.AddComponent<T>();

                }
            }
            return _instance;
        }

    }

    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


}
