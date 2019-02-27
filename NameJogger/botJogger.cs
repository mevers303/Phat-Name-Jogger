using System;
using System.Collections.Generic;
using BNSharp;
using BNSharp.BattleNet;
using BNSharp.Net;
using Microsoft.Win32;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;



namespace NameJogger
{
    class botJogger
    {

        #region Classes, Structs, and Enums

        private class Settings : IBattleNetSettings
        {

            private string _Name;
            public string Name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                }
            }

            private string _Client;
            public string Client
            {
                get
                {
                    return _Client;
                }
                set
                {
                    _Client = value;
                }
            }

            private int _VersionByte;
            public int VersionByte
            {
                get
                {
                    return _VersionByte;
                }
                set
                {
                    _VersionByte = value;
                }
            }

            private string _CdKey1;
            public string CdKey1
            {
                get
                {
                    return _CdKey1;
                }
                set
                {
                    _CdKey1 = value;
                }
            }

            private string _CdKey2;
            public string CdKey2
            {
                get
                {
                    return _CdKey2;
                }
                set
                {
                    _CdKey2 = value;
                }
            }

            private string _GameExe;
            public string GameExe
            {
                get
                {
                    return _GameExe;
                }
                set
                {
                    _GameExe = value;
                }
            }

            private string _GameFile2;
            public string GameFile2
            {
                get
                {
                    return _GameFile2;
                }
                set
                {
                    _GameFile2 = value;
                }
            }

            private string _GameFile3;
            public string GameFile3
            {
                get
                {
                    return _GameFile3;
                }
                set
                {
                    _GameFile3 = value;
                }
            }

            private string _Username;
            public string Username
            {
                get
                {
                    return _Username;
                }
                set
                {
                    _Username = value;
                }
            }

            private string _ImageFile;
            public string ImageFile
            {
                get
                {
                    return _ImageFile;
                }
                set
                {
                    _ImageFile = value;
                }
            }

            private string _Password;
            public string Password
            {
                get
                {
                    return _Password;
                }
                set
                {
                    _Password = value;
                }
            }

            private string _Server;
            public string Server
            {
                get
                {
                    return _Server;
                }
                set
                {
                    _Server = value;
                }
            }

            private int _Port;
            public int Port
            {
                get
                {
                    return _Port;
                }
                set
                {
                    _Port = value;
                }
            }

            private string _CdKeyOwner;
            public string CdKeyOwner
            {
                get
                {
                    return _CdKeyOwner;
                }
                set
                {
                    _CdKeyOwner = value;
                }
            }

            private PingType _PingMethod;
            public PingType PingMethod
            {
                get
                {
                    return _PingMethod;
                }
                set
                {
                    _PingMethod = value;
                }
            }

            private string _NameList;
            public string NameList
            {
                get
                {
                    return _NameList;
                }
                set
                {
                    _NameList = value;
                }
            }

            private string _Home;
            public string Home
            {
                get
                {
                    return _Home;
                }
                set
                {
                    _Home = value;
                }
            }

            private int _Delay;
            public int Delay
            {
                get
                {
                    return _Delay;
                }
                set
                {
                    _Delay = value;
                }
            }

