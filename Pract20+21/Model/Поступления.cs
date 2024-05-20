using System;
using System.Collections.Generic;

namespace Pract20_21.Model;

public partial class Поступления
{
    public int НомерНакладной { get; set; }

    public int КодТовара { get; set; }

    public int КоличествоПоступления { get; set; }

    public DateTime ДатаПоступления { get; set; }

    public virtual Ценник КодТовараNavigation { get; set; } = null!;
}
