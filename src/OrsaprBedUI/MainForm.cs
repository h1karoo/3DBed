using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelBuilder;
using ModelParameters;

namespace OrsaprBedUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Словарь для хранения сведений о TextBox
        /// </summary>
        private readonly Dictionary<TextBox, Action<ModelParameters.BedParameters, string>>
            _textBoxDictionary;

        /// <summary>
        /// Поле хранящее данные о кровати
        /// </summary>
        private BedParameters _bed = new BedParameters { };

        /// <summary>
        /// Поле для хранения данных о билдере
        /// </summary>
        private BedBuilder _build = new BedBuilder();

        /// <summary>
        /// Лист параметров
        /// </summary>
        private readonly List<Parameter> _parameters;

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private readonly List<TextBox> _textBoxList;

        /// <summary>
        /// Лист c текстбоксами
        /// </summary>
        private readonly List<Label> _labelList;

        public MainForm()
        {
            InitializeComponent();
            _textBoxDictionary = new Dictionary<TextBox, Action<BedParameters, string>>()
            {
                {
                    textBoxWidth,
                    (BedParameters bed, string text) =>
                    {
                        try
                        {
                            bed.Width.Value = double.Parse(text);
                        }
                        catch (Exception exception)
                        {
                            textBoxWidth.BackColor = Color.Red;
                            MessageBox.Show(exception.Message);
                        }
                    }
                },
                {
                    textBoxLength,
                    (BedParameters bed, string text) =>
                    {
                        try
                        {
                            bed.Length.Value = double.Parse(text);
                        }
                        catch (Exception exception)
                        {
                            textBoxLength.BackColor = Color.Red;
                            MessageBox.Show(exception.Message);
                        }
                    }
                },
                {
                    textBoxHeight,
                    (BedParameters bed, string text) =>
                    {
                        try
                        {
                            bed.Height.Value = double.Parse(text);
                        }
                        catch (Exception exception)
                        {
                            textBoxHeight.BackColor = Color.Red;
                            MessageBox.Show(exception.Message);
                        };
                    }
                },
                {
                    textBoxThickness,
                    (BedParameters bed, string text) =>
                    {
                        try
                        {
                            bed.Thickness.Value = double.Parse(text);
                        }
                        catch (Exception exception)
                        {
                            textBoxThickness.BackColor = Color.Red;
                            MessageBox.Show(exception.Message);
                        };
                    }
                },
                {
                    textBoxDistance,
                    (BedParameters bed, string text) =>
                    {
                        try
                        {
                            bed.Distance.Value = double.Parse(text);
                        }
                        catch (Exception exception)
                        {
                            textBoxDistance.BackColor = Color.Red;
                            MessageBox.Show(exception.Message);
                        };
                    }
                }

             };

            _parameters = new List<Parameter>
            {
                _bed.Width,
                _bed.Length,
                _bed.Height,
                _bed.Thickness,
                _bed.Distance,
            };

            _textBoxList = new List<TextBox>()
            {
                textBoxWidth,
                textBoxLength,
                textBoxHeight,
                textBoxThickness,
                textBoxDistance,
            };

            _labelList = new List<Label>
            {
                labelWidth,
                labelLength,
                labelHeight,
                labelThickness,
                labelDistance,
            };

            _bed.DefaultValue();
            UpdateFormFields();
            SetLimits();
        }


        /// <summary>
        /// Обработчик для присваивания значений из TextBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxLeave(object sender, EventArgs e)
        {
            var currentTextBox = (TextBox)sender;
            var currentAction = _textBoxDictionary[currentTextBox];
            if (!String.IsNullOrEmpty(currentTextBox.Text))
            {
                try
                {
                    currentAction.Invoke(_bed, currentTextBox.Text);
                    currentTextBox.BackColor = Color.White;
                    SetLimits();
                    UpdateFormFields();
                    if (Validate())
                    {
                        buttonBuildBed.Enabled = true;
                    }
                }
                catch (ArgumentException exception)
                {
                    
                    currentTextBox.BackColor = Color.Red;
                    MessageBox.Show(exception.Message);
                }
            }
        }

        /// <summary>
        /// Метод для проверки на соответствие сохраненных и введенных параметров
        /// </summary>
        /// <returns></returns>
        private bool Validate()
        {
            var smallestUpperBound = Math.Min(_textBoxList.Count, _parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                if (_textBoxList[index].Text.ToString() != _parameters[index].Value.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Метод, присваивающий значение предустановленных параметров в TextBox
        /// </summary>
        private void UpdateFormFields()
        {
            var smallestUpperBound = Math.Min(_textBoxList.Count, _parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                _textBoxList[index].Text = _parameters[index].Value.ToString();
            }
        }

        /// <summary>
        /// Метод для проброса минимальных и максимальных параметров в label формы
        /// </summary>
        private void SetLimits()
        {
            var smallestUpperBound = Math.Min(_labelList.Count, _parameters.Count);
            for (var index = 0; index < smallestUpperBound; index++)
            {
                _labelList[index].Text = Convert.ToString($"{_parameters[index].NameParameter} " +
                                                          $"({_parameters[index].MinimumValue} - " +
                                                          $"{_parameters[index].MaximumValue}) мм");
            }
        }

        private void buttonBuildBed_Click(object sender, EventArgs e)
        {
            _build.BuildBed(_bed);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxDistance_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


