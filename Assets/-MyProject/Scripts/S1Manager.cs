using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

//check if fire is put out
//check timer
//display game over/pass
public class S1Manager : MonoBehaviour
{
    public GameObject _CDText;

    public ParticleSystem _fire;
    public CountdownTimer currentTime;
    public PlayerHealth playerHealth;
    public GameObject player; //XR origin

    public AudioSource source;
    public ParticleSystem water;

    private string _excelFileName;
    private string result;

    private bool gameEnded = true;

    public GameObject winLoseScreen;
    public TextMeshProUGUI screenText;
    public Image imageComponent;

    public GameObject WristUI;


    public GameObject enemy;
   



    void Start()
    {
        currentTime = _CDText.GetComponent<CountdownTimer>();
        playerHealth = player.GetComponent<PlayerHealth>();
        water.Pause();
        winLoseScreen.SetActive(false);
        WristUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy");
        if(currentTime.currentTime == 0f || (currentTime.currentTime == 0f && _fire.isPlaying) || playerHealth.currentHealth <=0 )
        {
            Debug.Log("Game Over!");
            result = "Fail";
            WristUI.SetActive(false);
            winLoseScreen.SetActive(true);
              _CDText.SetActive(false);
            screenText.text = "Game Over";
            imageComponent.color = Color.gray;
            // _gameOverScreen.SetActive(true);
        }

        if(currentTime.currentTime != 0f && !_fire.isPlaying && gameEnded && enemy == null )
        {
            Debug.Log("Level Pass");

            WristUI.SetActive(false);
            winLoseScreen.SetActive(true);
            screenText.text = "Congratulations!";
            imageComponent.color = Color.green;
            _CDText.SetActive(false);
            result = "Pass";
            //Time.timeScale = 0f;
           // float timeTaken = 100f - currentTime.currentTime;
            //Debug.Log(Mathf.FloorToInt(timeTaken) + " seconds");
            gameEnded = false;
            //  _levelPassScreen.SetActive(true); //Display Game Pass Canvas
        }

        if (currentTime.currentTime == currentTime.startingTime)
        {
            Time.timeScale = 1f;
        }
    }



    public void exportResult()
    {

        //Create excel file with date
        DateTime dt = DateTime.Now;
        _excelFileName = dt.ToString("yyyy-MM-dd") + ".xls";

        //Path to create excel file
        string path = Application.dataPath + "/Output/";

        //Check if path exists
        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        //Calcute time taken to complete level
        float secondsTaken = 180f - currentTime.currentTime;
        


        //==================================================================
        if (System.IO.File.Exists(path + _excelFileName))
        {
            Debug.Log("File Exist: [" + path + "]");

            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path + _excelFileName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = book.GetSheetAt(0);

            IRow hRow = sheet.GetRow(0);

            IRow row = sheet.CreateRow(sheet.LastRowNum);

            // Get the current date and time
            DateTime now = DateTime.Now;

            row.CreateCell(0).SetCellValue(now.ToString()); //insert date and time
            row.CreateCell(2).SetCellValue(result); //insert whether player pass or fail
            row.CreateCell(3).SetCellValue(secondsTaken.ToString() + " seconds"); //insert time taken

            sheet.CreateRow(sheet.LastRowNum + 1).CreateCell(0).SetCellValue("-END-");

            //==============================================================
            using (FileStream file = new FileStream(@path + _excelFileName, FileMode.Open, FileAccess.Write))
            {
                book.Write(file);
                file.Close();
            }

        }//end if
        else
        {
            Debug.Log("File DOES NOT Exist");

            IWorkbook book = new HSSFWorkbook();

            ISheet sheet = book.CreateSheet("Batch" + dt.ToString("yyyy-MM-dd"));


            sheet.CreateRow(0).CreateCell(0).SetCellValue("DateTime");

            //*
            sheet.GetRow(0).CreateCell(2).SetCellValue("Pass/Fail");
            sheet.GetRow(0).CreateCell(3).SetCellValue("Time taken"); // how long player took to complete the level
            //******/

            //insert records after columns created
            for (int i = 1; i <= 1; i++)
            {
                IRow row = sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(DateTime.Now.ToString());
                row.CreateCell(2).SetCellValue(result);
                row.CreateCell(3).SetCellValue(secondsTaken.ToString() + " seconds");
            }


            sheet.CreateRow(sheet.LastRowNum + 1).CreateCell(0).SetCellValue("-END-");
            Debug.Log("Last ROW: " + sheet.LastRowNum);

            //save
            FileStream xfile = File.Create(path + _excelFileName);
            book.Write(xfile);
            xfile.Close();
        }//end else
      
    }


    
}
