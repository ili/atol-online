namespace AtolOnline.V5.Enums;

public enum Measurement
{
    /// <summary>
    /// 0 - Применяется для предметов расчета, которые могут быть
    /// реализованы поштучно или единицами (а также в случае, если
    /// предметом расчета является товар, подлежащий обязательной
    /// маркировке средством идентификации (передан mark_code))
    /// </summary>
    Quantity = 0,

    /// <summary>
    /// Грамм
    /// </summary>
    Gr = 10,

    /// <summary>
    /// Килограмм
    /// </summary>
    Kg = 11,

    /// <summary>
    /// Тонна
    /// </summary>
    Ton = 12,

    /// <summary>
    /// Сантиметр
    /// </summary>
    Centimeter = 20,

    /// <summary>
    /// Дециметр
    /// </summary>
    Decimeter = 21,

    /// <summary>
    /// Метр
    /// </summary>
    Meter = 22,

    /// <summary>
    /// Квадратный сантиметр
    /// </summary>
    SquareCentimeter = 30,

    /// <summary>
    /// Квадратный дециметр
    /// </summary>
    SquareDecimeter = 31,

    /// <summary>
    /// Квадратный метр
    /// </summary>
    SquareMeter = 32,

    /// <summary>
    /// Миллилитр
    /// </summary>
    Milliliter = 40,

    /// <summary>
    /// Литр
    /// </summary>
    Liter = 41,

    /// <summary>
    /// Кубический метр
    /// </summary>
    CubicMeter = 42,

    /// <summary>
    /// Киловатт час
    /// </summary>
    KilowattHour = 50,

    /// <summary>
    /// Гигакалория
    /// </summary>
    Gigacalorie = 51,

    /// <summary>
    /// Сутки (день)
    /// </summary>
    Day = 70,

    /// <summary>
    /// Час
    /// </summary>
    Hour = 71,

    /// <summary>
    /// Минута
    /// </summary>
    Minute = 72,

    /// <summary>
    /// Секунда
    /// </summary>
    Second = 73,

    /// <summary>
    /// Килобайт
    /// </summary>
    Kilobyte = 80,

    /// <summary>
    /// Мегабайт
    /// </summary>
    Megabyte = 81,

    /// <summary>
    /// Гигабайт
    /// </summary>
    Gigabyte = 82,

    /// <summary>
    /// Терабайт
    /// </summary>
    Terabyte = 83,

    /// <summary>
    /// Применяется при использовании иных единиц измерени
    /// </summary>
    Other = 255
}
