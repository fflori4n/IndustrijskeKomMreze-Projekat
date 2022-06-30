using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Access
{
    public string cardId = "0000";
    public string cardType = "OBICNA";
    public bool isEntry = true;
    public string name = "JOHN";
    public string surname = "DOE";

    public Access() { 
    }

    public string getEntryStr()
    {
        if (isEntry)
        {
            return "ULAZ";
        }
        else {
            return "IZLAZ";
        }
    }
}
