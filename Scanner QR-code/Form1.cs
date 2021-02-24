using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;



namespace Scanner_QR_code
{
    public partial class ScannerQR : Form
    {
        public ScannerQR()
        {
            InitializeComponent();
        }

        private void CreateQR_Click_1(object sender, EventArgs e)
        {
            string qrtext = "ID: " + IDBox.Text +  "\n" + "Имя: " + NameBox.Text + "\n" + "Фамилия: " + SurnameBox.Text + "\n" + "Состояние: " + ActiveBox.Text + "\n" + "Группа крови: " + GroupBox.Text; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            pictureQR.Image = qrcode as Image; // pictureBox выводит qrcode как изображение.
        }
        private void SaveQR_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя, место, в которое он захочет сохранить файл. 
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //если пользователь нажимает в обозревателе кнопку "Сохранить".
            {
                pictureQR.Image.Save(save.FileName); //изображение из pictureBox'a сохраняется под именем, которое введёт пользователь
            }
        }
        private void InputQR_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog(); //  load будет запрашивать у пользователя место, из которого он хочет загрузить файл.
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK) // //если пользователь нажимает в обозревателе кнопку "Открыть".
            {
                pictureQR.ImageLocation = load.FileName; // в pictureBox'e открывается файл, который был по пути, запрошенном пользователем.
            }
        }
        private void OutsideQR_Click_1(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder(); // создаём "раскодирование изображения"
            MessageBox.Show(decoder.Decode(new QRCodeBitmapImage(pictureQR.Image as Bitmap))); //в MessageBox'e программа запишет раскодированное сообщение с изображения, которое предоврительно будет переведено из pictureBox'a в класс Bitmap, чтобы мы смогли с этим изображением работать. 
        }
       
        private void IDBox_Enter(object sender, EventArgs e)
        {
            IDBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(235))))); ;
        }
       
        private void IDBox_Leave_1(object sender, EventArgs e)
        {
            IDBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
        }

        private void NameBox_Enter(object sender, EventArgs e)
        {
            NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(235))))); ;
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
        }

        private void SurnameBox_Enter(object sender, EventArgs e)
        {
            SurnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(235))))); ;
        }

        private void SurnameBox_Leave(object sender, EventArgs e)
        {
            SurnameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
        }

        private void ActiveBox_Enter(object sender, EventArgs e)
        {
            ActiveBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(235))))); ;
        }

        private void ActiveBox_Leave(object sender, EventArgs e)
        {
            ActiveBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
        }

        private void GroupBox_Enter(object sender, EventArgs e)
        {
            GroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(235)))));
        }

        private void GroupBox_Leave(object sender, EventArgs e)
        {
            GroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(66)))), ((int)(((byte)(90)))));
        }

        private void CreateQR_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
        }

        private void CreateQR_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(59)))), ((int)(((byte)(81)))));
        }

        private void SaveQR_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
        }

        private void InputQR_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
        }

        private void InputQR_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(59)))), ((int)(((byte)(81)))));
        }

        private void OutsideQR_MouseEnter(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(75)))), ((int)(((byte)(76)))));
        }

        private void OutsideQR_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(59)))), ((int)(((byte)(81)))));
        }

        private void SaveQR_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(59)))), ((int)(((byte)(81)))));
        }

        
    }
}

