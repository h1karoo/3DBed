using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ModelParameters;

namespace ModelParameters
{    
    /// <summary>
    /// Класс, содержащий параметры кровати
    /// </summary>
    public class BedParameters
    {
         /// <summary>
         /// Лист параметров
         /// </summary>
         private readonly List<Parameter> parameters;

        /// <summary>
        /// Поле, содержащее длину кровати 
        /// </summary>
        public Parameter Length { get; set; }


        /// <summary>
        /// Поле, содержащее ширину кровати
        /// </summary>
        public Parameter Width { get; set; }


        /// <summary>
        /// Поле, содержащее высоту кровати
        /// </summary>
        public Parameter Height { get; set; }

        /// <summary>
        /// Поле, содержащее толщину материала"
        /// </summary>
        public Parameter Thickness { get; set; }

        /// <summary>
        /// Поле, содержащее растояние от каркаса до верхней части кровати
        /// </summary>
        public Parameter Distance { get; set; }
        /// <summary>
        /// Поле, содержащее высоту второй кровати
        /// </summary>
        public Parameter TwoStorey { get; set; }

        // <summary>
        /// Свойство, присваивающее максимальное значение "
        /// </summary>
        public void SetMaxValue()
        {
            Width.Value = Width.MaximumValue;
            Length.Value = Length.MaximumValue;
            Height.Value = Height.MaximumValue;
            Thickness.Value = Thickness.MaximumValue;
            Distance.Value = Distance.MaximumValue;
            TwoStorey.Value = TwoStorey.MaximumValue;
        }

		// <summary>
		/// Свойство, присваивающее минимальное значение "
		/// </summary>
		public void SetMinValue()
        {
            Width.Value = Width.MinimumValue;
            Length.Value = Length.MinimumValue;
            Height.Value = Height.MinimumValue;
            Thickness.Value = Thickness.MinimumValue;
            Distance.Value = Distance.MinimumValue;
            TwoStorey.Value = TwoStorey.MinimumValue;
        }
		/// <summary>
		/// Свойство, присваивающее значение по умолчанию для зависимых параметров
		/// </summary>
		public void SetDefaultValue()
        {
            Width.Value = Width.DefaultValue;
            Length.Value = Length.DefaultValue;
            Height.Value = Height.DefaultValue;
            Thickness.Value = Thickness.DefaultValue;
            Distance.Value = Distance.DefaultValue;
            TwoStorey.Value = TwoStorey.DefaultValue;
        }

        public BedParameters()
        {
            this.Width = new Parameter("Ширина кровати",
                1000, 2000, 1000);
            this.Length = new Parameter("Длина кровати",
                1800, 2100, 1800);
            this.Height = new Parameter("Высота кровати",
                400, 800, 400);
            this.Thickness = new Parameter("Толщина материала",
                8, 14, 10);
            this.Distance = new Parameter("Расстояние от каркаса до верхней части кровати",
                100, 250, 100);
            this.TwoStorey = new Parameter("Высота",
                500, 800,600);

            parameters = new List<Parameter>
            {
                Width,
                Length,
                Height,
                Thickness,
                Distance,
                TwoStorey,
            };

        }
    }
}
