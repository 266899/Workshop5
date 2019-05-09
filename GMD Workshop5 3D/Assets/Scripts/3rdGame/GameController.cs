using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] planets;
    private List<Sprite> gamePlanets = new List<Sprite>();
    private List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    public AudioSource sourceCorrect;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPlanet, secondGuessPlanet;
    private int correctGuesses;
    private int gameGuesses;
    public GameWon gameWon;
    public Timer timer;

    void Awake()
    {
      planets = Resources.LoadAll<Sprite>("Planets");
    }

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePlanets();
        Shuffle(gamePlanets);
        gameGuesses = gamePlanets.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for(int i=0; i<objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
        }
    }

    void AddGamePlanets()
    {
        int looper = btns.Count;
        int index = 0;

        for(int i = 0; i<looper; i++)
        {
            if(index == looper / 2) { 
                index = 0;
            }
            gamePlanets.Add(planets[index]);
            index++;
        }
    }

    void AddListeners()
    {
        foreach(Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            btns[firstGuessIndex].image.sprite = gamePlanets[firstGuessIndex];
            firstGuessPlanet = gamePlanets[firstGuessIndex].name;
            btns[firstGuessIndex].interactable = false;

        } else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            btns[secondGuessIndex].image.sprite = gamePlanets[secondGuessIndex];
            secondGuessPlanet = gamePlanets[secondGuessIndex].name;
            btns[secondGuessIndex].interactable = false;

            StartCoroutine(CheckIfThePlanetsMatch());
        }
    }

    IEnumerator CheckIfThePlanetsMatch()
    {
        if (firstGuessPlanet == secondGuessPlanet)
        {
            sourceCorrect.Play();
            yield return new WaitForSeconds(0.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            CorrectGuesses();
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
            btns[firstGuessIndex].interactable = true;
            btns[secondGuessIndex].interactable = true;
        }
        firstGuess = secondGuess = false;
    }

    void CorrectGuesses()
    {
        correctGuesses++;
        if (correctGuesses == gameGuesses)
        {
            gameWon.ShowVictoryText();
            timer.StopTimer();
        }

    }

    void Shuffle(List<Sprite> list)
    {
        for(int i=0; i<list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
