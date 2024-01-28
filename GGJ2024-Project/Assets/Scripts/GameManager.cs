using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerControl Timer;
    public AcceptingObject placed;

    public int action = 0;

    [SerializeField] private int TotalAction;
    public static GameManager Instance;


    // Start is called before the first frame update



    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((action  == TotalAction) && Timer.remainingDuration > 0 )
        {
            Debug.Log("you win !! ");
        }
        else if ( (action < TotalAction) && Timer.remainingDuration <= 0 )
        {
            Debug.Log("You loose ! ");
        }
    }
}
