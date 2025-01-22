using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
    public GameObject opponentPanelPrefab;
    public Transform opponentsContainer;
    public TMP_Dropdown opponentsDropdown;
    public TMP_InputField mapSizeInput;
    public Button startButton;

    private List<GameObject> opponentPanels = new List<GameObject>();
    private List<Color> availableColors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow, Color.magenta, Color.cyan };
    private HashSet<string> opponentNames = new HashSet<string>();

    void Start()
    {
        opponentsDropdown.onValueChanged.AddListener(OnOpponentsDropdownValueChanged);
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    void OnOpponentsDropdownValueChanged(int value)
    {
        int currentOpponentsCount = opponentPanels.Count;
        int targetOpponentsCount = value + 1; // +1 because the dropdown starts from 0

        if (targetOpponentsCount > currentOpponentsCount)
        {
            for (int i = currentOpponentsCount; i < targetOpponentsCount; i++)
            {
                AddOpponentPanel();
            }
        }
        else if (targetOpponentsCount < currentOpponentsCount)
        {
            for (int i = currentOpponentsCount - 1; i >= targetOpponentsCount; i--)
            {
                RemoveOpponentPanel(opponentPanels[i]);
            }
        }
    }

    void AddOpponentPanel()
    {
        GameObject newOpponentPanel = Instantiate(opponentPanelPrefab, opponentsContainer);
        opponentPanels.Add(newOpponentPanel);

        TMP_InputField nameInput = newOpponentPanel.GetComponentInChildren<TMP_InputField>();
        nameInput.onEndEdit.AddListener(delegate { OnOpponentNameChanged(nameInput); });

        Button colorButton = newOpponentPanel.GetComponentInChildren<Button>();
        colorButton.onClick.AddListener(delegate { OnColorButtonClicked(colorButton); });

        SetRandomColor(colorButton);
    }

    void RemoveOpponentPanel(GameObject opponentPanel)
    {
        opponentPanels.Remove(opponentPanel);
        Destroy(opponentPanel);
    }

    void OnOpponentNameChanged(TMP_InputField nameInput)
    {
        string newName = nameInput.text;
        if (opponentNames.Contains(newName))
        {
            nameInput.image.color = Color.red;
        }
        else
        {
            nameInput.image.color = Color.white;
            opponentNames.Add(newName);
        }
    }

    void OnColorButtonClicked(Button colorButton)
    {
        Color newColor = availableColors[Random.Range(0, availableColors.Count)];
        colorButton.image.color = newColor;
        availableColors.Remove(newColor);
    }

    void SetRandomColor(Button colorButton)
    {
        if (availableColors.Count > 0)
        {
            Color newColor = availableColors[Random.Range(0, availableColors.Count)];
            colorButton.image.color = newColor;
            availableColors.Remove(newColor);
        }
    }

    void OnStartButtonClicked()
    {
        bool canStart = true;
        opponentNames.Clear(); // Clear the set before checking
        foreach (GameObject opponentPanel in opponentPanels)
        {
            TMP_InputField nameInput = opponentPanel.GetComponentInChildren<TMP_InputField>();
            if (opponentNames.Contains(nameInput.text))
            {
                canStart = false;
                nameInput.image.color = Color.red;
            }
            else
            {
                opponentNames.Add(nameInput.text);
            }
        }

        if (canStart)
        {
            Debug.Log("Game can start!");
        }
        else
        {
            Debug.Log("Game cannot start due to duplicate names!");
        }
    }
}
