using System;
using Kompas3DConnector;
using Kompas6API5;
using Kompas6Constants3D;
using ModelParameters;
using static System.Net.Mime.MediaTypeNames;

namespace ModelBuilder
{
    // TODO: XML
    /// <summary>
    ///Класс для построения кровати
    /// </summary>
    public class BedBuilder
    {
        /// <summary>
        ///Метод построения кровати
        /// </summary>
        public void BuildBed(BedParameters bed)
        {
            KompasConnector.Instance.InitializationKompas();
            // TODO: длина строк
            // Создание каркаса
            {
                if (bed.Width.Value > 1500)
                {
                    CreateRectangle(
                        -bed.Length.Value / 2 + bed.Thickness.Value,
                        -bed.Width.Value / 2 + bed.Thickness.Value,
                        bed.Length.Value - bed.Thickness.Value * 2,
                        bed.Width.Value - bed.Thickness.Value * 2,
                        bed.Thickness.Value * 2, 0);
                    // Создание правой боковой стенки
                    CreateRectangle(-bed.Length.Value / 2 + bed.Thickness.Value,
                        -bed.Width.Value / 2,
                        bed.Length.Value - bed.Thickness.Value * 2,
                        bed.Thickness.Value * 2, bed.Height.Value,
                        bed.Distance.Value);
                    // Создание левой боковой стенки
                    CreateRectangle(-bed.Length.Value / 2 + bed.Thickness.Value,
                        bed.Width.Value / 2 - bed.Thickness.Value,
                        bed.Length.Value - bed.Thickness.Value * 2,
                        bed.Thickness.Value * 2, bed.Height.Value,
                        bed.Distance.Value);
                    // Создание задней стенки
                    CreateRectangle(-bed.Length.Value / 2,
                        -bed.Width.Value / 2,
                        bed.Thickness.Value * 2,
                        bed.Width.Value,
                        bed.Height.Value,
                        bed.Distance.Value);
                    // Создание изголовья
                    CreateRectangle(bed.Length.Value / 2 - bed.Thickness.Value,
                        -bed.Width.Value / 2,
                        bed.Thickness.Value * 2,
                        bed.Width.Value,
                        bed.Height.Value,
                        bed.Distance.Value);
                }
                else
                {
                    CreateRectangle(
                        -bed.Length.Value / 2 + bed.Thickness.Value,
                        -bed.Width.Value / 2 + bed.Thickness.Value,
                        bed.Length.Value - bed.Thickness.Value * 2,
                        bed.Width.Value - bed.Thickness.Value * 2,
                        bed.Thickness.Value, 0);
                    // Создание правой боковой стенки
                    CreateRectangle(-bed.Length.Value / 2 + bed.Thickness.Value,
                        -bed.Width.Value / 2,
                        bed.Length.Value - bed.Thickness.Value * 2,
                        bed.Thickness.Value, bed.Height.Value,
                        bed.Distance.Value);
                    // Создание левой боковой стенки
                    CreateRectangle(-bed.Length.Value / 2 + bed.Thickness.Value,
                        bed.Width.Value / 2 - bed.Thickness.Value,
                        bed.Length.Value - bed.Thickness.Value * 2,
                        bed.Thickness.Value, bed.Height.Value,
                        bed.Distance.Value);
                    // Создание задней стенки
                    CreateRectangle(-bed.Length.Value / 2,
                        -bed.Width.Value / 2,
                        bed.Thickness.Value,
                        bed.Width.Value,
                        bed.Height.Value,
                        bed.Distance.Value);
                    // Создание изголовья
                    CreateRectangle(bed.Length.Value / 2 - bed.Thickness.Value,
                        -bed.Width.Value / 2,
                        bed.Thickness.Value,
                        bed.Width.Value,
                        bed.Height.Value,
                        bed.Distance.Value);
                }
            }
        }
        /// <summary>
        /// Метод для построения параллелипипеда
        /// </summary>
        private void CreateRectangle(double xc, double yc, double length, double width,
            double depth, double heightBuild)
        {

            ksEntity currentPlane = (ksEntity)KompasConnector.Instance.
                KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

            ksEntity sketch = (ksEntity)KompasConnector.Instance.
                KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            var sketchDef = CreateSketch(heightBuild);
            sketchDef.SetPlane(currentPlane);
            sketch.Create();
            ksDocument2D document2D = (ksDocument2D)sketchDef.BeginEdit();
            document2D.ksLineSeg(xc, yc, xc + length, yc, 1);
            document2D.ksLineSeg(xc, yc, xc, yc + width, 1);
            document2D.ksLineSeg(xc + length, yc, xc + length, yc + width, 1);
            document2D.ksLineSeg(xc, yc + width, xc + length, yc + width, 1);
            sketchDef.EndEdit();
            BossExtrusion(depth, sketchDef, false);
        }


        /// <summary>
        /// Метод для создания эскиза
        /// </summary>
        /// <param name="heightPlane">Высота плоскости</param>
        /// <returns>Эскиз</returns>
        private ksSketchDefinition CreateSketch(double heightPlane)
        {
            ksEntity currentPlane = (ksEntity)KompasConnector
                .Instance.KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksEntity newPlane = (ksEntity)KompasConnector
                .Instance.KompasPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            // Интерфейс настроек смещенной плоскости
            ksPlaneOffsetDefinition newPlaneDefinition =
                (ksPlaneOffsetDefinition)newPlane.GetDefinition();

            // начальная позиция плоскости: от предыдущей
            newPlaneDefinition.SetPlane(currentPlane);
            // направление смещения: прямое
            newPlaneDefinition.direction = true;
            // расстояние смещения
            newPlaneDefinition.offset = heightPlane;
            // создать плоскость
            newPlane.Create();
            // установить последнюю созданную плоскость текущей
            currentPlane = newPlane;

            ksEntity Sketch = (ksEntity)KompasConnector
                .Instance.KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition SketchDef = Sketch.GetDefinition();
            SketchDef.SetPlane(currentPlane);
            Sketch.Create();
            return SketchDef;
        }
        /// <summary>
        /// Метод для выдавливания
        /// </summary>
        /// <param name="height">Высота выдавливания</param>
        /// <param name="sketchDef">Эскиз</param>
        /// <param name="forward">Направление выдавливания</param>
        /// <param name="thin">тонкая стенка</param>
        private void BossExtrusion(double height, ksSketchDefinition sketchDef, bool forward)
        {
            var iBaseExtrusionEntity = (ksEntity)KompasConnector.Instance.
                KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            // интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef = (ksBossExtrusionDefinition)iBaseExtrusionEntity.GetDefinition();

            iBaseExtrusionDef.SetSideParam(forward, 0, height);

            if (forward == false)
            {
                iBaseExtrusionDef.directionType = (short)Direction_Type.dtReverse;
            }
            // эскиз операции выдавливания
            iBaseExtrusionDef.SetSketch(sketchDef);
            // создать операцию
            iBaseExtrusionEntity.Create();
        }
    }
}
