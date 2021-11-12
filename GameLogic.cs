using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private int _wrongLettersNum = 0;
    ColorXSprites xSprites;
    public enum State
    {
        GamePlaying,
        GameOver
    }
    public State currentState;

    // Start is called before the first frame update
    void Start()
    {
        xSprites = GameObject.Find("X markers").GetComponent<ColorXSprites>();
        currentState = State.GamePlaying;
        xSprites.resetColors();
        _wrongLettersNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.GamePlaying:
                switch (_wrongLettersNum)
                {
                    case 1:
                        xSprites.setColorRed(_wrongLettersNum);
                        break;
                    case 2:
                        xSprites.setColorRed(_wrongLettersNum);
                        break;
                    case 3:
                        xSprites.setColorRed(_wrongLettersNum);
                        currentState = State.GameOver;
                        break;
                }
                break;
 
            case State.GameOver:
                SceneManager.LoadScene(2);
                break;
        }
    }

    //get and set from chapter 8 book learning c# by developing games in Unity
    public int wrongLetterNum
    {
        get { return _wrongLettersNum; }
        set
        {
            _wrongLettersNum = value;
         
        }
    }

}
