using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //practice coroutine
    bool flyTimer = false;
    float destroyTimer = 0.0f;

    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (flyTimer)
        {
            StartCoroutine("Fly");
            flyTimer = false;
        }
        destroyTimer += Time.deltaTime;
        if (destroyTimer > 3.0f)
        {
            destroyTimer = 0.0f;
            ObjectManager.GetInstance.RestoreGameObject(this.gameObject);
        }
    }

    public void Init(Vector3 _position)
    {
        this.gameObject.transform.position = _position;

    }

    public void Fire()
    {
        StartCoroutine("Fly");
        destroyTimer = 0.0f;
    }

    IEnumerator Fly()
    {
        yield return new WaitForFixedUpdate();
        this.gameObject.transform.position += new Vector3(1.0f * Time.fixedDeltaTime, 0, 0);
        flyTimer = true;
    }

}
