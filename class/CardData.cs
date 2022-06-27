using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CardData{
   
    public string firstName = "";
    public string lastName = "";
    public string cardID = "";
    public string cardType = "";
    public string validUntil = "";
    public int id = -1;
    public DateTime validUntilTM;
    public bool isValid = false;
    public CardData(){ }
    public CardData(string firstName, string lastName, string cardID, string cardType, string validUntil)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.cardID = cardID;
        this.cardType = cardType;
        this.validUntil = validUntil;
        this.validUntilTM = DateTime.Parse(validUntil);
    }

    void setValidUntilTM(string DateTimeStr) { 
    }
}
