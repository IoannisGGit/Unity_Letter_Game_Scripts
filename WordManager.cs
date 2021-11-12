using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{

    private TMP_Text textComponent;
    private static string currentLetter;
    private static bool isCollected;
    public GameLogic gameLogicScript;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        isCollected = false;
        gameLogicScript = GameObject.Find("Game Manager").GetComponent<GameLogic>();
        
    }

  

    private void Update()
    {
        //if a letter is collected check for matches with the word
        if (isCollected)
        {
            checkMatch();
            if (checkWordFound())
            {
                textComponent.text = WordGenerator.generateWord();
                gameLogicScript.wrongLetterNum -= 1;

            }
        }
        
    }

    public void checkMatch()
    {
        TMP_TextInfo textInfo = textComponent.textInfo;
        int characterCount = textInfo.characterCount;
        for(int i=0; i<characterCount; i++)
        {
            if(textInfo.characterInfo[i].character == stringToChar(currentLetter))
            {
                colorALetter(i);
                return;
            }
        }

        gameLogicScript.wrongLetterNum += 1;
        isCollected = false;
    }

    public bool checkWordFound()
    {
        TMP_TextInfo textInfo = textComponent.textInfo;
        int characterCount = textInfo.characterCount;
        for (int i = 0; i < characterCount; i++)
        {
            if (!ischarGreen(i)) return false;

        }
        return true;
        
    }
  

    //this function is built on the textmeshpro/examples/VertexColorCycler
    void colorALetter(int characterIndex)
    {
        Color32[] newVertexColors;
        Color32 c0 = textComponent.color;
        
        TMP_TextInfo textInfo = textComponent.textInfo;
        // Get the index of the material used by the current character.
        int materialIndex = textInfo.characterInfo[characterIndex].materialReferenceIndex;

        // Get the vertex colors of the mesh used by this text element (character or sprite).
        newVertexColors = textInfo.meshInfo[materialIndex].colors32;

        // Get the index of the first vertex used by this text element.
        int vertexIndex = textInfo.characterInfo[characterIndex].vertexIndex;

        // Only change the vertex color if the text element is visible.
        if (textInfo.characterInfo[characterIndex].isVisible)
        {
            
            c0 = new Color32((byte)0, (byte)255, (byte)0, 255);

            newVertexColors[vertexIndex + 0] = c0;
            newVertexColors[vertexIndex + 1] = c0;
            newVertexColors[vertexIndex + 2] = c0;
            newVertexColors[vertexIndex + 3] = c0;

            // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
            textComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

        }
    }
    //check if a character has green color
    bool ischarGreen(int characterIndex)
    {
        Color32[] vertexColors;
        TMP_TextInfo textInfo = textComponent.textInfo;
        // Get the index of the material used by the current character.
        int materialIndex = textInfo.characterInfo[characterIndex].materialReferenceIndex;

        // Get the vertex colors of the mesh used by this text element (character or sprite).
        vertexColors = textInfo.meshInfo[materialIndex].colors32;

        // Get the index of the first vertex used by this text element.
        int vertexIndex = textInfo.characterInfo[characterIndex].vertexIndex;

         return isColorGreen(vertexColors[vertexIndex + 0]);

    }

    //helper functions
    private char stringToChar(string toConvert)
    {
        char[] mychars = toConvert.ToCharArray();
        return mychars[0];
    }

    public static void letterCollected(string letter)
    {
        currentLetter = letter;
        isCollected = true;

    }

    bool isColorGreen(Color32 col1)
    {
        Color32 greenC = new Color(0, 1, 0, 1);
        if (col1.Equals(greenC)) return true;
        return false;
    }
}


    