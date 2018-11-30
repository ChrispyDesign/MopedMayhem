// Main Author - Afridi Rahim
//
// Date last worked on --/--/18

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class _TestHighScore : MonoBehaviour {

    public struct Score
    {
        public string name;
        public int value;
    }

    public Score[] scoreArray;
    public int highscoreCount = 5;

    public string currentDirectory;
    public string nameDirectory;

    public string scoreFileName = "MMHScore.txt";
    public string scoreTagName = "MMID.txt";

    private void Start()
    {
        //To double check, print the current directory
        currentDirectory = Application.dataPath;
        nameDirectory = Application.dataPath;

        //Call load scores function
        LoadScoresFromFile();
        LoadNameFromFile();
    }

    public void LoadScoresFromFile()
    {
        //Before reading from a file, check it exists. If it doesn't exist, log a error message and abort
        bool fileExists = File.Exists(currentDirectory + "/" + scoreFileName);
        if (fileExists)
        {
            Debug.Log("Found highscore file " + scoreFileName);
        }
        else
        {
            Debug.LogWarning("The file " + scoreFileName + " does not exist. No scores will be loaded.");
            SaveScoresToFile();
            return;
        }

        //Make a new array of default values. This ensure no old values stick around if we've loaded a
        //new scores file in the past
        scoreArray = new Score[highscoreCount];

        //Reads the file in
        StreamReader fileReader = new StreamReader(currentDirectory + "/" + scoreFileName);

        //A counter to make sure we don't go past the end of our scores
        int scoreCount = 0;

        //While loop that runs as long as there is data to be read and as long as we haven't reached the
        //end of our scores array
        while (fileReader.Peek() != 0 && scoreCount < scoreArray.Length)
        {
            //Read the line into a variable
            string fileLine = fileReader.ReadLine();

            //Try to parse the variable into an integer
            int readScore = -1;

            //Try to parse it
            bool didparse = int.TryParse(fileLine, out readScore);
            if (didparse)
            {
                scoreArray[scoreCount].value = readScore;
            }
            else
            {
                Debug.LogWarning("Invalid line in scores file at " + scoreCount + ", using default value.");
                scoreArray[scoreCount].value = 0;
            }

            //Increment counter
            scoreCount++;
        }
       
        //Close the stream
        fileReader.Close();
        Debug.Log("Highscores read from " + scoreFileName);
    }

    public void LoadNameFromFile()
    {
        //Before reading from a file, check it exists. If it doesn't exist, log a error message and abort
        bool fileExists = File.Exists(nameDirectory + "/" + scoreTagName);
        if (fileExists)
        {
            Debug.Log("Found highscore file " + scoreTagName);
        }
        else
        {
            Debug.LogWarning("The file " + scoreTagName + " does not exist. No scores will be loaded.");
            SaveNamesToFile();
            return;
        }

        //Make a new array of default values. This ensure no old values stick around if we've loaded a
        //new scores file in the past
        for (int i = 0; i < scoreArray.Length; i++)
        {
            scoreArray[i].name = string.Empty;
        }

        //Reads the file in
        StreamReader fileReader = new StreamReader(nameDirectory + "/" + scoreTagName);

        //A counter to make sure we don't go past the end of our scores
        int scoreCount = 0;

        while (fileReader.Peek() != 0 && scoreCount < scoreArray.Length)
        {
            //Read the line into a variable
            string fileLine = fileReader.ReadLine();

            bool didparse = true;
            //Try to parse it
            if (fileLine == string.Empty)
            {
                didparse = false;
            }

            if (didparse)
            {
                scoreArray[scoreCount].name = fileLine;
            }
            else
            {
                Debug.LogWarning("Invalid line in scores file at " + scoreCount + ", using default value.");
                scoreArray[scoreCount].name = "-";
            }

            //Increment counter
            scoreCount++;
        }
        //Close the stream
        fileReader.Close();
        Debug.Log("Highscores read from " + scoreFileName);
    }

    public void SaveScoresToFile()
    {
        //Create a StreamWriter for our filepath
        StreamWriter fileWriter = new StreamWriter(currentDirectory + "/" + scoreFileName);

        //Write the line to the file
        for (int i = 0; i < scoreArray.Length; i++)
        {
            fileWriter.WriteLine(scoreArray[i].value);
        }

        //Close the stream
        fileWriter.Close();

        //Write a log message
        Debug.Log("Highscores written to " + scoreFileName);
    }

    public void SaveNamesToFile()
    {
        //Create a StreamWriter for our filepath
        StreamWriter fileWriter = new StreamWriter(nameDirectory + "/" + scoreTagName);

        //Write the line to the file
        for (int i = 0; i < scoreArray.Length; i++)
        {
            fileWriter.WriteLine(scoreArray[i].name);
        }

        //Close the stream
        fileWriter.Close();

        //Write a log message
        Debug.Log("Highscores written to " + scoreTagName);
    }

    public void AddScore(int newScore, string newName)
    {
        //Find the index where the score will sit
        int desiredIndex = -1;

        for (int i = 0; i < scoreArray.Length; i++)
        {
            if (scoreArray[i].value < newScore || scoreArray[i].value == 0)
            {
                desiredIndex = i;
                break;
            }
        }

        //If no desired index was found then the score ins't high enough to get into the top 10
        //so we just abort
        if (desiredIndex < 0)
        {
            Debug.Log("Score of " + newScore + " is not high enough for high scores list.");
            return;
        }

        //Move all scores below the one added down a position
        for (int i = scoreArray.Length - 1; i > desiredIndex; i--)
        {
            scoreArray[i] = scoreArray[i - 1];
        }

        //Insert the new score in
        scoreArray[desiredIndex].value = newScore;
        scoreArray[desiredIndex].name = newName;
        Debug.Log("Score of " + newScore + " entered into highscores at position " + desiredIndex);
    }
}