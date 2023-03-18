using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarEnemy : MonoBehaviour
{
    public Transform bar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector2(size, 1f);
    }
}
