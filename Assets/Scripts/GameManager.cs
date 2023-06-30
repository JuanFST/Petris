using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform blockPrefab;
    [SerializeField] private Transform blockHolder;
    [SerializeField] private Transform[] ArrayAnimales;

    [SerializeField] private TMPro.TextMeshProUGUI livesText;

    private Transform currentBlock = null;
    private Rigidbody2D currentRigidbody;

    private Vector2 blockStartPosition = new Vector2(0f, 4f);

    [SerializeField] private float blockSpeed = 10f;
    [SerializeField] private float blockSpeedIncrement = 0.5f;
    [SerializeField] private int blockDirection = 1;
    [SerializeField] private float xLimit = 5;


    //Variables de estado

    private int startingLives = 3;
    private int livesRemaining;
    private bool playing = true;
    private int previousAnimalIndex = 0;

    public GameOverScreen GameOverScreen;

    private void Start()
    {
        livesRemaining = startingLives;
        livesText.text = $"{livesRemaining}";
        SpawnNewBlock();
    }

    private void Update()
    {
        if (currentBlock && playing)
        {
            float moveAmount = Time.deltaTime * blockSpeed * blockDirection;
            currentBlock.position = currentBlock.position + new Vector3(moveAmount, 0, 0);

            if (Mathf.Abs(currentBlock.position.x) > xLimit)
            {
                currentBlock.position = new Vector3(blockDirection * xLimit, currentBlock.position.y, 0);
                blockDirection = -blockDirection;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentBlock = null;
                currentRigidbody.simulated = true;
                SpawnNewBlock();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

    }
    public void removeLife()
    {
        livesRemaining = Mathf.Max(livesRemaining - 1, 0);
        livesText.text = $"{livesRemaining}";

        if(livesRemaining == 0)
        {
            playing = false;
            gameOverScreen.GameOver();

        }
    }

    public void victoryScreen()
    {
        if (livesRemaining > 0)
        {
            playing = false;
        }
    }


    private void SpawnNewBlock()
    {
        var randomNumber = Random.Range((int)0, ArrayAnimales.Length-1);
        randomNumber = randomNumber == previousAnimalIndex ? Random.Range((int)0, ArrayAnimales.Length - 1) : randomNumber;
        blockPrefab = ArrayAnimales[randomNumber];
        Debug.Log(randomNumber);
        currentBlock = Instantiate(blockPrefab, blockHolder);
        currentBlock.position = blockStartPosition;
        currentRigidbody = currentBlock.GetComponent<Rigidbody2D>();

        blockSpeed = blockSpeed + blockSpeedIncrement;

        previousAnimalIndex = randomNumber;
    }
}
