using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace 抽奖
{
    public partial class Form1 : Form
    {
        private Random mRandom = new Random();
        private Dictionary<int, bool> mDict = new Dictionary<int, bool>();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = mTotal.ToString();
        }
        private int mTotal = 50;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled)
            {
                int count = mTotal;
                bool result = int.TryParse(textBox1.Text, out count);
                if (!result)
                {
                    return;
                }
                else
                {
                    mTotal = count;
                    textBox1.Enabled = false;
                }
            }
            lock (mDict)
            {
                if (mDict.Count == mTotal)
                {
                    button1.Text = "已达到" + mTotal + "人";
                    return;
                }
                while (true)
                {
                    var val = mRandom.Next(mTotal);
                    if (!mDict.ContainsKey(val))
                    {
                        mDict.Add(val, true);
                        richTextBox1.AppendText((val + 1).ToString() + " ");
                        break;
                    }
                }
            }
        }
    }
}
