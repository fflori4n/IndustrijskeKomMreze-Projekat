using Npgsql;
using ProjektniZadatak.forms;

namespace ProjektniZadatak;

public partial class Form1 : Form
{
    public user activeUser = new user("", "", 0);
    public static ListView mainListView;
   // CardData newCard = new CardData();
    public Form1()
    {
        InitializeComponent();
        mainListView = ListView;
        ListView.Columns.RemoveAt(0);
        //ListView.Columns.RemoveAt(1);
        RS232 serial = new RS232("COM1", ListView);
    }
    public static void print2list(string poruka)
    {
        if (mainListView == null) {
            return;
        }
        if (mainListView.InvokeRequired)
        {
            mainListView.Invoke((MethodInvoker)(() =>
            {
                mainListView.Items.Add("InvokeRequired");
                mainListView.Items.Add(poruka);
            }));
        }
        else
        {
            mainListView.Items.Add(poruka);
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

    public void reactToCardSwipe(string cardMsg) {
        Access access = new Access();
        string[] words = cardMsg.Split(',');
        if (words[0] == "0")
        {
            access.isEntry = true;
        }
        else { 
            access.isEntry = false;
        }

        access.cardId = words[1];
        if (checkAccess(access.cardId))
        {
            /// TODO: send open CMD
            CardData newCard = PostgreSQL.checkCard(access.cardId);
            access.name = newCard.firstName;
            access.surname = newCard.lastName;
            access.cardType = newCard.cardType;
            PostgreSQL.logAccess(access);
        }
        else { 
            /// TODO: send do not open
        }
        
    }
    private bool checkAccess(string cardID) {
        CardData checkedCard = PostgreSQL.checkCard(cardID);
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
            PostgreSQL.addUserToWhiteList(newCard.cardID, newCard.cardType.ToUpper(), newCard.firstName.ToUpper(), newCard.lastName.ToUpper(), newCard.validUntil);

        }
    }

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        checkAccess("6969");
        FrmRemoveUser remove = new FrmRemoveUser();
        DialogResult res = remove.ShowDialog();
        if (res == DialogResult.OK)
        {
            //checkAccess("6969");
        }
    }

    private void BtnShow_Click(object sender, EventArgs e)
    {
        PostgreSQL.showLog();
        
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
         
            PostgreSQL.changeWhitelistData(editUser.oldFirstName, editUser.oldLastName, updatedCard);
        }
    }

    private void BtnAccGranted_Click(object sender, EventArgs e)
    {
        //searchBySingleParam("first_name", "A");
        reactToCardSwipe("1,556");
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
