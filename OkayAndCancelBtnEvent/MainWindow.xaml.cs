using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
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
using System.Xml.Serialization;

namespace OkayAndCancelBtnEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();
        Person p1 = new Person();
        Person p2 = new Person();
        Person p3 = new Person();

        string desktopPathJson = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktopPathBinary = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktopPathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public MainWindow()
        {
            InitializeComponent();
        }

        //Buttons
        #region
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {        
            CreateJsonFile();
            CreateBinary();
            CreateXml();
        }
        
        // Button Exit or Close Application
        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Button show Json File
        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            ShowJsonFile();
        }

        // Button Show Binary File
        private void Btn_Binary_Click(object sender, RoutedEventArgs e)
        {
            ShowBinaryFile();
        }

        // Button Show Xml File
        private void Btn_Xml_Click(object sender, RoutedEventArgs e)
        {
            ShowXmlFile();
        }

        //Button Delete
        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            people.RemoveAt(Dat_grid.SelectedIndex);
            Dat_grid.ItemsSource = null;
            Dat_grid.ItemsSource = people;
            }

            catch (Exception)
            {
                MessageBox.Show("invalid option");
            }

        }
        #endregion
    
        //Link Textfields from UI to attributes in Class Person and create Json File
        #region      

            // Json Serialization
        private void CreateJsonFile()
        {

            p1.fName = txtBox_fName.Text;
            p1.surName = txtBox_sName.Text;
            p1.country = txtBox_country.Text;

            try
            {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            FileStream fs = new FileStream(desktopPathJson +"\\JsonPersInfo", FileMode.OpenOrCreate);
            serializer.WriteObject(fs, p1);
            fs.Close();

            MessageBox.Show("Json Serialized");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // Json Deserialization
        private void ShowJsonFile()
        {
            try
            {

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            FileStream fs = new FileStream(desktopPathJson + "\\JsonPersInfo", FileMode.OpenOrCreate);
            p1 = (Person)serializer.ReadObject(fs);

            fs.Close();

          
            people.Add(p1);
            people.Add(p2);
            people.Add(p3);

            Dat_grid.ItemsSource = people;
                 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion

        //Link Textfields from UI to attributes in Class Person and create Binary File
        #region
            
            // Binary Serialization
        private void CreateBinary()
        {
            p2.fName = txtBox_fName.Text;
            p2.surName = txtBox_sName.Text;
            p2.country = txtBox_country.Text;

            try
            {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(desktopPathBinary + "\\Binaryfile", FileMode.OpenOrCreate);
            bf.Serialize(fs,p2);
            fs.Close();

            MessageBox.Show("Binary Serialized");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // Binary Deserializaion
        private void ShowBinaryFile()
        {
            try
            {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(desktopPathBinary + "\\Binaryfile", FileMode.OpenOrCreate);
            p2 = (Person)bf.Deserialize(fs);

            fs.Close();

            people.Add(p1);
            people.Add(p2);
            people.Add(p3);

            Dat_grid.ItemsSource = people;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }
        #endregion

        //Link Textfields from UI to attributes in Class Person and create XML File
        #region

            // XMl Serialization
        private void CreateXml()
        {
            p3.fName = txtBox_fName.Text;
            p3.surName = txtBox_sName.Text;
            p3.country = txtBox_country.Text;

            try
            {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            FileStream fs = new FileStream(desktopPathXml + "\\Xmlfile", FileMode.OpenOrCreate);
            fs.Close();

            MessageBox.Show("XLM file Serialized");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        // XML Deserialization
        private void ShowXmlFile()
        {
            try
            {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            FileStream fs = new FileStream(desktopPathXml + "\\Xmlfile", FileMode.OpenOrCreate);
            p3 = (Person)xmlSerializer.Deserialize(fs);

            fs.Close();

            people.Add(p1);
            people.Add(p2);
            people.Add(p3);

            Dat_grid.ItemsSource = people;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

    }
}
