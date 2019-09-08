using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanApp
{
    class Note
    {
        public int number; //номер 
        public string description;//описание
        public DateTime startDate; //дата начала задания
        public DateTime endDate; // дата конца задания

        public Note(int _number, string _description, DateTime _startDate, DateTime _endDate)
        {
            number = _number;
            description = _description;
            startDate = _startDate;
            endDate = _endDate;
        }

        public Note() { }
    }

}
