using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ILiveStateDelegate(ILiveState _state);

public interface Istate
{

    void Start();

    void Run();

    void Complete();
}

public class FSM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
