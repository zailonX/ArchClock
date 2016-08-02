using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2014080_Shikka_ArchClock
{
    public partial class Form1 : Form
    {
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //this.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point FormCenter = new Point(Form1.ActiveForm.Width / 2, Form1.ActiveForm.Height / 2);
            Bitmap Bmap = new Bitmap(Form1.ActiveForm.Width, Form1.ActiveForm.Height);
            Bmap.SetResolution(1080, 1080);
            Graphics g = Graphics.FromImage(Bmap);
            DateTime now = DateTime.Now;NodaTime.LocalDateTime NDateTime;
            
        
            NDateTime = new NodaTime.LocalDateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            Color backColor = Color.Transparent;

            int StartAngle = 270;
            int ArchWidthDiff = 90;

            int YearArchWidth = ArchWidthDiff * 7;
            int YearArchHeight = YearArchWidth;
            int YearArchSweepAngle = (int)(NDateTime.DayOfYear * 0.9856478718219701);


            int MonthArchWidth = ArchWidthDiff * 6;
            int MonthArchHeight = MonthArchWidth;
            int MonthArchSweepAngle = (int)((NDateTime.Hour + NDateTime.Day * 24) * 0.492823935910985);// 730.484 hours in a month. CurrentHour/TotalHoursInMonth.


            int dayOfWeekArchWidth = ArchWidthDiff * 5; 
            int dayOfWeekArchHeight = dayOfWeekArchWidth;
            int dayOfWeekArchSweepAngle = (int)(NDateTime.Hour * 2.142857142857143);// 168 hours in week/360 degrees in an angle. CurrentHour/TotalHoursInWeek.


            int hourArchWidth = ArchWidthDiff*4;
            int hourArchHeight = hourArchWidth;
            int hourArchSweepAngle = NDateTime.Hour * 15;

            int minuteArchWidth = ArchWidthDiff*3;
            int minuteArchHeight = minuteArchWidth;
            int minuteArchSweepAngle = NDateTime.Minute * 6;

            int secondArchWidth = ArchWidthDiff*2;
            int secondArchHeight = secondArchWidth;
            int secondArchSweepAngle = NDateTime.Second * 6;

            int centerCapWidth = ArchWidthDiff;
            int centerCapHeight = centerCapWidth;

            Rectangle YearArchBox = new Rectangle(FormCenter.X - YearArchWidth / 2, FormCenter.Y - YearArchHeight / 2, YearArchWidth, YearArchHeight);
            Rectangle MonthArchBox = new Rectangle(FormCenter.X - MonthArchWidth / 2, FormCenter.Y - MonthArchHeight / 2, MonthArchWidth, MonthArchHeight);
            Rectangle dayArchBox = new Rectangle(FormCenter.X - dayOfWeekArchWidth / 2, FormCenter.Y - dayOfWeekArchHeight / 2, dayOfWeekArchWidth, dayOfWeekArchHeight);
            Rectangle hourArchBox = new Rectangle(FormCenter.X - hourArchWidth / 2, FormCenter.Y - hourArchHeight / 2, hourArchWidth, hourArchHeight);
            Rectangle minuteArchBox = new Rectangle(FormCenter.X - minuteArchWidth / 2, FormCenter.Y - minuteArchHeight / 2, minuteArchWidth, minuteArchHeight);
            Rectangle secondArchBox = new Rectangle(FormCenter.X - secondArchWidth / 2, FormCenter.Y - secondArchHeight / 2, secondArchWidth, secondArchHeight);

            Rectangle centerCapBox = new Rectangle(FormCenter.X - centerCapWidth / 2, FormCenter.Y - centerCapHeight / 2, centerCapWidth, centerCapHeight);


            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.FillEllipse(Brushes.Gray, YearArchBox);
            g.FillPie(Brushes.HotPink, YearArchBox, StartAngle, YearArchSweepAngle);
            g.FillEllipse(Brushes.Gray, MonthArchBox);
            g.FillPie(Brushes.Honeydew, MonthArchBox, StartAngle, MonthArchSweepAngle);
            g.FillEllipse(Brushes.Gray, dayArchBox);
            g.FillPie(Brushes.CornflowerBlue, dayArchBox, StartAngle, dayOfWeekArchSweepAngle);
            g.FillEllipse(Brushes.Gray, hourArchBox);
            g.FillPie(Brushes.Gold, hourArchBox, StartAngle, hourArchSweepAngle);
            g.FillEllipse(Brushes.Gray, minuteArchBox);
            g.FillPie(Brushes.Fuchsia, minuteArchBox, StartAngle, minuteArchSweepAngle);
            g.FillEllipse(Brushes.Gray, secondArchBox);
            g.FillPie(Brushes.Aquamarine, secondArchBox, StartAngle, secondArchSweepAngle);

            g.FillPie(Brushes.White, centerCapBox, StartAngle, 360);
            
            
            

            this.BackgroundImage = Bmap;
        }
    }
}
