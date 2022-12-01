using System;

namespace ModelParameters
{
    public class Parameter
    {
        /// <summary>
        /// Поле, хранящее значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Поле, хранящее максимально допустимое значение параметра
        /// </summary>
        private double _maxValue;

        /// <summary>
        ///  Поле, хранящее Минимально допустимое значение параметра
        /// </summary>
        private double _minValue;

        /// <summary>
        ///  Поле, хранящее значение по умолчанию для параметра
        /// </summary>
        private double _defaultValue;

        /// <summary>
        /// Свойство, хранящее значения параметра
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (String.IsNullOrEmpty(NameParameter))
                {
                    throw new ArgumentException("Имя параметра не определено");
                }
                if (_maxValue > 0 && _minValue > 0)
                {
                    if (value <= _maxValue && value >= _minValue)
                    {
                        _value = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Параметр {NameParameter} " +
                                                    $"должен быть меньше {_maxValue} " +
                                                    $"и больше {_minValue}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Максимальное и минимальное значение параметра {NameParameter} не установлено");
                }
            }
        }

        /// <summary>
        /// Поле, хранящее максимальное допустимое значение параметра
        /// </summary>
        public double MaximumValue
        {
            get => _maxValue;
            set
            {
                if (_minValue > 0)
                {
                    if (value > _minValue)
                    {
                        _maxValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Максимальное значение не модет быть больше минимального = {_minValue}");
                    }
                }
                else
                {
                    if (value > 0)
                    {
                        _maxValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Максимальное значение должно быть больше 0");
                    }
                }
            }
        }

        /// <summary>
        /// Свойство, хранящее минимально допустимое значение параметра
        /// </summary>
        public double MinimumValue
        {
            get => _minValue;
            set
            {
                if (_maxValue > 0)
                {
                    if (value < _maxValue)
                    {
                        _minValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Минимальное значение не должно привышать = {_maxValue}");
                    }
                }
                else
                {
                    if (value > 0)
                    {
                        _minValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Минимальное значение должно быть больше 0");
                    }

                }
            }
        }

        /// <summary>
        /// Свойство, хранящее название параметра
        /// </summary>
        public string NameParameter { get; set; }

        /// <summary>
        /// Свойство, хранящее параметр по умолчанию
        /// </summary>
        public double DefaultValue
        {
            get => _defaultValue;
            set
            {
                if (_maxValue > 0 && _minValue > 0)
                {
                    if (value <= _maxValue && value >= _minValue)
                    {
                        _defaultValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Параметр {NameParameter} " +
                                                    $"должен быть меньше {_maxValue} " +
                                                    $"и больше {_minValue}");
                    }
                }
                else
                {
                    throw new ArgumentException($"Максимальное и минимальное значение параметра {NameParameter} не установлено" );
                }
            }
        }

        public Parameter() { }

        public Parameter(string name, double min, double max, double defaultValue)
        {
            this.MinimumValue = min;
            this.MaximumValue = max;
            this.NameParameter = name;
            this.DefaultValue = defaultValue;
        }

    }
}
