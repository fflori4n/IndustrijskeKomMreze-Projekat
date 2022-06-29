using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Access
{
    public string cardId;
    public string cardType;
    public bool isEntry;
    public string name;
    public string surname;

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