            private int _ConnectDelay;
            public int ConnectDelay
            {
                get
                {
                    return _ConnectDelay;
                }
                set
                {
                    _ConnectDelay = value;
                }
            }

        }

        #endregion


        #region Members


        static public frmMain form;
        //settings object
        private Settings settings = new Settings();
        //BN# client
        public BattleNetClient client;
        //dictionary of shared name lists, the key is the file path, the value is a struct w/ the index and list
        protected static Dictionary<string, List<string>> nameLists = new Dictionary<string, List<string>>();
        protected static Dictionary<string, int> listIndexes = new Dictionary<string, int>();
        protected static Dictionary<string, int> lastConnections = new Dictionary<string, int>();
        //timer for going to next name
        public System.Timers.Timer joggerTimer = new System.Timers.Timer();
        //the listviewitem associated with the bot
        protected ListViewItem listViewItem;
        //last tick of start time
        int waitTime = 0;
        protected int jogStartTime = 0;

        public string name
        {
            get
            {
                return settings.Name;
            }
            set
            {
                settings.Name = value;
            }
        }
        public bool connected
        {
            get
            {
                return client.IsConnected;
            }
        }
        public string username
        {
            get
            {
                return settings.Username;
            }
            set
            {
                try
                {
                    form.Invoke(new MethodInvoker(delegate { listViewItem.SubItems[1].Text = settings.Username; }));
                }
                catch
                {
                }
            }
        }
        public string status
        {
            get
            {
                return listViewItem.SubItems[2].Text;
            }
            set
            {
                form.Invoke(new MethodInvoker(delegate { listViewItem.SubItems[2].Text = value; }));
            }
        }
        public int progress
        {
            set
            {
                form.Invoke(new MethodInvoker(delegate { listViewItem.SubItems[3].Text = (value + 1).ToString() + " / " + (nameLists[settings.NameList].Count + 1).ToString(); }));
            }
        }
        public string channel
        {
            set
            {
                try
                {
                    form.Invoke(new MethodInvoker(delegate { listViewItem.SubItems[4].Text = value; }));
                }
                catch
                {
                }
            }
        }
        public string server
        {
            set
            {
                try
                {
                    form.Invoke(new MethodInvoker(delegate { listViewItem.SubItems[5].Text = value; }));
                }
                catch
                {
                }
            }
        }
        public string nameList
        {
            set
            {
                try
                {
                    form.Invoke(new MethodInvoker(delegate { listViewItem.SubItems[6].Text = value; }));
                }
                catch
                {
                }
            }
            get
            {
                return settings.NameList;
            }
        }
        public Color color
        {
            get
            {
                return listViewItem.ForeColor;
            }
            set
            {
                try
                {
                    form.Invoke(new MethodInvoker(delegate { listViewItem.ForeColor = value; }));
                }
                catch
                {
                }
            }
        }

        #endregion


        #region Misc Functions

        public void addChat(string format, params object[] args) {
            Console.WriteLine((name + " - " ).PadRight(20, ' ') + string.Format(format, args));
        }

        public botJogger(string botName, ListViewItem item)
        {

            name = botName;
            listViewItem = item;


            setStatus("Initializing...", Color.Yellow);



            loadConfig();
            setStatus("Settings loaded", Color.Yellow);
            


            client = new BattleNetClient(settings);


            joggerTimer.Elapsed += new ElapsedEventHandler(joggerTimer_Elapsed);

        }

        ~botJogger()
        {
            close();
        }

        public void loadConfig()
        {

            setStatus("Loading settings...", Color.Yellow);


            RegistryKey mainKey = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ");
            RegistryKey botKey = mainKey.OpenSubKey("Profiles\\" + name);

            settings.Client = (string)botKey.GetValue("Product", "");
            settings.VersionByte = (int)mainKey.GetValue(settings.Client + " VerByte", 0);
            settings.CdKey1 = (string)botKey.GetValue("CD Key", "");
            settings.CdKey2 = (string)botKey.GetValue("Expansion CD Key", "");
            settings.GameExe = (string)mainKey.GetValue(settings.Client + " File 1", "");
            settings.GameFile2 = (string)mainKey.GetValue(settings.Client + " File 2", "");
            settings.GameFile3 = (string)mainKey.GetValue(settings.Client + " File 3", "");
            settings.ImageFile = (string)mainKey.GetValue(settings.Client + " Video Dump", "");
            settings.Password = (string)botKey.GetValue("Password", "");
            settings.Server = (string)botKey.GetValue("Server", "");
            server = settings.Server;
            settings.Port = (int)mainKey.GetValue("Port", 6112);
            settings.CdKeyOwner = "Phat NJ";
            settings.PingMethod = (PingType)botKey.GetValue("Ping Type", PingType.Normal);
            settings.NameList = (string)botKey.GetValue("Name List", "");
            nameList = settings.NameList;
            settings.Home = (string)botKey.GetValue("Home", "");
            settings.Delay = (int)botKey.GetValue("Delay", 300); //5 minutes
            settings.ConnectDelay = (int)mainKey.GetValue("Connect Delay", 5000);

            setStatus("Settings loaded!", Color.Lime);

            loadNames();

        }

        public void loadNames()
        {

            if (!nameLists.ContainsKey(settings.NameList))
            {

                setStatus("Loading name list...", Color.Yellow);

                FileStream file = null;
                try
                {
                    file = File.OpenRead(settings.NameList);
                }
                catch
                {
                    setStatus("Could not load namelist!", Color.Red);
                    progress = -1;
                    return;
                }
                StreamReader stream = new StreamReader(file);

                List<string> names = new List<string>();
                string line;

                while ((line = stream.ReadLine()) != null)
                    names.Add(line);

                stream.Close();
                file.Close();

                RegistryKey mainKey = Registry.CurrentUser.OpenSubKey("Software\\Phat NJ");

                int i = (int)mainKey.OpenSubKey("List Indexes").GetValue(settings.NameList, 0);

                nameLists.Add(settings.NameList, names);
                listIndexes.Add(settings.NameList, i);

                setStatus("Name list loaded!", Color.Lime);

            }

            progress = 0;

        }

        protected void setEvents()
        {
            client.Connected += delegate { setStatus("Checking version...", Color.Yellow); };
            client.Error += new BNSharp.ErrorEventHandler(client_Error);
            client.EnteredChat += new EnteredChatEventHandler(client_EnteredChat);
            client.LoginSucceeded += delegate { setStatus(string.Format("Joining chat..."), Color.Yellow); };
            client.LoginFailed += new LoginFailedEventHandler(client_LoginFailed);
            client.ServerErrorReceived += new ServerChatEventHandler(client_ServerErrorReceived);
            client.ClientCheckPassed += delegate { setStatus("Logging in", Color.Yellow); };
            client.ClientCheckFailed += new ClientCheckFailedEventHandler(client_ClientCheckFailed);
            client.JoinedChannel += new ServerChatEventHandler(client_JoinedChannel);
            client.WardentUnhandled += delegate { setStatus("Warden check unhandled!", Color.Red); };
            client.UserProfileReceived += new UserProfileEventHandler(client_UserProfileReceived);
            client.Disconnected += new EventHandler(client_Disconnected);
            client.AccountCreated += new AccountCreationEventHandler(client_AccountCreated);
            client.AccountCreationFailed += new AccountCreationFailedEventHandler(client_AccountCreationFailed);
        }

        public void jogNext()
        {

            lock (this)
            {

                int i = listIndexes[settings.NameList];
                listIndexes[settings.NameList] = i + 1;
                if (i >= nameLists[settings.NameList].Count)
                {
                    i = 0;
                    listIndexes[settings.NameList] = i;
                }

                string newName = nameLists[settings.NameList][i];

                if (client.IsConnected)
                    close();

                settings.Username = newName;


                Registry.CurrentUser.OpenSubKey("Software\\Phat NJ\\List Indexes", true).SetValue(settings.NameList, listIndexes[settings.NameList], RegistryValueKind.DWord);

                progress = i + 1;
                username = newName;

            }

            connect();

        }

        public void connect()
        {

            setStatus("Connecting...", Color.Yellow);

            if (lastConnections.ContainsKey(settings.Server))
            {

                int difference = System.Environment.TickCount - lastConnections[settings.Server];

                if (difference < settings.ConnectDelay)
                {

                    System.Timers.Timer timer = new System.Timers.Timer(settings.ConnectDelay - difference);

                    timer.AutoReset = false;
                    timer.Elapsed += new ElapsedEventHandler(delegate { connect(); });
                    timer.Enabled = true;

                    setStatus("Waiting to connect...", Color.Yellow);

                    return;

                }

                lastConnections[settings.Server] = System.Environment.TickCount;

            }
            else
                lastConnections.Add(settings.Server, System.Environment.TickCount);


            try
            {
                client = new BattleNetClient(settings);
            }
            catch
            {
                MessageBox.Show(form, "Couldn't create new BN# client, probably because of a memory leak within BN#.  There is no fix for this yet, you're fucked.  Just restart the bot.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            setEvents();


            try
            {
                client.Connect();
            }
            catch
            {
                close();
            }

        }

        public void close()
        {

            if (client.IsConnected)
                client.Close();

            joggerTimer.Enabled = false;
            username = "";
            channel = "";

            jogStartTime = 0;

        }

        public void setStatus(string s, Color c)
        {
            if (s == "Disconnected!" && color == Color.Red)
                return;
            addChat(s);
            status = s;
            color = c;
        }

        public void refreshWaitTime()
        {
            if (connected && (jogStartTime > 0))
            {
                int elapsed = Environment.TickCount - jogStartTime;
                elapsed /= 1000;
                TimeSpan time = new TimeSpan(0, 0, 0, waitTime - elapsed);
                setStatus("Waiting " + time.ToString(), Color.Lime);
            }
        }

        #endregion


        #region Events

        void client_UserProfileReceived(object sender, UserProfileEventArgs e)
        {

            if (e.Profile.UserName.Contains("#"))
            {
                close();
                jogNext();
                return;
            }

            int timeLogged = int.Parse(e.Profile[UserProfileKey.TotalTimeLogged]);
            waitTime = 7201 - timeLogged;

            if (waitTime < settings.Delay)
                waitTime = settings.Delay;

            joggerTimer.Interval = waitTime * 1000;
            joggerTimer.Enabled = true;

            jogStartTime = Environment.TickCount;
            refreshWaitTime();

        }

        void client_JoinedChannel(object sender, ServerChatEventArgs e)
        {
            channel = e.Text;
            if (e.Text.ToLower() != settings.Home.ToLower())
                client.SendMessage("/join " + settings.Home);
        }

        void client_ClientCheckFailed(object sender, ClientCheckFailedEventArgs e)
        {

            switch (e.Reason)
            {

                case ClientCheckFailureCause.BannedCdKey:
                    setStatus("CD key is banned!", Color.Red);
                    break;

                case ClientCheckFailureCause.BannedExpCdKey:
                    setStatus("Expansion CD key is banned!", Color.Red);
                    break;

                case ClientCheckFailureCause.CdKeyInUse:
                    setStatus("CD key in use by " + e.AdditionalInformation, Color.Red);
                    break;

                case ClientCheckFailureCause.ExpCdKeyInUse:
                    setStatus("Expansion CD key in use by " + e.AdditionalInformation, Color.Red);
                    break;

                case ClientCheckFailureCause.InvalidCdKey:
                    setStatus("Invalid CD key!", Color.Red);
                    break;

                case ClientCheckFailureCause.InvalidExpCdKey:
                    setStatus("Invalid expansion CD key!", Color.Red);
                    break;

                case ClientCheckFailureCause.InvalidVersion:
                    setStatus("Invalid hash version!", Color.Red);
                    break;

                case ClientCheckFailureCause.NewerVersion:
                    setStatus("Game hashes need to be downgraded?", Color.Red);
                    break;

                case ClientCheckFailureCause.OldVersion:
                    setStatus("Game hashes are out of date!", Color.Red);
                    break;

                case ClientCheckFailureCause.Passed:
                    return;

                case ClientCheckFailureCause.WrongExpProduct:
                    setStatus("Expansion CD key is for a different game!", Color.Red);
                    break;

                case ClientCheckFailureCause.WrongProduct:
                    setStatus("CD key is for a different game!", Color.Red);
                    break;

            }


            close();

        }

        static void client_ServerErrorReceived(object sender, ServerChatEventArgs e)
        {
            Console.WriteLine("SERVER ERROR: {0}", e.Text);
        }

        void client_LoginFailed(object sender, LoginFailedEventArgs e)
        {

            switch (e.Reason)
            {

                case LoginFailureReason.AccountClosed:
                    setStatus("Account closed!", Color.Red);
                    close();
                    break;

                case LoginFailureReason.AccountDoesNotExist:
                    setStatus("Account does not exist!", Color.Red);
                    setStatus("Attempting to create account...", Color.Red);
                    try
                    {
                        client.CreateAccount();
                    }
                    catch (Exception ex)
                    {
                        setStatus(ex.Message, Color.Red);
                    }
                    break;

                case LoginFailureReason.InvalidAccountOrPassword:
                    setStatus("Incorrect password!", Color.Red);
                    close();
                    setStatus("Skipping to next account...", Color.Yellow);
                    jogNext();
                    break;

                case LoginFailureReason.Unknown:
                    setStatus("Unknown login error!", Color.Red);
                    close();
                    break;

            }

        }

        void client_EnteredChat(object sender, EnteredChatEventArgs e)
        {
            username = e.UniqueUsername;
            UserProfileRequest req = new UserProfileRequest(settings.Username, UserProfileKey.TotalTimeLogged);
            client.RequestUserProfile(settings.Username, req);
        }

        void client_Error(object sender, BNSharp.ErrorEventArgs e)
        {
            if (e.IsDisconnecting)
            {
                setStatus(e.Error, Color.Red);
                close();
            }
        }

        void joggerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            setStatus("Jogging complete!", Color.SkyBlue);
            jogNext();
        }

        void client_Disconnected(object sender, EventArgs e)
        {
            setStatus("Disconnected!", Color.Red);
            close();
        }

        void client_AccountCreationFailed(object sender, AccountCreationFailedEventArgs e)
        {
            setStatus("Failed to create account " + e.Reason.ToString(), Color.Red);
            close();
            jogNext();
        }

        void client_AccountCreated(object sender, AccountCreationEventArgs e)
        {
            setStatus("Successfully created " + e.AccountName + "!", Color.Green);
        }

        #endregion

    }
}
