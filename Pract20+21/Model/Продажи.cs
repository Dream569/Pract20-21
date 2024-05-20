using System;
using System.Collections.Generic;

namespace Pract20_21.Model;

public partial class Продажи
{
    public int НомерЧека { get; set; }

    public int КодТовара { get; set; }

    public int КоличествоПродано { get; set; }

    public DateTime ДатаПродажи { get; set; }

    public virtual Ценник КодТовараNavigation { get; set; } = null!;
}
