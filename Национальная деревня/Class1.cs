using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Национальная_деревня
{
    public partial class Расписание
    {
        public override string ToString()
        {
            return день_и_время+название_события;


        }
    }
    public partial class Билеты
    {
        public override string ToString()
        {
            return тип + цена;


        }
    }
    public partial class Посетители

    {
        public override string ToString()
        {
            return ФИО + номер+ почта+login+password;


        }
    }
    public partial class Заказ

    {
        public override string ToString()
        {
            return Convert.ToString (количество_билетов + итоговая_стоимость);


        }
    }
}
