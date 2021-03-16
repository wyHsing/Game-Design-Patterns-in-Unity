using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    static readonly ObjectManager m_ObjectManager = new ObjectManager();

    public List<GameObject> bulletList = new List<GameObject>();
    Dictionary<string, List<GameObject>> listNameDic = new Dictionary<string, List<GameObject>>();
    Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();
    public static ObjectManager GetInstance
    {
        get
        {
            return m_ObjectManager;
        }
    }

    public ObjectManager()
    {
        listNameDic.Add("Bullet", bulletList);// maybe many object lists can be another list as well.
        prefabDic.Add("Bullet", Resources.Load("Prefab/Bullet", typeof(GameObject)) as GameObject);
    }

    public GameObject GetGameObject(string _objectName)
    {
        GameObject newObject = CheckList(listNameDic[_objectName]);
        if(newObject == null)
        {
            // need to create one
            newObject = GameObject.Instantiate(prefabDic[_objectName]);
            listNameDic[_objectName].Add(newObject);
            
        }

        else
        {
            newObject.SetActive(true);
        }

        if (_objectName == "Bullet")
        {
            newObject.GetComponent<Bullet>().Init(new Vector3(0, 0, 0));
        }

        return newObject;
    }
    public void RestoreGameObject(GameObject _gameObject)
    {
        _gameObject.SetActive(false);
    }
    public GameObject CheckList(List<GameObject> _list)
    {
        foreach(var item in _list)
        {
            if(item.activeSelf == false)
            {
                return item;
            }
        }

        return null;
    }


}
