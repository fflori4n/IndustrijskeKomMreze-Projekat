using Npgsql;
using ProjektniZadatak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PostgreSQL
{
    public const string connectionCredStr = $"Host = localhost; Port = 5432; Username = postgres; Password = foska000; Database = postgres";
    public static int executeNonQuery(string naredba)
    {
        NpgsqlConnection conn = new NpgsqlConnection(connectionCredStr);
        try
        {
            conn.Open();

            //Form1.print2list("Konekcija otvorena...");
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);
            int res = command.ExecuteNonQuery();
            Form1.print2list(res.ToString());
        }
        catch (Exception ex)
        {
            Form1.print2list(ex.Message);
            return -1;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return 0;
    }
    public static void addUserToWhiteList(String cardId, String cardType, string name, string surname, string validUntil)
    {
        string naredba = $"INSERT INTO korisnici(\"card_id\",\"first_name\",\"last_name\",\"card_type\",\"valid_until\") VALUES('{cardId.ToUpper()}','{name.ToUpper()}','{surname.ToUpper()}','{cardType.ToUpper()}','{validUntil}');";
        int res = PostgreSQL.executeNonQuery(naredba);
        if (res == 0)
        {
            Form1.print2list("[ OK ] User added");
        }
    }
    public static bool removeUserByCardID(string cardID)
    {
        string naredba = $"delete from korisnici where card_id = '{cardID}'";
     
        int res = PostgreSQL.executeNonQuery(naredba);
        if (res == 0)
        {
            // print2list($"[ OK ] Deleted {cardID}");
            return true;
        }
        else
        {
            //print2list("[ ER ] Deleted {cardID}");
            return false;
        }
    }
    public static void changeWhitelistData(String firstName, String lastName, CardData card)
    {
        string naredba = $"Update korisnici SET first_name='{card.firstName.ToUpper()}', last_name='{card.lastName.ToUpper()}', card_type='{card.cardType.ToUpper()}', card_id='{card.cardID.ToUpper()}', valid_until='{card.validUntil}' WHERE first_name='{firstName.ToUpper()}' and last_name='{lastName.ToUpper()}'";
  

        int res = PostgreSQL.executeNonQuery(naredba);
        if (res == 0)
        {
            Form1.print2list("[ OK ] Change user");
        }
        else
        {
            Form1.print2list("[ ER ] Change user");
        }
    }
    public static void logAccess(Access newAccess)
    {
        string naredba = $"INSERT INTO evidencija(\"card_id\",\"card_type\",\"is_entry\",\"name\",\"surname\",\"time\",\"date\") VALUES ('{newAccess.cardId.ToUpper()}','{newAccess.cardType.ToUpper()}',{newAccess.isEntry},'{newAccess.name.ToUpper()}','{newAccess.surname.ToUpper()}','{DateTime.Now.ToShortTimeString()}','{DateTime.Now.ToShortDateString()}')";
       

        int res = PostgreSQL.executeNonQuery(naredba);
        if (res == 0)
        {
            Form1.print2list("[ OK ] Event logged");
        }
    }
    public static bool isUserInWhiteList(string firstName, string lastName)
    {
        ///SELECT* from korisnici Where first_name = 'hllo' AND last_name = 'world'
        //ListView.Clear();
        NpgsqlConnection conn = new NpgsqlConnection(connectionCredStr);
        try
        {
            // regularni kod
            conn.Open();
            string naredba = $"SELECT id from korisnici Where first_name = '{firstName.ToUpper()}' AND last_name='{lastName.ToUpper()}'";
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

            NpgsqlDataReader reader = command.ExecuteReader();
            List<int> ids = new List<int>();
            if (reader.Read())
            {
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            // obrada greske
            //print2list(ex.Message);
            return false;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    public static int isUserInside(string cardId) {
        ///select is_entry from evidencija where card_id='1234'
        List<CardData> cardDatas = new List<CardData>();
        NpgsqlConnection conn = new NpgsqlConnection(connectionCredStr);
        string naredba = $"select is_entry from evidencija where card_id='{cardId}'";

        try
        {
            // regularni kod
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            bool valInDb = false;
            while (reader.Read())
            {
                valInDb = reader.GetBoolean(0);
            }

            if (valInDb)
            {
                return 0;
            }
            else { 
                return 1;   
            }
            //return cardDatas;

        }
        catch (Exception ex)
        {
            // obrada greske
            //print2list(ex.Message);
            //return cardDatas;
            return -1;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public static List<CardData> searchBySingleParam(string key, string value)
    {
        List<CardData> cardDatas = new List<CardData>();
        NpgsqlConnection conn = new NpgsqlConnection(connectionCredStr);
        string naredba = $"select id,card_id,first_name, last_name,card_type, valid_until from korisnici where {key} like '%{value}%'";

        try
        {
            // regularni kod
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CardData newCard = new CardData();

                newCard.id = reader.GetInt32(0);
                newCard.cardID = reader.GetString(1);
                newCard.firstName = reader.GetString(2);
                newCard.lastName = reader.GetString(3);
                newCard.cardType = reader.GetString(4);
                newCard.validUntil = reader.GetString(5);
                cardDatas.Add(newCard);
                // print2list($"{newCard.id.ToString().PadLeft(10)} | {newCard.cardID.PadLeft(15)} | {newCard.firstName.PadLeft(15)} | {newCard.lastName.PadLeft(15)} | {newCard.cardType.PadLeft(15)} | {newCard.validUntil.PadLeft(30)}");
            }
            return cardDatas;

        }
        catch (Exception ex)
        {
            // obrada greske
            //print2list(ex.Message);
            return cardDatas;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }
    public static CardData checkCard(string cardID)
    {
        string checkCardSQLCmdStr = $"select first_name, last_name, card_type, valid_until from korisnici where card_id='{cardID.ToUpper()}'";
        
        NpgsqlConnection conn = new NpgsqlConnection(connectionCredStr);

        try
        {
            conn.Open();
           // Form1.print2list("Konekcija otvorena...");
            string naredba = checkCardSQLCmdStr;
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CardData card = new CardData();
                card.firstName = reader.GetString(0).ToUpper();
                card.lastName = reader.GetString(1).ToUpper();
                card.cardType = reader.GetString(2).ToUpper();
                card.validUntil = reader.GetString(3);
                card.validUntilTM = DateTime.Parse(card.validUntil);
                //DateTime now = DateTime.Now;
                if (card.validUntilTM.CompareTo(DateTime.Now) < 0)
                {
                    card.isValid = false;
                }
                else
                {
                    card.isValid = true;
                }

                //Form1.print2list($"{card.firstName.PadLeft(10)} | {card.lastName.PadLeft(15)} | {card.cardType.PadLeft(15)} | {card.validUntil.PadLeft(15)}");
                return card;
            }
        }
        catch (Exception ex)
        {
            Form1.print2list(ex.Message);
            return new CardData();
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return new CardData();
    }
    public static void showLog()
    {
        string naredba = "select is_entry, time, date, card_id, card_type, name, surname from evidencija";

        NpgsqlConnection conn = new NpgsqlConnection(connectionCredStr);
        try
        {
            // regularni kod
            conn.Open();
            Form1.print2list("Konekcija otvorena...");
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bool isEntry = reader.GetBoolean(0);
                string time = reader.GetString(1).ToUpper().PadLeft(8);
                string date = reader.GetString(2).ToUpper().PadLeft(10);
                string cardId = reader.GetString(3).ToUpper().PadLeft(5);
                string cardType = reader.GetString(4).ToUpper().PadLeft(10);
                string name = reader.GetString(5).ToUpper();
                string surname = reader.GetString(6).ToUpper();
                string entry = "Ulaz".PadLeft("Ručna dozvola".Length);
                if (!isEntry)
                {
                    entry = "Izlaz".PadLeft("Ručna dozvola".Length);
                }
                //Form1.print2list($"{entry} | {time} | {date} | {cardId} | {cardType} | {(name + " " + surname)}");
                if ((name).CompareTo("DOZVOLA PUTEM APLIKACIJE") == 0) {
                    entry = "Ručna dozvola";
                }//{entry}
                Form1.print2list($"{entry}|{time}|{date}|{cardId}|{cardType}| {(name + " " + surname)}");
            }

        }
        catch (Exception ex)
        {
            // obrada greske
            Form1.print2list(ex.Message);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

}

