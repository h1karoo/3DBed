using System;
using Kompas3DConnector;
using Kompas6API5;
using Kompas6Constants3D;
using ModelParameters;

namespace ModelBuilder
{
    /// <summary>
    ///Класс для построения кровати
    /// </summary>
    public class BedBuilder
    {
        /// <summary>
        ///Метод построения кровати
        /// </summary>
        public void BuildBed(BedParameters bed, bool isBedTwoStorey)
        {
            KompasConnector.Instance.InitializationKompas();
            BuildStorey(bed.Length.Value, bed.Width.Value,0,bed.Thickness.Value, bed.Distance.Value,bed.Height.Value);
            if (isBedTwoStorey)
            {
                BuildStorey(bed.Length.Value, bed.Width.Value, bed.TwoStorey.Value, 
                    bed.Thickness.Value, bed.Distance.Value + bed.TwoStorey.Value, bed.Height.Value / 2);
                BuildLegs(bed.Length.Value, bed.Width.Value, bed.Height.Value, bed.Thickness.Value, bed.TwoStorey.Value );
            }
        }

        /// <summary>
        ///Метод построения яруса
        /// </summary>
        public void BuildStorey(double length, double width, double heightBuild, double thickness, double distance, double depth)
        {
            // Создание каркаса
            CreateRectangle(
                -length / 2 + thickness,
                -width / 2 + thickness,
                length - thickness * 2,
                width - thickness * 2,
                thickness * 2, heightBuild);
            // Создание правой боковой стенки
            CreateRectangle(-length / 2 + thickness,
                -width / 2,
                length - thickness * 2,
                thickness * 2, depth,
                distance);
            // Создание левой боковой стенки
            CreateRectangle(-length / 2 + thickness,
                width / 2 - thickness,
                length - thickness * 2,
                thickness * 2, depth,
                distance);
            // Создание задней стенки
            CreateRectangle(-length / 2,
                -width / 2,
                thickness * 2,
                width,
                depth,
                distance);
            // Создание изголовья
            CreateRectangle(length / 2 - thickness,
                -width / 2,
                thickness * 2,
                width,
                depth,
                distance);
        }

        /// <summary>
        ///Метод построения ножек
        /// </summary>
        public void BuildLegs( double length, double width, double heightBuild, double thickness, double twoStorey) 
        {
            // Создание ножки
            CreateRectangle(-length / 2,
                -width / 2,
                thickness * 2,
                thickness * 2,
                heightBuild * 1.75,
                twoStorey);
            // Создание ножки
            CreateRectangle(-length / 2,
                width - width / 2 - thickness * 2,
                thickness * 2,
                thickness * 2,
                heightBuild * 1.75,
                twoStorey);
            //Создание ножки
            CreateRectangle(length / 2 - thickness * 2,
                -width / 2,
                thickness * 2,
                thickness * 2,
                heightBuild * 1.75,
                twoStorey);
            //Создание ножки
            CreateRectangle(length / 2 - thickness * 2,
                width / 2 - thickness * 2,
                thickness * 2,
                thickness * 2,
                heightBuild * 1.75,
                twoStorey);
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
