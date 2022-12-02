using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ModelParameters
{
    // TODO: XML
    public class BedParameters
    {
         /// <summary>
         /// Лист параметров
         /// </summary>
         // TODO: не используется. Нужен?
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
        /// Поле, содержащее растояние от каркаса до верхней части кровати "
        /// </summary>
        public Parameter Distance { get; set; }

        // TODO: XML
        // TODO: не используется. Нужен?
        public void MaxValue()
        {
            Width.Value = Width.MaximumValue;
            Length.Value = Length.MaximumValue;
            Height.Value = Height.MaximumValue;
            Thickness.Value = Thickness.MaximumValue;
            Distance.Value = Distance.MaximumValue;
            
        }

        // TODO: XML
        // TODO: не используется. Нужен?
		public void MinValue()
        {
            Width.Value = Width.MinimumValue;
            Length.Value = Length.MinimumValue;
            Height.Value = Height.MinimumValue;
            Thickness.Value = Thickness.MinimumValue;
            Distance.Value = Distance.MinimumValue;
        }
        /// <summary>
        /// Свойство, присваивающее значение по умолчанию для зависимых параметров
        /// </summary>
        public void DefaultValue()
        {
            Width.Value = Width.DefaultValue;
            Length.Value = Length.DefaultValue;
            Height.Value = Height.DefaultValue;
            Thickness.Value = Thickness.DefaultValue;
            Distance.Value = Distance.DefaultValue;
        }

        // TODO: XML
        public BedParameters()
        {
            Width = new Parameter("Ширина кровати",
                1000, 2000, 1000);
            Length = new Parameter("Длина кровати",
                1800,2100,1800);
            Height = new Parameter("Высота кровати",
                400, 800, 400);
            Thickness = new Parameter("Толщина материала",
                8, 14, 10);
            Distance = new Parameter("Расстояние от каркаса до верхней части кровати",
                100, 250, 100);

            parameters = new List<Parameter>
            {
                Width,
                Length,
                Height,
                Thickness,
                Distance,
            };

        }
    }
}
