using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SimpleStateEvent(ISimpleState state);

public interface ISimpleState
{
    SimpleStateEvent OnStateSwitch { get; set; }
    void Start();
    void Run();
    void Complete();
}

public class SimpleFSM : MonoBehaviour
{
    ISimpleState currentState;
    public SimpleFSM(ISimpleState firstState)
    {
        SwitchState(firstState);
    }

    private void Start()
    {
        SwitchState(new Asleep());
    }


    public void Update()
    {
        if (currentState != null)
        {
            currentState.Run();
        }
    }

    public void SwitchState(ISimpleState _newState)
    {
        //clean up
        if (currentState != null)
        {
            currentState.OnStateSwitch -= SwitchState;
            currentState.Complete();
        }

        //initialize
        _newState.Start();
        _newState.OnStateSwitch += SwitchState;

        //store current
        currentState = _newState;
    }
}

public class Asleep : ISimpleState
{
    public SimpleStateEvent OnStateSwitch { get; set; }

    public void Start()
    {

    }

    public void Run()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnStateSwitch(new Awake());
            Debug.Log("ASLEEP");
        }
    }

    public void Complete()
    {

    }
}

public class Awake : ISimpleState
{
    public SimpleStateEvent OnStateSwitch { get; set; }
    private float timer = 0;

    public void Start()
    {
        timer = 0;
    }

    public void Run()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            OnStateSwitch(new Asleep());
            Debug.Log("AWAKEKE");
        }
    }

    public void Complete()
    {

    }
}
