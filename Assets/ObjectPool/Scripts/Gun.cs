using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    private ObjectManager m_objectManager;
    [SerializeField]
    public Text text;
    void Start()
    {
        m_objectManager = ObjectManager.GetInstance;
        GameObject newGameObject = GameObject.Instantiate(Resources.Load("Prefab/Bullet", typeof(GameObject)) as GameObject);
        m_objectManager.bulletList.Add(newGameObject);
        newGameObject.SetActive(false);
        newGameObject = GameObject.Instantiate(Resources.Load("Prefab/Bullet", typeof(GameObject)) as GameObject);
        m_objectManager.bulletList.Add(newGameObject);
        newGameObject.SetActive(false);
        newGameObject = GameObject.Instantiate(Resources.Load("Prefab/Bullet", typeof(GameObject)) as GameObject);
        m_objectManager.bulletList.Add(newGameObject);
        newGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //shoot
            Shoot();
        }

        text.text = m_objectManager.bulletList.Count.ToString();
    }

    public void Shoot()
    {
        //take out a bullet from object pool
        GameObject newBullet = m_objectManager.GetGameObject("Bullet");
        newBullet.GetComponent<Bullet>().Fire();
    }
}
