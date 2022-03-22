using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labfinal_even
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (var reader = new System.IO.StreamReader(@"C:\Users\Win-10\Downloads\SWE4201MarkSheet.csv"))
            {
                listBox1.Items.Add("ID \t\t Name\t\t\tpercentage\t\tGrade");
                while (!reader.EndOfStream)
                {
                    var Line = reader.ReadLine();
                    var values = Line.Split(',');
                    Student dummy_stu = new Student();
                    try
                    { dummy_stu.Id = values[0]; }
                    catch (Exception ex)
                    { dummy_stu.Id = "0"; }
                    try
                    {
                        dummy_stu.Name = values[1];
                    }
                    catch (Exception ex)
                    {
                        dummy_stu.Name = "0";
                    }
                    try
                    {
                        dummy_stu.attendence = Convert.ToInt32(values[2]);
                    }
                    catch (Exception ex)
                    {
                        dummy_stu.attendence = 0;
                    }
                   
                    try
                    {
                        dummy_stu.quiz1 = Convert.ToInt32(values[3]);
                    }
                    catch(Exception ex)
                    {
                        dummy_stu.quiz1= 0;
                    }
                    try
                    {
                        dummy_stu.quiz2 = Convert.ToInt32(values[4]);
                    }
                    catch( Exception ex)
                    {
                        dummy_stu.quiz2= 0;
                    }
                    try
                    {
                        dummy_stu.quiz3 = Convert.ToInt32(values[5]);
                    }
                    catch( Exception ex)
                    {
                        dummy_stu.quiz3 = 0;
                    }
                    try
                    {
                        dummy_stu.quiz4 = Convert.ToInt32(values[6]);
                    }
                    catch(Exception ex)
                    {
                        dummy_stu.quiz4 = 0;
                    }
                    try
                    {
                        dummy_stu.mid = Convert.ToInt32(values[7]);
                    }
                    catch(Exception ex)
                    {
                        dummy_stu.mid = 0;
                    }
                    try
                    {
                        dummy_stu.final = Convert.ToInt32(values[8]);
                    }
                    catch(Exception ex)
                    {
                        dummy_stu.final = 0;
                    }
                    try
                    {
                        dummy_stu.viva = Convert.ToInt32(values[9]);
                    }
                    catch (Exception ex)
                    {
                        dummy_stu.viva= 0;
                    }

                    double quizsum = Math.Round(calcQuizTotal(dummy_stu.quiz1, dummy_stu.quiz2, dummy_stu.quiz3,
                        dummy_stu.quiz4), 2);
                    double totalMark = Math.Round(totalMarkCalculator(dummy_stu.attendence, dummy_stu.total_quiz, dummy_stu.mid, dummy_stu.final, dummy_stu.viva), 2);
                    double percentage = Math.Round(percentageCalc(totalMark), 2);
                    students.Add(dummy_stu);
                    listBox1.Items.Add(dummy_stu.Id + "\t\t" + dummy_stu.Name + "\t\t" + dummy_stu.percentage + "%" + "\t\t" + dummy_stu.grade);


                }

            }
            
        }
        List<Student> students = new List<Student>();
        public double calcQuizTotal(int quiz1, int quiz2, int quiz3, int quiz4)
        {
            double Quiz1 = Convert.ToDouble(quiz1);
            double Quiz2 = Convert.ToDouble(quiz2);
            double Quiz3 = Convert.ToDouble(quiz3);
            double Quiz4 = Convert.ToDouble(quiz4);
            double[] quizMark = { Quiz1, Quiz2, Quiz3, Quiz4 };
            Array.Sort(quizMark);
            double quizTotal = quizMark[1] + quizMark[2] + quizMark[3];
            return quizTotal;
        }
        public double percentageCalc(double totalMark)
        {
            double percentage = (totalMark * 100) / 300;
            return percentage;
        }
        public double totalMarkCalculator(int attendence, int total_quiz, int mid, int final, int viva)
        {
            double Attendance = Convert.ToDouble(attendence);
            double midMark = Convert.ToDouble(mid);
            double finalMark = Convert.ToDouble(final);
            double vivaMark = Convert.ToDouble(viva);
            double TotalMark = Attendance + total_quiz + midMark + finalMark + vivaMark;
            return TotalMark;
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }
  

        private void button1_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Student dummy in students)
            {
                if (dummy.Id == textBox1.Text)
                {
                   
                        label3.Text = "Attendence : " + dummy.attendence.ToString();
                        label4.Text = "Quiz1 : " + dummy.quiz1.ToString();
                        label5.Text = "Quiz2 : " + dummy.quiz2.ToString();
                        label6.Text = "Quiz3 :" + dummy.quiz3.ToString();
                        label7.Text = "Quiz4 :" + dummy.quiz4.ToString();
                        label8.Text = "Quiz Total(best3)"  ;
                        label9.Text = "Mid :" + dummy.mid.ToString();
                        label10.Text = "Final" + dummy.final.ToString();
                        label11.Text = "Viva" + dummy.viva.ToString();
                        label12.Text = "Total(Outof 300) :";



                  
                    found = true;
                }
            }
            if (!found)
            {
                MessageBox.Show("Put an valid ID");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        

        }
    }
}
