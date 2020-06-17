using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData
{
    public string token;
    public int money;
    public int product;
    public int happiness;
    public int taxes;
    public float resMulti;
    public float timeMulti;
    public float taxMulti;
    public int admin;
    public int bux;
    public int dining;
    public int hr;
    public int it;
    public int konsult;
    public int lawyer;
    public int library;
    public int market;
    public int sale;
    public int sport;
    public int top;
    public int totalMoney;
    public int totalProduct;
    public int totalTax;

    public SessionData()
    {

    }
    public SessionData(string token, int money, int product, int happiness, int taxes, float resMulti, float timeMulti, float taxMulti, int admin, int bux, int dining, int hr, int it, int konsult, int lawyer, int library, int market, int sale, int sport, int top, int totalMoney, int totalProduct, int totalTax)
    {
        this.token = token;
        this.money = money;
        this.product = product;
        this.happiness = happiness;
        this.taxes = taxes;
        this.resMulti = resMulti;
        this.timeMulti = timeMulti;
        this.taxMulti = taxMulti;
        this.admin = admin;
        this.bux = bux;
        this.dining = dining;
        this.hr = hr;
        this.it = it;
        this.konsult = konsult;
        this.lawyer = lawyer;
        this.library = library;
        this.market = market;
        this.sale = sale;
        this.sport = sport;
        this.top = top;
        this.totalMoney = totalMoney;
        this.totalProduct = totalProduct;
        this.totalTax = totalTax;


    }
}
