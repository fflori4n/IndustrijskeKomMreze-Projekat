using Npgsql;
using ProjektniZadatak.forms;

namespace ProjektniZadatak;

public partial class Form1 : Form
{
    public user activeUser = new user("", "", 0);
   // CardData newCard = new CardData();
    public Form1()
    {
        InitializeComponent();
        ListView.Columns.RemoveAt(0);
        //ListView.Columns.RemoveAt(1);
    }

    private void print2list(string poruka)
    {
        if (ListView.InvokeRequired)
        {
            ListView.Invoke((MethodInvoker)(() =>
            {
                ListView.Items.Add("InvokeRequired");
                ListView.Items.Add(poruka);
            }));
        }
        else
        {
            ListView.Items.Add(poruka);
        }
    }
    private int GetDeterministicHashCode(string str)    /// from: https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }
    private void exit()
    {
        activeUser.name = "dirty fix";
        System.Windows.Forms.Application.ExitThread();
    }

    private bool checkAccess(string cardID) {
        CardData checkedCard = checkCard(cardID);
        if (checkedCard.isValid) {
            if (checkedCard.cardType.CompareTo("OBIČNA") == 0)
            {
                if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 15)
                {
                    print2list($"DOZVOLJENO: {cardID}");
                    return true;
                }
                else {
                    print2list($"ZABRANJENO: {cardID} -- Pokušaj van radnog vremena");
                    return false;
                }
            }
            else { 
                return true;
            }
        }
        print2list($"ZABRANJENO: {cardID} -- Istekla kartica");
        return false;
    }
    private CardData checkCard(string cardID) {
        /// select first_name, last_name, card_type, valid_until from korisnici where card_id='00'
        /// 
        NpgsqlConnection conn = new NpgsqlConnection($"Host = localhost; Port = 5432; Username = postgres; Password = foska000; Database = postgres");
        
        try
        {
            conn.Open();
            print2list("Konekcija otvorena...");
            string naredba = $"select first_name, last_name, card_type, valid_until from korisnici where card_id='{cardID.ToUpper()}'";
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
                    //print2list("card expired");
                    card.isValid = false;
                }
                else {
                    //print2list("card valid");
                    card.isValid = true;
                }
               
                print2list($"{card.firstName.PadLeft(10)} | {card.lastName.PadLeft(15)} | {card.cardType.PadLeft(15)} | {card.validUntil.PadLeft(15)}");
                return card;
            }
        }
        catch (Exception ex)
        {
            print2list(ex.Message);
            return new CardData();
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return new CardData();
    }
    private void login()
    {

        string passHash = "";
        forms.FrmLogin login;
        login = new forms.FrmLogin("change");
        if (activeUser.name.Equals(""))
        {
            login = new forms.FrmLogin("login");
            DialogResult res = login.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                exit();
            }
            if (res == DialogResult.OK)
            {
                // pokusacemo da procitamo korisnika iz baze i vidimo koji nivo pristupa ima
                NpgsqlConnection conn = new NpgsqlConnection($"Host = localhost; Port = 5432; Username = postgres; Password = foska000; Database = postgres");
                try
                {
                    // regularni kod
                    conn.Open();
                    int uloga = -1;
                    string salt = "helloworldBlahBlah";
                    passHash = GetDeterministicHashCode((login.pass + login.user + salt)).ToString();


                    /*activeUser.name = login.user;
                    activeUser.pass = login.pass;
                    activeUser.accessLvl = uloga;
                    LblUser0.Text = activeUser.name;*/

                    print2list("Konekcija otvorena...");
                    //string naredba = $"SELECT access_lvl from auth WHERE user='{login.user}' and pass='{login.pass}'";
                    string naredba = $"SELECT access_lvl from auth where user_name='{login.user}' and pass='{passHash}'";
                    NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

                    Int32.TryParse(command.ExecuteScalar().ToString(), out uloga);

                    activeUser.name = login.user;
                    activeUser.pass = login.pass;
                    activeUser.accessLvl = uloga;
                    LblUser0.Text = activeUser.name;

                    if (activeUser.accessLvl != 0)
                    {
                        BtnAdd.Enabled = false;
                        BtnChange.Enabled = false;
                        BtnRemove.Enabled = false;
                    }
                    else
                    {
                        BtnAdd.Enabled = true;
                        BtnChange.Enabled = true;
                        BtnRemove.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    // obrada greske
                    print2list(ex.Message);
                    print2list("login atempt: user:" + login.user + " pass: " + passHash);
                    //insert into auth("id","user_name","pass","access_lvl") VALUES (3,'admin',979195496,0)
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
    }
    public void addUserToWhiteList(String cardId, String cardType, string name, string surname, string validUntil) {
        /// INSERT INTO korisnici("card_id","first_name","last_name") VALUES('1234','hello','world');
        string naredba = $"INSERT INTO korisnici(\"card_id\",\"first_name\",\"last_name\",\"card_type\",\"valid_until\") VALUES('{cardId.ToUpper()}','{name.ToUpper()}','{surname.ToUpper()}','{cardType.ToUpper()}','{validUntil}');";
        int res = executeNonQuery(naredba);
        if (res == 0)
        {
            print2list("[ OK ] User added");
        }
    }

     public static bool isUserInWhiteList(string firstName, string lastName) {
         ///SELECT* from korisnici Where first_name = 'hllo' AND last_name = 'world'
         //ListView.Clear();
         NpgsqlConnection conn = new NpgsqlConnection($"Host = localhost; Port = 5432; Username = postgres; Password = foska000; Database = postgres");
         try
         {
             // regularni kod
             conn.Open();
             string naredba = $"SELECT id from korisnici Where first_name = '{firstName.ToUpper()}' AND last_name='{lastName.ToUpper()}'";
             NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

             NpgsqlDataReader reader = command.ExecuteReader();
             List<int> ids = new List<int>();
            if (reader.Read()) {
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
    
     void changeWhitelistData(String firstName, String lastName, CardData card) {
        /// 
        ///Update korisnici SET first_name='gg', last_name='gg', card_type='gg', card_id='gg', valid_until='gg' WHERE first_name='gg' and last_name='gg';

        string naredba = $"Update korisnici SET first_name='{card.firstName.ToUpper()}', last_name='{card.lastName.ToUpper()}', card_type='{card.cardType.ToUpper()}', card_id='{card.cardID.ToUpper()}', valid_until='{card.validUntil}' WHERE first_name='{firstName.ToUpper()}' and last_name='{lastName.ToUpper()}'";
        int res = executeNonQuery(naredba);
        if (res == 0)
        {
            print2list("[ OK ] Change user");
        }
        else {
            print2list("[ ER ] Change user");
        }
    }
    public void logAccess(string cardId, string cardType, bool isEntry, string name, string surname)
    {
        DateTime now = DateTime.Now;
        string time = now.Hour.ToString() + ":" + now.Minute.ToString() + ":" + now.Second.ToString();
        string date = now.Day.ToString() + "/" + now.Month.ToString() + "/" + now.Year.ToString();
        string naredba = $"INSERT INTO evidencija(\"card_id\",\"card_type\",\"is_entry\",\"name\",\"surname\",\"time\",\"date\") VALUES ('{cardId}','{cardId}',{isEntry},'{name}','{surname}','{time}','{date}')";
        int res = executeNonQuery(naredba);
        if (res == 0) {
            print2list("[ OK ] Event logged");
        }
    }

    public int executeNonQuery(string naredba) {
        NpgsqlConnection conn = new NpgsqlConnection($"Host = localhost; Port = 5432; Username = postgres; Password = foska000; Database = postgres");
        try
        {
            conn.Open();

            print2list("Konekcija otvorena...");
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);
            int res = command.ExecuteNonQuery();
            print2list(res.ToString());   
        }
        catch (Exception ex)
        {
            print2list(ex.Message);
            return -1;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        return 0;
    }


    private void showLog()
    {
        ListView.Clear();
        NpgsqlConnection conn = new NpgsqlConnection($"Host = localhost; Port = 5432; Username = postgres; Password = foska000; Database = postgres");
        try
        {
            // regularni kod
            conn.Open();
            print2list("Konekcija otvorena...");
            string naredba = "select is_entry, time, date, card_id, card_type, name, surname from evidencija";
            NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                bool isEntry = reader.GetBoolean(0);
                string time = reader.GetString(1).ToUpper();
                string date = reader.GetString(2).ToUpper();
                string cardId = reader.GetString(3).ToUpper();
                string cardType = reader.GetString(4).ToUpper();
                string name = reader.GetString(5).ToUpper();
                string surname = reader.GetString(6).ToUpper();
                string entry = "Ulaz";
                if (!isEntry) {
                    entry = "Izlaz";
                }
                print2list($"{entry.PadLeft(10)} | {time.PadLeft(15)} | {date.PadLeft(15)} | {cardId.PadLeft(15)} | {cardType.PadLeft(15)} | {(name + " " + surname).PadLeft(30)}");
            }

        }
        catch (Exception ex)
        {
            // obrada greske
            print2list(ex.Message);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        while (activeUser.name.CompareTo("") == 0)
        {
            login();
        }
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
        // logAccess("1234", "temp", false, "unknown", "unknown");
        forms.FrmAddUser addUser = new forms.FrmAddUser();
        DialogResult res = addUser.ShowDialog();
        if (res == DialogResult.OK)
        {
            /// ADD new user to DB
            CardData newCard = new CardData();
            newCard.firstName = addUser.firstName;
            newCard.lastName = addUser.lastName;
            newCard.cardID = addUser.cardID;
            newCard.cardType = addUser.cardType;
            newCard.validUntil = addUser.validUntil;
            newCard.validUntilTM = DateTime.Parse(newCard.validUntil);
            addUserToWhiteList(newCard.cardID, newCard.cardType.ToUpper(), newCard.firstName.ToUpper(), newCard.lastName.ToUpper(), newCard.validUntil);

        }
    }   

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        checkAccess("6969");
        //checkAccess("6969");
    }

    private void BtnShow_Click(object sender, EventArgs e)
    {
        showLog();
        
    }

    private void BtnChange_Click(object sender, EventArgs e)
    {
        print2list("Change user");

        FrmEditUser editUser = new FrmEditUser();
        DialogResult res = editUser.ShowDialog();
        if (res == DialogResult.OK) {
            CardData updatedCard = new CardData();
            updatedCard.firstName = editUser.newFirstName;
            updatedCard.lastName = editUser.newLastName;
            updatedCard.cardID = editUser.cardID;
            updatedCard.cardType = editUser.cardType;
            updatedCard.validUntil = editUser.validUntil;
         
            changeWhitelistData(editUser.oldFirstName, editUser.oldLastName, updatedCard);
        }
    }

    private void BtnAccGranted_Click(object sender, EventArgs e)
    {

    }

    private void BtnFinished_Click(object sender, EventArgs e)
    {
        exit();
    }

    private void BtnClearTerminal_Click(object sender, EventArgs e)
    {
        ListView.Clear();
    }

    private void DropMenu0_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }

    private void toolStripTextBox3_Click(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void toolStripComboBox1_Click(object sender, EventArgs e)
    {

    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }

    private void toolStripTextBox1_Click(object sender, EventArgs e)
    {

    }

    private void BtnLogout_Click_1(object sender, EventArgs e)
    {
        activeUser = new user("", "", 0);
        while (activeUser.name.CompareTo("") == 0)
        {
            login();
        }
    }

    private void BtnLogin_Click_1(object sender, EventArgs e)
    {
        login();
    }

    private void ListView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
