using UnityEngine;
using TMPro;                    

public class WordInputManager : MonoBehaviour
{
    public Transform gridParent; // padre con le 6 righe

    private TMP_Text[,] gridLetters = new TMP_Text[6, 5];

    private int currentRow = 0;
    private int currentCol = 0;

    public WordChecker wordChecker;

    void Start()
    {
        Debug.Log(gridParent);
        Debug.Log("Rows count: " + gridParent.childCount);

        for (int r = 0; r < 6; r++)
        {
            Transform row = gridParent.GetChild(r);
            Debug.Log($"Row {r} panels: {row.childCount}");

            for (int c = 0; c < 5; c++)
            {
                Transform panel = row.GetChild(c);
                gridLetters[r, c] = panel.GetComponentInChildren<TMP_Text>();

                if (gridLetters[r, c] == null)
                    Debug.LogError($"NESSUN TMP_Text trovato in riga {r}, colonna {c}", panel.gameObject);
            }
        }
    }

    public void PressLetter(string letter)
    {
        if (currentCol >= 5) return;

        Debug.Log("Lettera digitata: " + letter);

        gridLetters[currentRow, currentCol].text = letter.ToUpper();
        currentCol++;
    }

    public void PressDelete()
    {
        if (currentCol == 0) return;

        currentCol--;
        gridLetters[currentRow, currentCol].text = "";
    }

    public void PressEnter()
    {
        if (currentCol < 5) return;

        string word = "";
        for (int i = 0; i < 5; i++)
            word += gridLetters[currentRow, i].text;

        wordChecker.CheckWord(word, currentRow);

        currentRow++;
        currentCol = 0;
    }

    public TMP_Text GetCell(int row, int col)
    {
        return gridLetters[row, col];
    }
}
