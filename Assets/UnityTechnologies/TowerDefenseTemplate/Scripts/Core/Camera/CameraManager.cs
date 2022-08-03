using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TowerDefense.UI.HUD;
using TowerDefense.Level;
using TowerDefense.Towers;
using TMPro;

/// <summary>
/// Handles use of multiple cameras during game and their respective player control settings 
/// </summary>
/// 
public class CameraManager : MonoBehaviour
{

    public PlayerMode currentPlayerMode;

    public Camera currentCamera;

    private PlayerManager[] allPlayersInLevel;
    private PlayerManager currentPlayer;

    public int timerLaserTower;

    public TextMeshProUGUI timerText;

    public void Awake()
    {
        allPlayersInLevel = FindObjectsOfType<PlayerManager>();
        currentPlayer = allPlayersInLevel.FirstOrDefault(player => player.playerMode == currentPlayerMode);
        UpdatePlayerMode(currentPlayerMode);
        

    }

    public void Start()
    {
        UpdatePlayerMode(currentPlayerMode);
    }


    public void Update()
    {
        
        //Update player mode if changing player mode
        if (currentPlayer.playerMode != currentPlayerMode)
        {
            UpdatePlayerMode(currentPlayerMode);
        }


        //Input keys during game play, temp
        if (Input.GetKeyDown(KeyCode.J))
        {
            currentPlayerMode = PlayerMode.MainMenu;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            currentPlayerMode = PlayerMode.FPS;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            currentPlayerMode = PlayerMode.ShootingTower;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LevelManager.instance.BuildingCompleted();
        }
            
            
    }


    public void UpdatePlayerMode(PlayerMode newPlayerMode)
    {

        //If its laser, only do it X seconds
        if (newPlayerMode == PlayerMode.ShootingTower)
        {
            StartCoroutine(LaserTowerTimer());
        }

        //Disable all player modes for safety, then enable the necessary one
        foreach (var player in allPlayersInLevel)
        {
            //player.playerCamera.enabled = false;
            player.gameObject.SetActive(false);
        }

        //enable player mode
        currentPlayer = allPlayersInLevel.FirstOrDefault(player => player.playerMode == newPlayerMode);
        currentPlayer.gameObject.SetActive(true);
        currentCamera = currentPlayer.playerCamera;



    }



    IEnumerator LaserTowerTimer()
    {
        timerText.gameObject.SetActive(true);
        float newTime = 0f;
        var initialTime = Time.time;
        var finalTime = initialTime + timerLaserTower;

        for(var num=0; num <= timerLaserTower; num++)
        {
            newTime = finalTime - initialTime;
            timerText.text = newTime.ToString();
            
            if(newTime <= 0)
            {
                newTime = 0;
                timerText.text = newTime.ToString();
                currentPlayerMode = PlayerMode.FPS;
                timerText.gameObject.SetActive(false);
                break;
            }
            
            yield return new WaitForEndOfFrame();
        }

        
    }








}










/// <summary>
/// Define the current type of camera and player mode
/// </summary>

public enum PlayerMode
{
    MainMenu,
    FPS,
    ShootingTower,

}

