using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GameStatSend(string json);

    // Then create a function that is going to trigger
    // the imported function from our JSLib.

    [SerializeField]
    private string url;
    [SerializeField]
    public List<string> roomLabels;
    public  int money;
    private int product;
    private int happiness;
    private int taxes;
    private float resMulti;
    private float timeMulti;
    private float taxMulti;
    private string token;
    [SerializeField]
    private Score score;
    [SerializeField]
    private TimeControl time;
    [SerializeField]
    private GameObject overPanell;
    [SerializeField]
    private Text totalText;
    [SerializeField]
    private Text totalRoomsText;
    [SerializeField]
    private Text totalScoreText;

    public int totalMoney = 0;
    public int totalProduct = 0;
    public int totalTax = 0;

    private int admin = 0;
    private int bux = 0;
    private int dining = 0;
    private int hr = 0;
    private int it = 0;
    private int konsult = 0;
    private int lawyer = 0;
    private int library = 0;
    private int market = 0;
    private int sale = 0;
    private int sport = 0;
    private int top = 0;

    [SerializeField]
    private Text moneyScore;
    [SerializeField]
    private Text productScore;
    [SerializeField]
    private Text moneyOverall;
    [SerializeField]
    private Text productOverall;
    [SerializeField]
    private Text taxOverall;
    [SerializeField]
    private Text itCount;
    [SerializeField]
    private Text saleCount;
    [SerializeField]
    private Text topCount;
    [SerializeField]
    private Text diningCount;
    [SerializeField]
    private Text sportCount;
    [SerializeField]
    private Text libraryCount;
    [SerializeField]
    private Text buxCount;
    [SerializeField]
    private Text hrCount;
    [SerializeField]
    private Text marketCount;
    [SerializeField]
    private Text adminCount;
    [SerializeField]
    private Text lawyaerCount;
    [SerializeField]
    private Text konsultCount;
    [SerializeField]
    private Text timeAlive;
    [SerializeField]
    private Text gameOverText;
    [SerializeField]
    private TimeLine timeLine;
    private string aToken;
    



    public void PutData()
    {
        
        time.Pause();
        money = score.money;
        product = score.product;
        happiness = score.happiness;
        taxes = score.moneyTax;
        resMulti = score.globalResourceMulti;
        timeMulti = score.globalTimeMulti;
        taxMulti = score.globalTaxMulti;
        Stat();
        Display();
        overPanell.SetActive(true);
        if(Mathf.RoundToInt(timeLine.currrentTime / 10) >=372)
        {
            gameOverText.text = "Твой бизнес дожил до наших дней, но ты сможешь ещё круче. Попробуй ;)";
        }
        else
        {
            gameOverText.text = "Тебе чуть-чуть не хватило для победы :( Сыграй ещё раз — успех совсем рядом!";
        }
        timeAlive.text = "Вы продержались " + Mathf.RoundToInt(timeLine.currrentTime / 10).ToString() + " месяцев";
       
        SessionData data = new SessionData(token, money, product, happiness, taxes, resMulti, timeMulti, taxMulti, admin, bux, dining, hr, it, konsult, lawyer, library, market, sale, sport, top, totalMoney, totalProduct, totalTax);
        
        var json = JsonUtility.ToJson(data);
        Debug.Log(json);
        GameStatSend(json);
    }
    public void SaveToken(string id)
    {
        token = id;
        Debug.Log("token recieved: " + token);   
        
    }
    private IEnumerator Send(string json)
    {
       
        UnityWebRequest www = UnityWebRequest.Post(url, json);       
        yield return www.SendWebRequest();

    }
    public void SaveAcessToken(string accessToken)
    {
        token = accessToken;
        Debug.Log("access token recieved: " + aToken);
    } 
    

    public void Stat()
    {
        for (int i = 0; i < 25; i++)
        {
            if (roomLabels[i] == "Сисадмины")
            {
                admin++;
            }
            else if (roomLabels[i] == "Бухгалетрия")
            {
                bux++;
            }
            else if (roomLabels[i] == "Столовая")
            {
                dining++;
            }
            else if (roomLabels[i] == "HR")
            {
                hr++;
            }
            else if (roomLabels[i] == "Разработчики")
            {
                it++;
            }
            else if (roomLabels[i] == "Консультанты")
            {
                konsult++;
            }
            else if (roomLabels[i] == "Юристы")
            {
                lawyer++;
            }
            else if (roomLabels[i] == "Библиотека")
            {
                library++;
            }
            else if (roomLabels[i] == "Маркетологи")
            {
                market++;
            }
            else if (roomLabels[i] == "Продавцы")
            {
                sale++;
            }
            else if (roomLabels[i] == "Спортзал")
            {
                sport++;
            }
            else if (roomLabels[i] == "ТОПЫ")
            {
                top++;
            }

        }
    }
    private void Display()
    {
        moneyScore.text = money.ToString();
        productScore.text = product.ToString();
        moneyOverall.text = totalMoney.ToString();
        productOverall.text = totalProduct.ToString();
        taxOverall.text = totalTax.ToString();
        itCount.text = it.ToString();
        saleCount.text = sale.ToString();
        topCount.text = top.ToString();
        diningCount.text = dining.ToString();
        sportCount.text = sport.ToString();
        libraryCount.text = library.ToString();
        buxCount.text = bux.ToString();
        hrCount.text = hr.ToString();
        marketCount.text = market.ToString();
        adminCount.text = admin.ToString();
        lawyaerCount.text = lawyer.ToString();
        konsultCount.text = konsult.ToString();
        /*
        string buildRooms = "Вы построили: " + admin.ToString() + " комнат Сисадминов, " + bux.ToString() + " комнат Бухгалетрии, " + dining.ToString() + " Столовых, " + hr.ToString() + " комнат HR, "
             + it.ToString() + " комнат Разработчиков, " + konsult.ToString() + " комнат Консультантов, " + lawyer.ToString() + " комнат Юристов, " + library.ToString() + " Библиотек, "
              + market.ToString() + " комнат Маркетологов, " + sale.ToString() + " комнат Продажников, " + sport.ToString() + " Спортзалов, " + top.ToString() + " комнат ТОПов";
        string economics = "Всего Вы произвели " + totalProduct + " продукта"  + " и заработали " + totalMoney + " контуриков, " + "выплачено налогов " + totalTax + " контуриков";
        string totalScore = "На балансе: " + money + " контуриков"+ " и " + product +  " продукта";
        totalRoomsText.text = buildRooms;
        totalText.text = economics;
        totalScoreText.text = totalScore;
        */
    }


}
