using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
// Added
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Data;


namespace DB_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // For facemaker
        public CommandHandler cmdNewEyes1;
        public CommandHandler cmdNewEyes2;
        public CommandHandler cmdNewEyes3;
        public CommandHandler cmdNewHair1;
        public CommandHandler cmdNewHair2;
        public CommandHandler cmdNewHair3;
        public CommandHandler cmdNewNose1;
        public CommandHandler cmdNewNose2;
        public CommandHandler cmdNewNose3;
        public CommandHandler cmdNewMouth1;
        public CommandHandler cmdNewMouth2;
        public CommandHandler cmdNewMouth3;
        public CommandHandler cmdNewRandom;

        //NC-3 Specify a connection string.  
        string connstr = DB_03.Utility.GetConnectionString();

        // Declare DataTable class-wide, so delete button can access
        DataTable dt;

        // update needs current primary key
        int current_primary_key = 0;

        public MainWindow()
        {
            InitializeComponent();

            // Fill the data grid with Person table data
            FillDataGrid();

            // Fill the data grid with Event table data
            FillEventDataGrid();

            cmdNewEyes1 = new CommandHandler(newEyes1, true);
            cmdNewEyes2 = new CommandHandler(newEyes2, true);
            cmdNewEyes3 = new CommandHandler(newEyes3, true);
            cmdNewHair1 = new CommandHandler(newHair1, true);
            cmdNewHair2 = new CommandHandler(newHair2, true);
            cmdNewHair3 = new CommandHandler(newHair3, true);
            cmdNewNose1 = new CommandHandler(newNose1, true);
            cmdNewNose2 = new CommandHandler(newNose2, true);
            cmdNewNose3 = new CommandHandler(newNose3, true);
            cmdNewMouth1 = new CommandHandler(newMouth1, true);
            cmdNewMouth2 = new CommandHandler(newMouth2, true);
            cmdNewMouth3 = new CommandHandler(newMouth3, true);
            cmdNewRandom = new CommandHandler(newRandom, true);

            DataContext = new
            {
                newEyesCMD1 = cmdNewEyes1,
                newEyesCMD2 = cmdNewEyes2,
                newEyesCMD3 = cmdNewEyes3,
                newHairCMD1 = cmdNewHair1,
                newHairCMD2 = cmdNewHair2,
                newHairCMD3 = cmdNewHair3,
                newNoseCMD1 = cmdNewNose1,
                newNoseCMD2 = cmdNewNose2,
                newNoseCMD3 = cmdNewNose3,
                newMouthCMD1 = cmdNewMouth1,
                newMouthCMD2 = cmdNewMouth2,
                newMouthCMD3 = cmdNewMouth3,
                newRandomCMD = cmdNewRandom,

            };

            InputBindings.Add(new KeyBinding(cmdNewEyes1, new KeyGesture(Key.Q, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewEyes2, new KeyGesture(Key.W, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewEyes3, new KeyGesture(Key.E, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewHair1, new KeyGesture(Key.F1, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(cmdNewHair2, new KeyGesture(Key.F2, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(cmdNewHair3, new KeyGesture(Key.F3, ModifierKeys.None)));
            InputBindings.Add(new KeyBinding(cmdNewNose1, new KeyGesture(Key.A, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewNose2, new KeyGesture(Key.S, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewNose3, new KeyGesture(Key.D, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewMouth1, new KeyGesture(Key.Z, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewMouth2, new KeyGesture(Key.X, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewMouth3, new KeyGesture(Key.C, ModifierKeys.Control)));
            InputBindings.Add(new KeyBinding(cmdNewRandom, new KeyGesture(Key.R, ModifierKeys.Control)));
        }

        BitmapImage Hair01 = new BitmapImage(new Uri("images/hair1.gif", UriKind.Relative));
        BitmapImage Eyes01 = new BitmapImage(new Uri("images/eyes1.gif", UriKind.Relative));
        BitmapImage Nose01 = new BitmapImage(new Uri("images/nose1.gif", UriKind.Relative));
        BitmapImage Mouth01 = new BitmapImage(new Uri("images/mouth1.gif", UriKind.Relative));

        BitmapImage Hair02 = new BitmapImage(new Uri("images/hair2.gif", UriKind.Relative));
        BitmapImage Eyes02 = new BitmapImage(new Uri("images/eyes2.gif", UriKind.Relative));
        BitmapImage Nose02 = new BitmapImage(new Uri("images/nose2.gif", UriKind.Relative));
        BitmapImage Mouth02 = new BitmapImage(new Uri("images/mouth2.gif", UriKind.Relative));

        BitmapImage Hair03 = new BitmapImage(new Uri("images/hair3.gif", UriKind.Relative));
        BitmapImage Eyes03 = new BitmapImage(new Uri("images/eyes3.gif", UriKind.Relative));
        BitmapImage Nose03 = new BitmapImage(new Uri("images/nose3.gif", UriKind.Relative));
        BitmapImage Mouth03 = new BitmapImage(new Uri("images/mouth3.gif", UriKind.Relative));

        Random rnd = new Random();

        public void RandomFace(BitmapImage temp, BitmapImage temp2, BitmapImage temp3, int left, int top)
        {
            Image img = new Image();

            List<BitmapImage> random = new List<BitmapImage>();

            random.Add(temp);
            random.Add(temp2);
            random.Add(temp3);

            int index = rnd.Next(0, 3);

            img.Source = random[index];
            img.Width = random[index].Width;
            img.Height = random[index].Height;

            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
            myCanvas.Children.Add(img);
        }

        public void FaceSelect(BitmapImage temp, int left, int top)
        {
            Image img = new Image();

            img.Source = temp;
            img.Width = temp.Width;
            img.Height = temp.Height;

            Canvas.SetLeft(img, left);
            Canvas.SetTop(img, top);
            myCanvas.Children.Add(img);

        }

        String eye = "";
        String hair = "";
        String nose = "";
        String mouth = "";

        public void newEyes1()
        {
            FaceSelect(Eyes01, 1, 305);
            eye = "Eye 1";
        }

        public void newEyes2()
        {
            FaceSelect(Eyes02, 1, 305);
            eye = "Eye 2";
        }

        public void newEyes3()
        {
            FaceSelect(Eyes03, 1, 305);
            eye = "Eye 3";
        }

        public void newHair1()
        {
            FaceSelect(Hair01, 1, 38);
            hair = "Hair 1";
        }

        public void newHair2()
        {
            FaceSelect(Hair02, 1, 38);
            hair = "Hair 2";
        }

        public void newHair3()
        {
            FaceSelect(Hair03, 1, 38);
            hair = "Hair 3";
        }

        public void newNose1()
        {
            FaceSelect(Nose01, 1, 450);
            nose = "Nose 1";
        }

        public void newNose2()
        {
            FaceSelect(Nose02, 1, 450);
            nose = "Nose 2";
        }

        public void newNose3()
        {
            FaceSelect(Nose03, 1, 450);
            nose = "Nose 3";
        }

        public void newMouth1()
        {
            FaceSelect(Mouth01, 1, 625);
            mouth = "Mouth 1";
        }

        public void newMouth2()
        {
            FaceSelect(Mouth02, 1, 625);
            mouth = "Mouth 2";
        }

        public void newMouth3()
        {
            FaceSelect(Mouth03, 1, 625);
            mouth = "Mouth 3";
        }

        public void newRandom()
        {
            RandomFace(Hair01, Hair02, Hair03, 1, 38);
            RandomFace(Nose01, Nose02, Nose03, 1, 450);
            RandomFace(Eyes01, Eyes02, Eyes03, 1, 305);
            RandomFace(Mouth01, Mouth02, Mouth03, 1, 625);
 
        }

        // Bind the Database Person table to the screen datagrid
        private void FillDataGrid()
        {

            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(connstr))
            {
                // pull whatever columns we want on the grid...get all
                CmdString = "SELECT Id, fname, lname, city, occ, hob, hair, eyes, nose, mouth FROM Person";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);             // adapter to connect both sides
                dt = new DataTable("gridPerson");
                sda.Fill(dt);
                gridPerson.ItemsSource = dt.DefaultView;  // Fill grid with DataTable
            }
        }

        // Bind the Database event table to the screen datagrid
        private void FillEventDataGrid()
        {

            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(connstr))
            {
                // pull whatever columns we want on the grid...get all
                CmdString = "SELECT Id, eventname, eventcity, eventdesc FROM Event";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);             // adapter to connect both sides
                dt = new DataTable("gridEvent");
                sda.Fill(dt);
                gridEvent.ItemsSource = dt.DefaultView;  // Fill grid with DataTable
            }
        }


        // Event for buttons start with "b_"
        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            String fn = tb_first.Text;
            String ln = tb_last.Text;
            String city = tb_city.Text;
            String occ = occupation.Text;
            String hob = hobby.Text;
            String ha = hair;
            String ey = eye;
            String no = nose;
            String mo = mouth;


            // Add this record if values not empty
            if (fn != "" && ln != "" && city != "" && occ != "" && hob != "" && ha != "" && ey != "" && no != "" && mo != "")
            {
                this.addPerson(fn, ln, city, occ, hob, ha, ey, no, mo);  // old school SQL-over-the-connection
            }
            else
            {
                MessageBox.Show("A field is empty...enter all fields");
            }

            // Update changes to the grid
            FillDataGrid();
        }


        // Add a person record with these attributes...SQL INSERT command
        private void addPerson(String fn, String ln, String city, String occ, String hob, String ha, String ey, String no, String mo)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connstr);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text = "INSERT INTO Person(fname, lname, city, occ, hob, hair, eyes, nose, mouth)  VALUES('" + fn + "', '" + ln + "', '" + city + "', '" + occ + "', '" + hob + "', '" + ha + "', '" + ey + "', '" + no + "', '" + mo + "');";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { MessageBox.Show("DB Add Exception"); }
            finally { conn.Close(); }

        }


        // Add a person record with these attributes...SQL INSERT command
        private void delPerson(int pkey)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connstr);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text = "DELETE FROM Person WHERE Id = " + pkey + ";";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { MessageBox.Show("DB Delete Exception"); }
            finally { conn.Close(); }

        }



        // Add a person record with these attributes...SQL INSERT command
        private void upPerson(int pkey, String fn, String ln, String city, String occ, String hob, String ha, String ey, String no, String mo)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connstr);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text = 
                "UPDATE Person SET fname = '" + fn + 
                "', lname = '" + ln + 
                "', city = '" + city +
                "', occ = '" + occ +
                "', hob = '" + hob +
                "', hair = '" + ha +
                "', eyes = '" + ey +
                "', nose = '" + no +
                "', mouth = '" + mo +
                "'  WHERE Id = " + pkey + ";";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { MessageBox.Show("DB Delete Exception"); }
            finally { conn.Close(); }

        }


        // Add a event record with these attributes...SQL INSERT command
        private void upEvent(int pkey, String en, String ec, String ed)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connstr);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text =
                "UPDATE Event SET eventname = '" + en +
                "', eventcity = '" + ec +
                "', eventdesc = '" + ed +
                "'  WHERE Id = " + pkey + ";";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { MessageBox.Show("DB Delete Exception"); }
            finally { conn.Close(); }

        }


        // Gets called when grid is selected
        private void gridPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // When we get here after deleting a row, we can't get the current row
            try
            {
                // fetch the columns from the selected row
                current_primary_key = (int)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[0];
                tb_first.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[1];
                tb_last.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[2];
                tb_city.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[3];
                occupation.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[4];
                hobby.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[5];
                hair = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[6];
                eye = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[7];
                nose = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[8];
                mouth = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[9];



                Trace.WriteLine("Selected = " + current_primary_key + tb_first.Text + tb_last.Text + tb_city.Text + occupation.Text.ToString() + hobby.Text.ToString() + hair + eye + nose + mouth);
            }
            catch
            {
                // If deleting row, get exception trying to get it's data
                Trace.WriteLine("No Row (deleted?)...default record used");
                current_primary_key = -1;
                tb_first.Text = "";
                tb_last.Text = "";
                tb_city.Text = "";
                occupation.SelectedIndex = -1;
                hobby.SelectedIndex = -1;

            }
        }

        private void delEvent(int pkey)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connstr);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text = "DELETE FROM Event WHERE Id = " + pkey + ";";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { MessageBox.Show("DB Delete Exception"); }
            finally { conn.Close(); }

        }

        private void b_delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridPerson.SelectedItem != null)
            {
                int key = (int)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[0];
                delPerson(key);

                // These lines update the grid, but not the database
                dt.Rows.Remove((gridPerson.SelectedItem as DataRowView).Row);
                dt.AcceptChanges();
            }
        }

        private void b_update_Click(object sender, RoutedEventArgs e)
        {
            if (current_primary_key >-1)
            {
                upPerson(current_primary_key, tb_first.Text, tb_last.Text, tb_city.Text, occupation.Text, hobby.Text, hair, eye, nose, mouth);

                // Update changes to the grid
                FillDataGrid();
            }
        }

        // Add a event record with these attributes...SQL INSERT command
        private void addEvent(String en, String ec, String ed)
        {
            // Old school connection
            SqlConnection conn = new SqlConnection(connstr);

            // old school insert statement...note Trace output should show format of SQL Insert command
            String cmd_Text = "INSERT INTO Event(eventname, eventcity, eventdesc)  VALUES('" + en + "', '" + ec + "', '" + ed + "');";
            Trace.Write(cmd_Text);

            // DB insert in try-catch
            try
            {
                // Example of C# named parameters...a good idea for important library calls
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                command.Connection.Open();
                command.ExecuteNonQuery();  //does the actual insert statement
            }
            catch { MessageBox.Show("DB Add Exception"); }
            finally { conn.Close(); }

        }

        private void b_eventAdd_Click(object sender, RoutedEventArgs e)
        {
            String en = tb_eventName.Text;
            String ec = tb_eventCity.Text;
            String ed = tb_eventDescription.Text;

            // Add this record if values not empty
            if (en != "" && ec != "" && ed != "")
            {
                this.addEvent(en, ec, ed);  // old school SQL-over-the-connection
  
            }
            else
            {
                MessageBox.Show("A field is empty...enter all fields");
            }

            // Update changes to the grid
            FillEventDataGrid();

        }

        private void gridEvent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // When we get here after deleting a row, we can't get the current row
            try
            {
                // fetch the columns from the selected row
                current_primary_key = (int)(gridEvent.SelectedItem as DataRowView).Row.ItemArray[0];
                tb_eventName.Text = (string)(gridEvent.SelectedItem as DataRowView).Row.ItemArray[1];
                tb_eventCity.Text = (string)(gridEvent.SelectedItem as DataRowView).Row.ItemArray[2];
                tb_eventDescription.Text = (string)(gridEvent.SelectedItem as DataRowView).Row.ItemArray[3];



                Trace.WriteLine("Selected = " + current_primary_key + tb_eventName.Text + tb_eventCity.Text + tb_eventDescription.Text);
            }
            catch
            {
                // If deleting row, get exception trying to get it's data
                Trace.WriteLine("No Row (deleted?)...default record used");
                current_primary_key = -1;
                tb_eventName.Text = "";
                tb_eventCity.Text = "";
                tb_eventDescription.Text = "";

            }

        }

        private void b_eventDelete_Click(object sender, RoutedEventArgs e)
        {
            if (gridEvent.SelectedItem != null)
            {
                int key = (int)(gridEvent.SelectedItem as DataRowView).Row.ItemArray[0];
                delEvent(key);

                // These lines update the grid, but not the database
                dt.Rows.Remove((gridEvent.SelectedItem as DataRowView).Row);
                dt.AcceptChanges();
            }

        }

        private void b_eventUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (current_primary_key > -1)
            {
                upEvent(current_primary_key, tb_eventName.Text, tb_eventCity.Text, tb_eventDescription.Text);

                // Update changes to the grid
                FillEventDataGrid();
            }

        }
    }
}
