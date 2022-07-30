using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    }


    public void UpdatePlayerMode(PlayerMode newPlayerMode)
    {

        
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
