using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        private double _num1, _num2;
        private char _operate;
        bool _fixer = false;

        public Form1()
        {
            InitializeComponent();
            _num1 = _num2 = 0.0;
            _operate = '\0';
        }

        private void btnClickEvents(object sender, EventArgs e)
        {
            if (_fixer == true) {
                outputBox.Clear();
                _fixer = false;
            }
            Button _numButtons = sender as Button;
            if (_numButtons != null)
            outputBox.Text += _numButtons.Text;
        }

        private void btnOperates(object sender, EventArgs e)
        {
            Button _operateButtons = sender as Button;
            if (_operateButtons != null && !string.IsNullOrEmpty(_operateButtons.Text) && _operateButtons.Text.Length == 1)
            {
                _num1 = Convert.ToDouble(outputBox.Text);
                _operate = _operateButtons.Text[0];
                previewBox.Text = $"{_operate} {_num1}";
                _fixer = true;
            }
        }

        private void btnEqualEvent(object sender, EventArgs e)
        {
            double _answer = 0.0;

            if (double.TryParse(outputBox.Text, out _num2))
            {
                if (_num2 == 0 && _operate == '/')
                {
                    outputBox.Text = "Hata: 0x0";
                    previewBox.Clear();
                    return;
                }
            }
            else
            {
                outputBox.Text = "Hata: Geçersiz Sayı";
                previewBox.Clear();
                return;
            }

            switch (_operate)
            {
                case '-':
                    _answer = _num1 - _num2;
                    break;
                case '+':
                    _answer = _num1 + _num2;
                    break;
                case '/':
                    _answer = _num1 / _num2;
                    break;
                case '*':
                    _answer = _num1 * _num2;
                    break;
            }

            _fixer = true;
            previewBox.Text = $"= {_num2} {_operate} {_num1}";
            outputBox.Text = Convert.ToString(_answer);
        }

        private void btnClearEvent(object sender, EventArgs e)
        {
            outputBox.Clear();
            previewBox.Clear();
            return;
        }
    }
}
