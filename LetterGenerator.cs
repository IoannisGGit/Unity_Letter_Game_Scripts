using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGenerator : MonoBehaviour
{
    //TODO:CHECK THE PROBABILITY OF LETTERS OCCURING IN THE ENGLISH APHABET
    public static string[] letters = 
        {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
        


    public static string generateLetter()
    {
        int letterIndex = (int)Random.Range(0, letters.Length);
        string letter = letterFromIndex(letterIndex);
        return letter;
    }

    static string letterFromIndex(int i)
    {
        return letters[i];
    }
}
