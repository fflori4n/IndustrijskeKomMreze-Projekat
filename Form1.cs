#define _checkMultipleEntry

using Npgsql;
using ProjektniZadatak.forms;

namespace ProjektniZadatak;

public partial class Form1 : Form
{

    public user activeUser = new user("", "", 0);
    public static ListView mainListView;
    public RS232 serial;
    public Form1()
    {
        InitializeComponent();
        mainListView = ListView;

        /// from: https://stackoverflow.com/questions/2309046/making-listview-scrollable-in-vertical-direction
        ListView.Scrollable = true;
        ListView.View = View.Details;
        ListView.HeaderStyle = ColumnHeaderStyle.None;

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

    public static void reactToCardSwipe(string cardMsg) {
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
        if (checkAccess(access.cardId, access.isEntry))
        {

#if _checkMultipleEntry
            /// check if user already entered - optional -************************************************
            int res = PostgreSQL.isUserInside(access.cardId);
            if (res == 0 && access.isEntry){
                print2list($"ZABRANJENO: {access.cardId} -- Pokušaj ulaza više puta istim karticom");
                TCPClient.send("03, 78, 58, 90"); /// send DO NOT OPEN
                return;
            }
            /// -************************************************
#endif
            CardData newCard = PostgreSQL.checkCard(access.cardId);
            access.name = newCard.firstName;
            access.surname = newCard.lastName;
            access.cardType = newCard.cardType;

            PostgreSQL.logAccess(access);
            TCPClient.send("03, 78, 58, 68"); /// send OPEN
            string ulaz = "IZLAZ";
            if (access.isEntry) {
                ulaz = "ULAZ";
            }
            print2list($"DOZVOLJENO: {access.cardId} - {ulaz} - {access.name} {access.surname} - {access.cardType} Kartica");
        }
        else {
            TCPClient.send("03, 78, 58, 90"); /// send DO NOT OPEN
        }

    }
    private static bool checkAccess(string cardID, bool isEntry) {
        CardData checkedCard = PostgreSQL.checkCard(cardID);
        if (checkedCard.isValid) {
            if (checkedCard.cardType.CompareTo("OBIČNA") == 0 && isEntry)
            {
                if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 15)
                {
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

                    string naredba = $"SELECT access_lvl from auth where user_name='{login.user}' and pass='{passHash}'";
                    NpgsqlCommand command = new NpgsqlCommand(naredba, conn);

                    Int32.TryParse(command.ExecuteScalar().ToString(), out uloga);

                    activeUser.name = login.user;
                    activeUser.pass = login.pass;
                    activeUser.accessLvl = uloga;
                    LblUser0.Text = activeUser.name;
                    serial = new RS232(login.comPort);
                    TCPClient.connect(login.tcpIpAddr, login.tcpPort);
                    TCPClient.send("C# Client connected!");
                    mainListView.Refresh();
                    mainListView = ListView;
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
                    print2list("login atempt: user:" + login.user + " pass: " + passHash); /// print to screen so I can add hash to database for new users
                    
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
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
        TCPClient.send("03, 78, 58, 80");
        Access access = new Access();
        access.cardId = "0000";
        access.isEntry = true;
        access.name = "DOZVOLA PUTEM APLIKACIJE";
        access.surname = "";
        PostgreSQL.logAccess(access);
    }

    private void BtnFinished_Click(object sender, EventArgs e)
    {
        TCPClient.dispose();
        exit();
    }

    private void BtnClearTerminal_Click(object sender, EventArgs e)
    {
        mainListView.Items.Clear();
    }

    private void BtnLogout_Click_1(object sender, EventArgs e)
    {
        activeUser = new user("", "", 0);
        TCPClient.dispose();
        if (serial is not null) {
            serial.dispose();
        }
        while (activeUser.name.CompareTo("") == 0)
        {
            this.Visible = false;
            login();
        }
        this.Visible = true;
    }

    private void BtnLogin_Click_1(object sender, EventArgs e)
    {
        login();
    }
}
