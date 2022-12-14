using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Runtime.InteropServices;
// TODO: Не изменять значение на стандартное при ошибкe
// TODO: Добавить зависимости


namespace Kompas3DConnector
{
    /// <summary>
    /// Класс для соединения с API Компас-3D
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Поле для создание интерфейса
        /// </summary>
        private static KompasConnector _instance;

        /// <summary>
        /// Свойство для реализации интерфейса API Компас 
        /// </summary>
        public static KompasConnector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new KompasConnector();

                return _instance;
            }
        }

        /// <summary>
        /// Свойство для реализации связи с API Компас
        /// </summary>
        public KompasObject KompasObject { get; set; }

        /// <summary>
        /// Сойство для реализации связи с частями детали
        /// </summary>
        public ksPart KompasPart { get; set; }

        /// <summary>
        /// Сойство для реализации связи с 3D эскизом
        /// </summary>
        public ksDocument3D Document3D { get; set; }

        /// <summary>
        /// Метод запуска Компас в режиме детали, инициализации свойств Document3D, KompasPart и KompasObject
        /// </summary>
        public void InitializationKompas()
        {
            try
            {
                if (KompasObject != null)
                {
                    Document3D.close();
                }
                if (KompasObject == null)
                {
                    Type progId = Type.GetTypeFromProgID("KOMPAS.Application.5");

                    KompasObject = (KompasObject)Activator.CreateInstance(progId);
                }
                Document3D = (Document3D)KompasObject.Document3D();
                Document3D.Create(false, true);
                KompasPart = (ksPart)Document3D.GetPart((short)Part_Type.pTop_Part);
                KompasObject.Visible = true;
                KompasObject.ActivateControllerAPI();
            }
            catch (Exception e)
            {
                KompasObject = null;
                InitializationKompas();
            }
        }

		// TODO: ?
		/// <summary>
		/// Метод для выгрузки и выхода из компаса
		/// </summary>

		// TODO: ?
		/// <summary>
		/// Конструктор класса
		/// </summary>
	}
}
