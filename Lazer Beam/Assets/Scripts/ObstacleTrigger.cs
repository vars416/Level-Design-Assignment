using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleTrigger : MonoBehaviour
{

    public GameObject Trigger;
    public GameObject Obstacle;
    private bool IsItHappening;
    public float Timer;
    private float decreasing;
    // Start is called before the first frame update
    void Start()
    {
        IsItHappening = false;
        decreasing = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        TurningOff();
        TurningOn();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        if (Trigger.GetComponent<Collider>() == other)
        {
            IsItHappening = true;
            print(IsItHappening);
        }
    }
    void TurningOff ()
    {
        if (IsItHappening == true)
        {
            if (decreasing > 0f)
            {
                decreasing -= Time.deltaTime;
                //print(decreasing);
            }
            Obstacle.gameObject.SetActive(false);
        }
    }

    void TurningOn ()
    {
        if (decreasing <= 0f)
        {
            Obstacle.gameObject.SetActive(true);
            IsItHappening = false;
            print(IsItHappening);
            decreasing = Timer;
        }
    }
}
