using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameState state;

    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Menu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
