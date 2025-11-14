using UnityEngine;

public class WordChecker : MonoBehaviour
{
    public string secretWord = "CANTO";
    public WordInputManager manager;

    public void CheckWord(string guess, int row)
    {
        guess = guess.ToUpper();
        secretWord = secretWord.ToUpper();

        for (int i = 0; i < 5; i++)
        {
            string letter = guess[i].ToString();

            var cell = manager.GetCell(row, i); 
            var img = cell.transform.parent.GetComponent<UnityEngine.UI.Image>();

            if (letter == secretWord[i].ToString())
            {
                img.color = Color.green;
            }
            else if (secretWord.Contains(letter))
            {
                img.color = Color.yellow;
            }
            else
            {
                img.color = Color.gray;
            }
        }
    }
}
